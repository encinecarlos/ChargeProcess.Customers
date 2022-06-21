using ChargeProcess.Customers.Domain.Entity;

namespace ChargeProcess.Customers.Infrastructure.Repositories
{
    public interface ICustomerWriteRepository
    {
        Task<string> Save(Customer customer);
    }
}
