using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webmotors.Back9944.Interfaces.Services;

namespace Webmotors.Back9944.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IWebmotorsService _service;

        public ServicesController(IWebmotorsService service)
        {
            _service = service;
        }

        [HttpGet("/Makers")]
        public async Task<IActionResult> Makers()
        {
            var makers = await _service.GetMakers();
            return Ok(makers);
        }

        [HttpGet("/Models/{makerId:int}")]
        public async Task<IActionResult> Models(int makerId)
        {
            var models = await _service.GetModels(makerId);
            return Ok(models);
        }

        [HttpGet("/Versions/{modelId:int}")]
        public async Task<IActionResult> Versions(int modelId)
        {
            var versions = await _service.GetVersions(modelId);
            return Ok(versions);
        }

        [HttpGet("/Vehicles/{pageIndex:int}")]
        public async Task<IActionResult> Vehicles(int pageIndex)
        {
            var versions = await _service.GetVehicles(pageIndex);
            return Ok(versions);
        }
    }
}
