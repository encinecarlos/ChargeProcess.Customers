using ChargeProcess.Customers.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeProcess.Customers.Application.Commands.Customers
{
    public class CustomerAdapter
    {
        public Customer Adapt(CustomerRequest customer)
        {
            return new Customer
            {
                Id = Guid.NewGuid().ToString(),
                DocumentId = customer.DocumentId,
                Name = customer.Name,
                Province = customer.Province,
                LeadByZero = customer.DocumentId.StartsWith("0") ? true : false,
            };
        }
    }
}
