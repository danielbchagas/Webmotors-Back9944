using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
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
                Id = 1,
                Marca = null,
                Modelo = null,
                Observacao = null,
                Versao = null
            };

            string json = JsonSerializer.Serialize(advertising);

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await _http.PostAsync("Advertising/Create", stringContent);
            IEnumerable<string> errors = await GetErrors(response);

            // Assert
            Assert.True((int)response.StatusCode == StatusCodes.Status400BadRequest);
            Assert.True(errors.Count() > 0);
            Assert.True(errors.Where(e => e.Contains("Id")).Count() > 0);
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
            IEnumerable<string> errors = await GetErrors(response);

            // Assert
            Assert.True((int)response.StatusCode == StatusCodes.Status400BadRequest);
            Assert.True(errors.Count() > 0);
            Assert.True(errors.Where(e => e.Contains("Id")).Count() > 0);
        }

        private JsonSerializerOptions SerializeOptions()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            return options;
        }

        private async Task<IEnumerable<string>> GetErrors(HttpResponseMessage response)
        {
            string content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<string>>(content, SerializeOptions());
        }
    }
}
