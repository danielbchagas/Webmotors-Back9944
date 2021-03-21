using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Models;
using Xunit;
using Version = Webmotors.Back9944.Business.Models.Version;

namespace Webmotors.Back9944.App.Tests
{
    public class App_ServicesController : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _http;

        public App_ServicesController(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("Services/makers")]
        public async Task Get_EndpointsReturnMakers(string url)
        {
            // Arrange
            _http = _factory.CreateClient();
            HttpResponseMessage response = await _http.GetAsync(url);

            // Act
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<Maker> result = JsonSerializer.Deserialize<IEnumerable<Maker>>(content, SerializeOptions());

            // Assert
            Assert.True(result.Count() > 0);
            Assert.True(result.Where(_ => _.Id == 0 || _.Name == null).Count() == 0);
        }

        [Theory]
        [InlineData("Services/Models/1")]
        [InlineData("Services/Models/2")]
        [InlineData("Services/Models/3")]
        public async Task Get_EndpointsReturnModels(string url)
        {
            // Arrange
            _http = _factory.CreateClient();
            HttpResponseMessage response = await _http.GetAsync(url);

            // Act
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<Model> result = JsonSerializer.Deserialize<IEnumerable<Model>>(content, SerializeOptions());

            // Assert
            Assert.True(result.Count() > 0);
            Assert.True(result.Where(_ => _.Id == 0 || _.Name == null || _.MakeId ==0).Count() == 0);
        }

        [Theory]
        [InlineData("Services/Vehicles/1")]
        [InlineData("Services/Vehicles/2")]
        [InlineData("Services/Vehicles/3")]
        public async Task Get_EndpointsReturnVehicles(string url)
        {
            // Arrange
            _http = _factory.CreateClient();
            HttpResponseMessage response = await _http.GetAsync(url);

            // Act
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<Vehicle> result = JsonSerializer.Deserialize<IEnumerable<Vehicle>>(content, SerializeOptions());

            // Assert
            Assert.True(result.Count() > 0);
        }

        [Theory]
        [InlineData("Services/Versions/1")]
        [InlineData("Services/Versions/2")]
        [InlineData("Services/Versions/3")]
        public async Task Get_EndpointsReturnVersions(string url)
        {
            // Arrange
            _http = _factory.CreateClient();
            HttpResponseMessage response = await _http.GetAsync(url);

            // Act
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<Version> result = JsonSerializer.Deserialize<IEnumerable<Version>>(content, SerializeOptions());

            // Assert
            Assert.True(result.Count() > 0);
            Assert.True(result.Where(_ => _.Id == 0 || _.Name == null || _.ModelID == 0).Count() == 0);
        }

        private JsonSerializerOptions SerializeOptions()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            return options;
        }
    }
}
