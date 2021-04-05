using Microsoft.AspNetCore.Hosting;

namespace Webmotors.Back9944.App.Tests
{
    public class WebApplicationFactory<TStartUp> : Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<TStartUp> where TStartUp : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseStartup<TStartUp>();
            
            base.ConfigureWebHost(builder);
        }
    }
}
