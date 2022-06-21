using Microsoft.Extensions.Configuration;
using Serilog;

namespace ChargeProcess.Customers.Crosscutting.DependencyInjection
{
    public static class LoggerServiceCollectionExtension
    {
        public static void AddLogger(this IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
