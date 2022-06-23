using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeProcess.Customers.Domain.ValueObjects
{
    public class CustomerFilters
    {
        public string Name { get; set; }
        public string Province { get; set; }
        public string DocumentId { get; set; }
    }
}
