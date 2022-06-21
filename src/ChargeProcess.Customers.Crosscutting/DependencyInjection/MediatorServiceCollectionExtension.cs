using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ChargeProcess.Customers.Crosscutting.DependencyInjection
{
    public static class MediatorServiceCollectionExtension
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("ChargeProcess.Customers.Application");

            services.AddMediatR(assembly);

            return services;
        }
    }
}
