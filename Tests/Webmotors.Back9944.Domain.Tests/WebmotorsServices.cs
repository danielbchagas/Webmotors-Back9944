using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Interfaces.Services;
using Webmotors.Back9944.Domain.Tests.Factories;
using Xunit;

namespace Webmotors.Back9944.App.Tests
{
    public class WebmotorsServices : IClassFixture<DomainFactory<Startup>>
    {
        private readonly DomainFactory<Startup> _factory;
        private readonly IWebmotorsService _service;

        public WebmotorsServices(DomainFactory<Startup> factory)
        {
            _factory = factory;
            _service = _factory.Services.GetRequiredService<IWebmotorsService>();
        }

        [Fact]
        public async Task Get_EndpointReturnMakers()
        {
            // Arrange

            // Act
            var response = await _service.GetMakers();

            // Assert
            Assert.True(response.Count() > 0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task Get_EndpointReturnModels(int id)
        {
            // Arrange

            // Act
            var response = await _service.GetModels(id);

            // Assert
            Assert.True(response.Count() > 0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task Get_EndpointReturnVehicles(int id)
        {
            // Arrange

            // Act
            var response = await _service.GetVehicles(id);

            // Assert
            Assert.True(response.Count() > 0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task Get_EndpointReturnVersions(int id)
        {
            // Arrange

            // Act
            var response = await _service.GetVersions(id);

            // Assert
            Assert.True(response.Count() > 0);
        }
    }
}
