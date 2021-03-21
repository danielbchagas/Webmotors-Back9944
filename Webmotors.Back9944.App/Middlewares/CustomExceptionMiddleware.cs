using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Webmotors.Back9944.App.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext http)
        {
            try
            {
                await _next(http);
            }
            catch (Exception e)
            {
                await http.Response.WriteAsJsonAsync($"Houve um problema com a requisição! Detalhes: {e.Message}");
                _logger.LogError(e, $"Exceção gerada em: {DateTime.Now}", e.Message);
            }
        }
    }
}
