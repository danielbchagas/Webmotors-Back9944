using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Models;
using Xunit;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace Webmotors.Back9944.App.Tests
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient _http;

        public UnitTest1(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("Services/makers")]
        public async Task Test1(string url)
        {
            // Arrange
            _http = _factory.CreateClient();
            HttpResponseMessage response = await _http.GetAsync(url);

            // Act
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<Maker> result = JsonSerializer.Deserialize<IEnumerable<Maker>>(content, SerializeOptions());

            // Assert
            Assert.True(result.Count() > 0);
        }

        [Theory]
        [InlineData("Services/Models/1")]
        [InlineData("Services/Versions/1")]
        [InlineData("Services/Vehicles/1")]
        public async Task Test2(string url)
        {
            // Arrange
            _http = _factory.CreateClient();
            HttpResponseMessage response = await _http.GetAsync(url);

            // Act
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<Model> result = JsonSerializer.Deserialize<IEnumerable<Model>>(content, SerializeOptions());

            // Assert
            Assert.True(result.Count() > 0);
        }

        private JsonSerializerOptions SerializeOptions()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            return options;
        }
    }
}
