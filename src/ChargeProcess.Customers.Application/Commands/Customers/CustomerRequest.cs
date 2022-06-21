using ChargeProcess.Customers.Domain.Entity;
using MediatR;

namespace ChargeProcess.Customers.Application.Commands.Customers
{
    public class CustomerRequest : IRequest<CustomerResponse>
    {
        public Customer? Customer { get; set; }
    }
}
