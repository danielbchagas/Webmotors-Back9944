using Microsoft.Extensions.DependencyInjection;
using Webmotors.Back9944.Business.Interfaces.Repositories;
using Webmotors.Back9944.Business.Interfaces.Services;
using Webmotors.Back9944.Business.Repositories;
using Webmotors.Back9944.Business.Services;
using Webmotors.Back9944.Data.Repositories;

namespace Webmotors.Back9944.App.Configurations
{
    public static class DependencyInjectionConfiguration {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services){
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IAdvertisingRepository, AdvertisingRepository>();
            services.AddScoped<IAdvertisingService, AdvertisingService>();
            
            services.AddHttpClient<IWebmotorsService, WebmotorsService>();
            
            return services;
        }
    }
}