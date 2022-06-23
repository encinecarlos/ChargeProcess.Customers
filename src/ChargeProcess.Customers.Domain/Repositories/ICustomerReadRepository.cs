using ChargeProcess.Customers.Domain.Entity;
using ChargeProcess.Customers.Domain.ValueObjects;

namespace ChargeProcess.Customers.Domain.Repositories
{
    public interface ICustomerReadRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers(CustomerFilters? filters);
        Task<Customer> GetCustomerByDocument(string documentId);
    }
}
