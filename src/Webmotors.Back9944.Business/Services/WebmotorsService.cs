using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.DTOs;
using Webmotors.Back9944.Business.Interfaces.Services;
using Webmotors.Back9944.Business.Options;

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

        public async Task<IEnumerable<MakerDTO>> GetMakers()
        {
            HttpResponseMessage response = await _http.GetAsync(_options.Make);

            return await Response<MakerDTO>(response);
        }

        public async Task<IEnumerable<ModelDTO>> GetModels(int makerId)
        {
            HttpResponseMessage response = await _http.GetAsync(_options.Model + makerId);

            return await Response<ModelDTO>(response);
        }

        public async Task<IEnumerable<VehicleDTO>> GetVehicles(int pageIndex)
        {
            HttpResponseMessage response = await _http.GetAsync(_options.Vehicle + pageIndex);

            return await Response<VehicleDTO>(response);
        }

        public async Task<IEnumerable<VersionDTO>> GetVersions(int modelId)
        {
            HttpResponseMessage response = await _http.GetAsync(_options.Version + modelId);

            return await Response<VersionDTO>(response);
        }

        private JsonSerializerOptions SerializeOptions()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            return options;
        }

        private async Task<IEnumerable<T>> Response<T>(HttpResponseMessage response) where T : class
        {
            try
            {
                string content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw FormattedException(response);

                return JsonSerializer.Deserialize<IEnumerable<T>>(content, SerializeOptions());
            }
            catch (HttpRequestException e)
            {
                throw FormattedException(response, e);
            }
        }

        private HttpRequestException FormattedException(HttpResponseMessage response, HttpRequestException e = null)
        {
            return new HttpRequestException(message: response.ReasonPhrase, inner: e, statusCode: response.StatusCode);
        }
    }
}