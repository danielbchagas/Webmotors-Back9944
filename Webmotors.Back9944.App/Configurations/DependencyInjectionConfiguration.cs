using Microsoft.Extensions.DependencyInjection;
using Webmotors.Back9944.Business.Interfaces.Repositories;
using Webmotors.Back9944.Business.Interfaces.Services;
using Webmotors.Back9944.Business.Repositories;

using Webmotors.Back9944.Services;

namespace Webmotors.Back9944.Configurations
{
    public static class DependencyInjectionConfiguration {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services){
            services.AddHttpClient<IWebmotorsService, WebmotorsService>();
            services.AddScoped<IAdvertisingRepository, AdvertisingRepository>();
            
            return services;
        }
    }
}