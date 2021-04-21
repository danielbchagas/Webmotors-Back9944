using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Webmotors.Back9944.App.Tests.Factories;
using Webmotors.Back9944.App.Tests.Fixtures;
using Webmotors.Back9944.Business.Models;
using Xunit;

namespace Webmotors.Back9944.App.Tests
{
    [Collection(nameof(AdvertisingCollection))]
    public class AdvertisingController : IClassFixture<AppFactory<Startup>>
    {
        private readonly AdvertisingFixture _advertisingFixture;
        private readonly AppFactory<Startup> _factory;
        private readonly HttpClient _http;
        
        public AdvertisingController(AppFactory<Startup> factory, AdvertisingFixture advertisingFixture)
        {
            _advertisingFixture = advertisingFixture;
            _factory = factory;
            _http = _factory.CreateClient();
        }

        [Fact]
        public async Task Post_EndpointReturnBadRequest()
        {
            // Arrange
            var advertising = _advertisingFixture.GetInvalidAdvertising();
            var stringContent = GetStringContent(advertising);

            // Act
            var response = await _http.PostAsync("Advertising/Create", stringContent);

            // Assert
            Assert.True((int)response.StatusCode == StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task Put_EndpointReturnBadRequest()
        {
            // Arrange
            var advertising = _advertisingFixture.GetInvalidAdvertising();
            var stringContent = GetStringContent(advertising);

            // Act
            HttpResponseMessage response = await _http.PutAsync("Advertising/Update", stringContent);

            // Assert
            Assert.True((int)response.StatusCode == StatusCodes.Status400BadRequest);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-200)]
        public async Task Delete_EndpointReturnInternalServerError(int id)
        {
            // Arrange

            // Act
            HttpResponseMessage response = await _http.DeleteAsync($"Advertising/Delete/{id}");

            // Assert
            Assert.True((int)response.StatusCode == StatusCodes.Status500InternalServerError);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-200)]
        public async Task Get_EndpointReturnInternalServerError(int id)
        {
            // Arrange

            // Act
            HttpResponseMessage response = await _http.GetAsync($"Advertising/Get/{id}");

            // Assert
            Assert.True((int)response.StatusCode == StatusCodes.Status500InternalServerError);
        }

        private StringContent GetStringContent(Advertising advertising)
        {
            string json = JsonSerializer.Serialize(advertising);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
