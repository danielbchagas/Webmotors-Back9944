using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Webmotors.Back9944.App.Tests.Factories;
using Webmotors.Back9944.Business.DTOs;
using Xunit;

namespace Webmotors.Back9944.App.Tests
{
    public class App_ServicesController : IClassFixture<AppFactory<Startup>>
    {
        private readonly AppFactory<Startup> _factory;
        private readonly HttpClient _http;
        
        public App_ServicesController(AppFactory<Startup> factory)
        {
            _factory = factory;
            _http = _factory.CreateClient();
            _http.BaseAddress = new Uri("http://desafioonline.webmotors.com.br/api/OnlineChallenge/");
        }

        [Theory]
        [InlineData("Make")]
        public async Task Get_EndpointReturnMakers(string url)
        {
            // Arrange
            HttpResponseMessage response = await _http.GetAsync(url);

            // Act
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<MakerDTO> result = JsonSerializer.Deserialize<IEnumerable<MakerDTO>>(content, SerializeOptions());

            // Assert
            Assert.True(result.Count() > 0);
            Assert.True(result.Where(_ => _.Id == 0 || _.Name == null).Count() == 0);
        }

        [Theory]
        [InlineData("Model?MakeID=1")]
        [InlineData("Model?MakeID=2")]
        [InlineData("Model?MakeID=3")]
        public async Task Get_EndpointReturnModels(string url)
        {
            // Arrange
            HttpResponseMessage response = await _http.GetAsync(url);

            // Act
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<ModelDTO> result = JsonSerializer.Deserialize<IEnumerable<ModelDTO>>(content, SerializeOptions());

            // Assert
            Assert.True(result.Count() > 0);
            Assert.True(result.Where(_ => _.Id == 0 || _.Name == null || _.MakeId ==0).Count() == 0);
        }

        [Theory]
        [InlineData("Vehicles?Page=1")]
        [InlineData("Vehicles?Page=2")]
        [InlineData("Vehicles?Page=3")]
        public async Task Get_EndpointReturnVehicles(string url)
        {
            // Arrange
            HttpResponseMessage response = await _http.GetAsync(url);

            // Act
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<VehicleDTO> result = JsonSerializer.Deserialize<IEnumerable<VehicleDTO>>(content, SerializeOptions());

            // Assert
            Assert.True(result.Count() > 0);
        }

        [Theory]
        [InlineData("Version?ModelID=1")]
        [InlineData("Version?ModelID=2")]
        [InlineData("Version?ModelID=3")]
        public async Task Get_EndpointReturnVersions(string url)
        {
            // Arrange
            HttpResponseMessage response = await _http.GetAsync(url);

            // Act
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<VersionDTO> result = JsonSerializer.Deserialize<IEnumerable<VersionDTO>>(content, SerializeOptions());

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
