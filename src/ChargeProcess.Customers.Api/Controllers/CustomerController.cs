using ChargeProcess.Customers.Application.Commands.Customers;
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
        public async Task<ActionResult<CustomerResponse>> SaveCustomer([FromBody] CustomerRequest request, CancellationToken cancellationToken)
        {
            Log.Information("Send request to handler");
            var response = await Mediator.Send(request, cancellationToken);

            return response;
        }
    }
}
