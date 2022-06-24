using ChargeProcess.Customers.Application.Commands.Customers;
using ChargeProcess.Customers.Application.Queries.GetCustomerBydocument;
using ChargeProcess.Customers.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChargeProcess.Customers.Crosscutting.DependencyInjection
{
    public static class UtilsServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMessageService<CustomerResponse>, MessageService<CustomerResponse>>();
            services.AddScoped<IMessageService<GetCustomerBydocumentResponse>, MessageService<GetCustomerBydocumentResponse>>();
            
            return services;
        }
    }
}
