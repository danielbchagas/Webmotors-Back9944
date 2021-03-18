using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Webmotors.Back9944.Interfaces.Services;
using Webmotors.Back9944.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Text.Json;

namespace Webmotors.Back9944.Services {
    public class WebmotorsService : IWebmotorsService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;
        private readonly string _resource;

        public WebmotorsService(HttpClient http, IConfiguration configuration){
            _http = http;
            _configuration = configuration;

            _http.BaseAddress = new Uri(_configuration.GetSection("WebServiceBase").ToString());
            _resource = _configuration.GetSection("WebServiceReource").ToString();
        }

        public async Task<IEnumerable<VehicleMaker>> GetMakers()
        {
            HttpResponseMessage response = await _http.GetAsync(_resource);
            
            string content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<VehicleMaker>>(content);
        }

        public async Task<IEnumerable<VehicleModel>> GetModels(int makerId)
        {
            HttpResponseMessage response = await _http.GetAsync(_resource);
            
            string content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<VehicleModel>>(content);
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles(int pageIndex)
        {
            HttpResponseMessage response = await _http.GetAsync(_resource);

            string content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<Vehicle>>(content);
        }

        public async Task<IEnumerable<VehicleVersion>> GetVersions(int modelId)
        {
            HttpResponseMessage response = await _http.GetAsync(_resource);

            string content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<VehicleVersion>>(content);
        }

        private void Success(HttpResponseMessage response){
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Criar validação
            }
        }
    }
}