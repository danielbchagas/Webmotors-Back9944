using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                var makers = await _service.GetMakers();
                return Ok(makers);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("Models/{makerId:int}")]
        public async Task<IActionResult> Models(int makerId)
        {
            try
            {
                var models = await _service.GetModels(makerId);
                return Ok(models);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("Versions/{modelId:int}")]
        public async Task<IActionResult> Versions(int modelId)
        {
            try
            {
                var versions = await _service.GetVersions(modelId);
                return Ok(versions);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("Vehicles/{pageIndex:int}")]
        public async Task<IActionResult> Vehicles(int pageIndex)
        {
            try
            {
                var versions = await _service.GetVehicles(pageIndex);
                return Ok(versions);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
