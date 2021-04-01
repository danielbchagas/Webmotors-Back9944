using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Interfaces.Services;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Services
{
    public class WebmotorsService : IWebmotorsService
    {
        private readonly HttpClient _http;
        private readonly WebServiceOptions _options;
        
        public WebmotorsService(HttpClient http, IOptions<WebServiceOptions> options)
        {
            _http = http;
            _options = options.Value;

            _http.BaseAddress = new Uri(_options.Base);
        }

        public async Task<IEnumerable<WmMaker>> GetMakers()
        {
            HttpResponseMessage response = await _http.GetAsync(_options.Make);

            string content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<WmMaker>>(content, SerializeOptions());
        }

        public async Task<IEnumerable<WmModel>> GetModels(int makerId)
        {
            HttpResponseMessage response = await _http.GetAsync(_options.Model + makerId);

            if (response.StatusCode != HttpStatusCode.OK)
                return new List<WmModel>();

            string content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<WmModel>>(content, SerializeOptions());
        }

        public async Task<IEnumerable<WmVehicle>> GetVehicles(int pageIndex)
        {
            HttpResponseMessage response = await _http.GetAsync(_options.Vehicle + pageIndex);

            if (response.StatusCode != HttpStatusCode.OK)
                return new List<WmVehicle>();

            string content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<WmVehicle>>(content, SerializeOptions());
        }

        public async Task<IEnumerable<WmVersion>> GetVersions(int modelId)
        {
            HttpResponseMessage response = await _http.GetAsync(_options.Version + modelId);

            if (response.StatusCode != HttpStatusCode.OK)
                return new List<WmVersion>();

            string content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<WmVersion>>(content, SerializeOptions());
        }

        private JsonSerializerOptions SerializeOptions()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            return options;
        }
    }
}