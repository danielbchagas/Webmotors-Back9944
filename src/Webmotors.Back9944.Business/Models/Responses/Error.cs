using System.Net;

namespace Webmotors.Back9944.Business.Models.Responses
{
    public class Error
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
