using AzureFunctions.HandsOn;
using AzureFunctions.HandsOn.Services;
using AzureFunctions.HandsOn.Services.Interfaces;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace AzureFunctions.HandsOn
{
    /// <summary>
    /// Startup the service to inject dependencies
    /// </summary>
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IBlobService, AzureBlobService>();
        }
    }
}