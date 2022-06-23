using ChargeProcess.Customers.Domain.Entity;
using ChargeProcess.Customers.Domain.Repositories;
using ChargeProcess.Customers.Domain.ValueObjects;
using ChargeProcess.Customers.Infrastructure.Common;
using ChargeProcess.Customers.Infrastructure.Cosmos;
using Microsoft.EntityFrameworkCore;

namespace ChargeProcess.Customers.Infrastructure.Repositories
{
    public class CustomerReadRepository : ICustomerReadRepository
    {
        private CustomerContext CustomerContext { get; }

        public CustomerReadRepository(CustomerContext customerContext)
        {
            CustomerContext = customerContext;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers(CustomerFilters? filters)
        {
            return await CustomerContext.Customers.Select(x => new Customer
            {
                Id = x.Id,
                DocumentId = x.DocumentId,
                Name = x.Name,
                Province = x.Province
            }).ToListAsync();

            
        }

        public async Task<Customer> GetCustomerByDocument(string documentId)
        {
            return await CustomerContext.Customers.Where(x => x.DocumentId.Equals(documentId.ConvertDocumentToNumber())).FirstOrDefaultAsync();
        }
    }
}
