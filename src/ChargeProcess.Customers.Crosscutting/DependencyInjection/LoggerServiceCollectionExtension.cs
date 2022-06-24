using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Filters;

namespace ChargeProcess.Customers.Crosscutting.DependencyInjection
{
    public static class LoggerServiceCollectionExtension
    {
        public static void AddLogger(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Debug)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", $"ChargeProcess.Customers - {Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}")
                .Filter.ByExcluding(Matching.FromSource("Microsoft.AspNetCore.StaticFiles"))
                .Filter.ByExcluding(z => z.MessageTemplate.Text.Contains("Business error"))
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u4}] {Message:lj} {Proeprties:j}{NewLine}{Exception}")
                .CreateLogger();
        }
    }
}
