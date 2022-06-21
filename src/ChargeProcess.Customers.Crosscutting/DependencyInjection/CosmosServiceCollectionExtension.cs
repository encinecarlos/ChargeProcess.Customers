using ChargeProcess.Customers.Infrastructure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChargeProcess.Customers.Crosscutting.DependencyInjection
{
    public static class CosmosServiceCollectionExtension
    {
        public static IServiceCollection AddCosmos(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection("DatabaseSettings");

            services.AddDbContext<CustomerContext>(ctx => 
                ctx.UseCosmos(config["Connection"], config["accountKey"], config["DatabaseId"])
            );

            return services;
            

        }
    }
}
