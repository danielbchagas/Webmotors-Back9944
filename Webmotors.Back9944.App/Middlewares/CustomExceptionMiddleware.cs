using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Webmotors.Back9944.App.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext http)
        {
            try
            {
                await _next(http);
            }
            catch (Exception e)
            {
                await http.Response.WriteAsJsonAsync($"Houve um problema com a requisição! Detalhes: {e.InnerException.Message}");
            }
        }
    }
}
