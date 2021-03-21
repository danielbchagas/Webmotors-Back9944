using Microsoft.AspNetCore.Mvc;
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
            var result = await _service.Get();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.Get(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Post(Advertising advertising)
        {
            await _service.Create(advertising);
            var errors = _service.GetErrors();

            if (errors.Count() > 0)
                return BadRequest(errors);

            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put(Advertising advertising)
        {
            await _service.Update(advertising);
            var errors = _service.GetErrors();

            if (errors.Count() > 0)
                return BadRequest(errors);

            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Get(id);
            await _service.Delete(result);

            return NoContent();
        }
    }
}
