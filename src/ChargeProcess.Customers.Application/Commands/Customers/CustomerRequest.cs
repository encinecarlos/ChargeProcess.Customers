using ChargeProcess.Customers.Domain.Entity;
using MediatR;

namespace ChargeProcess.Customers.Application.Commands.Customers
{
    public class CustomerRequest : IRequest<CustomerResponse>
    {
        public string Name { get; set; }

        public string Province { get; set; }

        public string DocumentId { get; set; }
    }
}
