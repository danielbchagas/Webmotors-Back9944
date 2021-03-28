using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
                await _service.Create(advertising);
                var errors = _service.GetErrors();

                if (errors.Count() > 0)
                    return BadRequest(errors);

                return Ok();
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
                await _service.Update(advertising);
                var errors = _service.GetErrors();

                if (errors.Count() > 0)
                    return BadRequest(errors);

                return Ok();
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
                var result = await _service.Get(id);
                await _service.Delete(result);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
