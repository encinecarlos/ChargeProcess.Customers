using AutoMapper;
using ChargeProcess.Customers.Application.DataTransferObjects;
using ChargeProcess.Customers.Application.Services;
using ChargeProcess.Customers.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeProcess.Customers.Application.Queries.GetCustomerBydocument
{
    public class GetCustomerByDocumentQuery : IRequestHandler<GetCustomerByDocumentRequest, GetCustomerByDocumentResponse>
    {
        private ICustomerReadRepository CustomerReadRepository { get; set; }
        private IMessageService<GetCustomerByDocumentResponse> MessageService { get; }
        private IMapper Mapper { get; }

        public GetCustomerByDocumentQuery(ICustomerReadRepository customerReadRepository, IMessageService<GetCustomerByDocumentResponse> messageService, IMapper mapper)
        {
            CustomerReadRepository = customerReadRepository;
            MessageService = messageService;
            Mapper = mapper;
        }

        public async Task<GetCustomerByDocumentResponse> Handle(GetCustomerByDocumentRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await CustomerReadRepository.GetCustomerByDocument(request.DocumentId);

                var response = Mapper.Map<CustomerDto>(customer);

                return await Task.FromResult(new GetCustomerByDocumentResponse
                {
                    Customer = response,
                    Message = "Success",
                    StatusCode = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Uexpected Error: {ex.Message}");
                return await MessageService.ReturnError(new GetCustomerByDocumentResponse(),
                                                        "Uexpected Error",
                                                        StatusCodes.Status500InternalServerError,
                                                        cancellationToken);
            }
        }
    }
}
