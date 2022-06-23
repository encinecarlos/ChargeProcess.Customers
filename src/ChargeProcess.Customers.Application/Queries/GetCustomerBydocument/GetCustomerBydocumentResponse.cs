using ChargeProcess.Customers.Application.DataTransferObjects;
using ChargeProcess.Customers.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeProcess.Customers.Application.Queries.GetCustomerBydocument
{
    public class GetCustomerBydocumentResponse : MessageBase
    {
        public CustomerDto Customer { get; set; }
    }
}
