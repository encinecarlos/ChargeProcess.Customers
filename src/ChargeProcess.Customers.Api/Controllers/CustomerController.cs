using ChargeProcess.Customers.Application.Commands.Customers;
using ChargeProcess.Customers.Application.Queries.GetCustomerBydocument;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ChargeProcess.Customers.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CustomerController : ControllerBase
    {
        private IMediator Mediator {get; set; }

        public CustomerController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerResponse>> SaveCustomer([FromBody] CustomerRequest request, CancellationToken cancellationToken)
        {
            Log.Information("Send request to handler");
            var response = await Mediator.Send(request, cancellationToken);

            return response;
        }

        [HttpGet("{documentId}")]
        [ProducesResponseType(typeof(GetCustomerBydocumentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GetCustomerBydocumentResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(GetCustomerBydocumentResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetCustomerBydocumentResponse>> GetCustomerbydocument([FromRoute] string documentId, CancellationToken cancellationToken)
        {
            var request = new GetCustomerByDocumentRequest
            {
                DocumentId = documentId,
            };

            var response = await Mediator.Send(request, cancellationToken);

            return response;
        }
    }
}
