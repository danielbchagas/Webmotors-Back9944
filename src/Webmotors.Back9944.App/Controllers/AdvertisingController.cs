using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Interfaces.Services;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdvertisingController : ControllerBase
    {
        private readonly IAdvertisingService _service;

        public AdvertisingController(IAdvertisingService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _service.Get();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("Get/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _service.Get(id);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Post(Advertising advertising)
        {
            try
            {
                var result = await _service.Create(advertising);

                return result == true ? Ok() : BadRequest(_service.GetErrors());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put(Advertising advertising)
        {
            try
            {
                var result = await _service.Update(advertising);

                return result == true ? Ok() : BadRequest(_service.GetErrors());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var advertising = await _service.Get(id);

                var result = await _service.Delete(advertising);

                return result == true ? NoContent() : BadRequest(_service.GetErrors());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
