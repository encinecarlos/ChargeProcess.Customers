using ChargeProcess.Customers.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ChargeProcess.Customers.Crosscutting.DependencyInjection
{
    public static class RepositoriesServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICustomerWriteRepository, CustomerWriteRepository>();

            return services;
        }
    }
}
