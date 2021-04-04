using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Models;
using Xunit;

namespace Webmotors.Back9944.App.Tests
{
    public class App_AdvertisingController : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _http;

        public App_AdvertisingController(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _http = _factory.CreateClient();
        }

        [Fact]
        public async Task Post_EndpointsCreateAdvertisingErrors()
        {
            // Arrange
            Advertising advertising = new Advertising 
            {
                Id = 0,
                Marca = null,
                Modelo = null,
                Observacao = null,
                Versao = null
            };

            string json = JsonSerializer.Serialize(advertising);

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await _http.PostAsync("Advertising/Create", stringContent);
            
            // Assert
            Assert.True((int)response.StatusCode == StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task Put_EndpointsUpdateAdvertisingErrors()
        {
            // Arrange
            Advertising advertising = new Advertising
            {
                Id = 0,
                Marca = null,
                Modelo = null,
                Observacao = null,
                Versao = null
            };

            string json = JsonSerializer.Serialize(advertising);

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await _http.PutAsync("Advertising/Update", stringContent);
            
            // Assert
            Assert.True((int)response.StatusCode == StatusCodes.Status400BadRequest);
        }

        [Theory]
        [InlineData("Advertising/Delete/-1")]
        [InlineData("Advertising/Delete/-200")]
        public async Task Delete_EndpointsDeleteAdvertisingErrors(string url)
        {
            // Arrange

            // Act
            HttpResponseMessage response = await _http.DeleteAsync(url);
            
            // Assert
            Assert.True((int)response.StatusCode == StatusCodes.Status500InternalServerError);
        }

        [Theory]
        [InlineData("Advertising/Get/-1")]
        [InlineData("Advertising/Get/-200")]
        public async Task Get_EndpointsGetAdvertisingErrors(string url)
        {
            // Arrange

            // Act
            HttpResponseMessage response = await _http.GetAsync(url);

            // Assert
            Assert.True((int)response.StatusCode == StatusCodes.Status500InternalServerError);
        }

        private JsonSerializerOptions SerializeOptions()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            return options;
        }
    }
}
