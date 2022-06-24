using ChargeProcess.Customers.Application.Services;
using ChargeProcess.Customers.Domain.Repositories;
using ChargeProcess.Customers.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ChargeProcess.Customers.Application.Commands.Customers
{
    public class CustomerCommand : IRequestHandler<CustomerRequest, CustomerResponse>
    {
        private ICustomerWriteRepository WiteRepository { get; set; }
        private ICustomerReadRepository ReadRepository { get; set; }
        private IMessageService<CustomerResponse> MessageService { get; }

        public CustomerCommand(ICustomerWriteRepository repository, ICustomerReadRepository readRepository, IMessageService<CustomerResponse> messageService)
        {
            WiteRepository = repository;
            ReadRepository = readRepository;
            MessageService = messageService;
        }

        public async Task<CustomerResponse> Handle(CustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customerAdapter = new CustomerAdapter().Adapt(request);
                var customerExist = await ReadRepository.GetCustomerByDocument(request.DocumentId);
                
                if (customerExist != null)
                {
                    return await MessageService.ReturnError(new CustomerResponse(),
                                                            "Document already exists",
                                                            StatusCodes.Status500InternalServerError,
                                                            cancellationToken);
                }   
                
                await WiteRepository.Save(customerAdapter);

                return await Task.FromResult(new CustomerResponse() 
                { 
                    Message = $"Saved Successful with Id: {customerAdapter.Id}", 
                    StatusCode = StatusCodes.Status200OK 
                });
            } catch (Exception ex)
            {
                return await Task.FromResult(new CustomerResponse()
                {
                    Message = $"Unexpected error: {ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError
                });
            }
        }
    }
}
