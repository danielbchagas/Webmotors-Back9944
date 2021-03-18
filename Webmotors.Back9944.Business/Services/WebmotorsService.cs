using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Interfaces.Services;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Services
{
    public class WebmotorsService : IWebmotorsService
    {
        private readonly HttpClient _http;
        private readonly WebServiceOptions _options;

        public WebmotorsService(HttpClient http, IOptions<WebServiceOptions> options)
        {
            _http = http;
            _options = options.Value;
        }

        public async Task<IEnumerable<Maker>> GetMakers()
        {
            HttpResponseMessage response = await _http.GetAsync(_options.Make);

            string content = await response.Content.ReadAsStringAsync();

            JsonSerializerOptions options = SerializeOptions();
            
            return JsonSerializer.Deserialize<IEnumerable<Maker>>(content, options);
        }

        public async Task<IEnumerable<Model>> GetModels(int makerId)
        {
            HttpResponseMessage response = await _http.GetAsync(_options.Model + makerId);

            string content = await response.Content.ReadAsStringAsync();

            JsonSerializerOptions options = SerializeOptions();

            return JsonSerializer.Deserialize<IEnumerable<Model>>(content, options);
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles(int pageIndex)
        {
            HttpResponseMessage response = await _http.GetAsync(_options.Vehicle + pageIndex);

            string content = await response.Content.ReadAsStringAsync();

            JsonSerializerOptions options = SerializeOptions();

            return JsonSerializer.Deserialize<IEnumerable<Vehicle>>(content, options);
        }

        public async Task<IEnumerable<Version>> GetVersions(int modelId)
        {
            HttpResponseMessage response = await _http.GetAsync(_options.Version + modelId);

            string content = await response.Content.ReadAsStringAsync();

            JsonSerializerOptions options = SerializeOptions();

            return JsonSerializer.Deserialize<IEnumerable<Version>>(content, options);
        }

        private JsonSerializerOptions SerializeOptions()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            return options;
        }
    }
}