using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Interfaces.Repositories;
using Xunit;

namespace Webmotors.Back9944.App.Tests
{
    public class Data_AdvertisingRepository : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly IAdvertisingRepository _repository;

        public Data_AdvertisingRepository(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;

            var newScope = _factory.Services.CreateScope();
            
            _repository = newScope.ServiceProvider.GetRequiredService<IAdvertisingRepository>();
        }

        [Fact]
        public async Task Get()
        {
            // Arrange

            // Act
            var result = await _repository.Get();

            // Assert
            Assert.True(result.Count() > 0);
        }
    }
}
