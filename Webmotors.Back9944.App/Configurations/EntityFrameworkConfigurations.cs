using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Webmotors.Back9944.Data.Contexts;

namespace Webmotors.Back9944.Configurations
{
    public static class EntityFrameworkConfigurations
    {
        private static readonly ILoggerFactory EFLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public static IServiceCollection AddEntityFrameworkConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("teste_webmotors");

            services.AddDbContext<ApplicationContext>(optionsAction =>
            {
                optionsAction.UseLoggerFactory(EFLoggerFactory);
                optionsAction.UseSqlServer(configuration.GetConnectionString("teste_webmotors"), sqlServerOptionsAction: options => {
                    options.EnableRetryOnFailure(maxRetryCount: 6, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null);
                });
            });

            return services;
        }
    }
}
