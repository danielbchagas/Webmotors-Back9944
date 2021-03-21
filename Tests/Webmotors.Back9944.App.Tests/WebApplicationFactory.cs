using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webmotors.Back9944.App.Tests
{
    public class WebApplicationFactory<TStartUp> : Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory<TStartUp> where TStartUp : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseStartup<TStartUp>();
            builder.UseEnvironment("Testing");

            base.ConfigureWebHost(builder);
        }
    }
}
