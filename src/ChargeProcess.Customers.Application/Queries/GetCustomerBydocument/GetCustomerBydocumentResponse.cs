using ChargeProcess.Customers.Application.DataTransferObjects;
using ChargeProcess.Customers.Domain.Common;

namespace ChargeProcess.Customers.Application.Queries.GetCustomerBydocument
{
    public class GetCustomerByDocumentResponse : MessageBase
    {
        public CustomerDto Customer { get; set; }
    }
}
