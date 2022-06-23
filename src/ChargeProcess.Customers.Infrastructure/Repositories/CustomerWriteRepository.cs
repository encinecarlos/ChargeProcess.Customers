using ChargeProcess.Customers.Domain.Entity;
using ChargeProcess.Customers.Domain.Repositories;
using ChargeProcess.Customers.Infrastructure.Cosmos;

namespace ChargeProcess.Customers.Infrastructure.Repositories
{
    public class CustomerWriteRepository : ICustomerWriteRepository
    {
        private CustomerContext CustomerContext { get; }

        public CustomerWriteRepository(CustomerContext customerContext)
        {
            CustomerContext = customerContext;
        }

        public async Task<string> Save(Customer customer)
        {
            CustomerContext.Customers.Add(customer);

            CustomerContext.SaveChanges();

            return customer.Id;
        }
    }
}
