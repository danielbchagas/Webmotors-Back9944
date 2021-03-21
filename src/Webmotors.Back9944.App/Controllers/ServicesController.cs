using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Interfaces.Services;

namespace Webmotors.Back9944.App.Controllers
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

        [HttpGet]
        [Route("Makers")]
        public async Task<IActionResult> Makers()
        {
            var makers = await _service.GetMakers();
            return Ok(makers);
        }

        [HttpGet]
        [Route("Models/{makerId:int}")]
        public async Task<IActionResult> Models(int makerId)
        {
            var models = await _service.GetModels(makerId);
            return Ok(models);
        }

        [HttpGet]
        [Route("Versions/{modelId:int}")]
        public async Task<IActionResult> Versions(int modelId)
        {
            var versions = await _service.GetVersions(modelId);
            return Ok(versions);
        }

        [HttpGet]
        [Route("Vehicles/{pageIndex:int}")]
        public async Task<IActionResult> Vehicles(int pageIndex)
        {
            var versions = await _service.GetVehicles(pageIndex);
            return Ok(versions);
        }
    }
}
