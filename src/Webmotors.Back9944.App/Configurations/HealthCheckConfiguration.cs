using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Webmotors.Back9944.App.Configurations
{
    public static class HealthCheckConfiguration
    {
        public static IServiceCollection AddHealthCheckConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks();

            return services;
        }
    }
}
