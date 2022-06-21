using ChargeProcess.Customers.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ChargeProcess.Customers.Application.Commands.Customers
{
    public class CustomerCommand : IRequestHandler<CustomerRequest, CustomerResponse>
    {
        private ICustomerWriteRepository Repository { get; set; }

        public CustomerCommand(ICustomerWriteRepository repository)
        {
            Repository = repository;
        }

        public async Task<CustomerResponse> Handle(CustomerRequest request, CancellationToken cancellationToken)
        {
            try
            {
                request.Customer.Id = Guid.NewGuid().ToString();
                await Repository.Save(request.Customer);
                return await Task.FromResult(new CustomerResponse() 
                { 
                    Message = $"Saved Successful with Id {request.Customer.Id}", 
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
