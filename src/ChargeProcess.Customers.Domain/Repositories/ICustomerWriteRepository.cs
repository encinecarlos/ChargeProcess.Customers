using ChargeProcess.Customers.Domain.Entity;

namespace ChargeProcess.Customers.Domain.Repositories
{
    public interface ICustomerWriteRepository
    {
        Task<string> Save(Customer customer);
    }
}
