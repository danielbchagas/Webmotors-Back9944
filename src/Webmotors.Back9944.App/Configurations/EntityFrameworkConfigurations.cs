using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Webmotors.Back9944.Data.Contexts;

namespace Webmotors.Back9944.App.Configurations
{
    public static class EntityFrameworkConfigurations
    {
        public static IServiceCollection AddEntityFrameworkConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(configuration.GetConnectionString("teste_webmotors"), sqlServerOptionsAction: options => {
                    options.EnableRetryOnFailure(maxRetryCount: 6, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null);
                });
            });

            return services;
        }
    }
}
