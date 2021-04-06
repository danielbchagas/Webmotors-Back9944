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

        [Theory]
        [InlineData(-1, null, null, null, null, 1949)]
        [InlineData(-10, "", null, "", null, 1500)]
        [InlineData(-90, null, "", null, null, 1900)]
        public async Task Post_EndpointReturnBadRequest(int id, string marca, string modelo, string observacao, string versao, int date)
        {
            // Arrange
            var advertising = new Advertising
            {
                Id = id,
                Marca = marca,
                Modelo = modelo,
                Observacao = observacao,
                Versao = versao,
                Ano = date
            };

            var json = JsonSerializer.Serialize(advertising);

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _http.PostAsync("Advertising/Create", stringContent);
            
            // Assert
            Assert.True((int)response.StatusCode == StatusCodes.Status400BadRequest);
        }

        [Theory]
        [InlineData(-1, null, null, null, null, 1949)]
        [InlineData(-10, "", null, "", null, 1500)]
        [InlineData(-90, null, "", null, null, 1900)]
        public async Task Put_EndpointReturnBadRequest(int id, string marca, string modelo, string observacao, string versao, int date)
        {
            // Arrange
            var advertising = new Advertising
            {
                Id = id,
                Marca = marca,
                Modelo = modelo,
                Observacao = observacao,
                Versao = versao,
                Ano = date
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
        public async Task Delete_EndpointReturnInternalServerError(string url)
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
        public async Task Get_EndpointReturnInternalServerError(string url)
        {
            // Arrange

            // Act
            HttpResponseMessage response = await _http.GetAsync(url);

            // Assert
            Assert.True((int)response.StatusCode == StatusCodes.Status500InternalServerError);
        }
    }
}
