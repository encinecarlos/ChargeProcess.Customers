using ChargeProcess.Customers.Domain.Entity;
using ChargeProcess.Customers.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChargeProcess.Customers.Application.Commands.Customers
{
    public class CustomerAdapter : DataConversion
    {
        public Customer Adapt(CustomerRequest customer)
        {
            return new Customer
            {
                Id = Guid.NewGuid().ToString(),
                DocumentId = customer.DocumentId.ConvertDocumentToNumber(),
                Name = customer.Name,
                Province = customer.Province,
                LeadByZero = customer.DocumentId.StartsWith("0") ? true : false,
            };
        }
    }
}
