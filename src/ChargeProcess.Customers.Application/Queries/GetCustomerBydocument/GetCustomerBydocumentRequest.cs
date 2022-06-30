using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeProcess.Customers.Application.Queries.GetCustomerBydocument
{
    public class GetCustomerByDocumentRequest : IRequest<GetCustomerByDocumentResponse>
    {
        public string DocumentId { get; set; }
    }
}
