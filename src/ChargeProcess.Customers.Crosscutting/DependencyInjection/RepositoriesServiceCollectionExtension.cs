using ChargeProcess.Customers.Domain.Repositories;
using ChargeProcess.Customers.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ChargeProcess.Customers.Crosscutting.DependencyInjection
{
    public static class RepositoriesServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();

            return services;
        }
    }
}
