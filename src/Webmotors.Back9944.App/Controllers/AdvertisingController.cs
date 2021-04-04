using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.Back9944.App.ViewModels;
using Webmotors.Back9944.Business.Interfaces.Services;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdvertisingController : ControllerBase
    {
        private readonly IAdvertisingService _service;
        private readonly IWebmotorsService _webmotorsService;

        public AdvertisingController(IAdvertisingService service, IWebmotorsService webmotorsService)
        {
            _service = service;
            _webmotorsService = webmotorsService;
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
            catch (Exception e)
            {
                return Problem(e.Message);
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
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Post(AdvertisingViewModel advertising)
        {
            try
            {
                await _service.Create(await FromIdToName(advertising));

                return Created(nameof(Get), advertising.Id);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put(Advertising advertising)
        {
            try
            {
                await _service.Update(advertising);

                return Ok();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var advertising = await _service.Get(id);

                await _service.Delete(advertising);

                return NoContent();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        #region
        private async Task<Advertising> FromIdToName(AdvertisingViewModel advertisingVm)
        {
            var advertising = new Advertising();

            advertising.Id = advertisingVm.Id;
            advertising.Marca = await FromMakers(advertisingVm.Marca);
            advertising.Modelo = await FromModels(advertisingVm.Marca, advertisingVm.Modelo);
            advertising.Versao = await FromVersions(advertisingVm.Modelo, advertisingVm.Versao);
            advertising.Observacao = advertisingVm.Observacao;
            advertising.Ano = advertisingVm.Ano;
            advertising.Quilometragem = advertisingVm.Quilometragem;

            return advertising;
        }

        private async Task<string> FromMakers(int id)
        {
            var result = (await _webmotorsService.GetMakers()).FirstOrDefault(_ => _.Id == id);

            return result.Name;
        }

        private async Task<string> FromModels(int makerId, int modelId)
        {
            var result = (await _webmotorsService.GetModels(makerId)).FirstOrDefault(_ => _.Id == modelId);

            return result.Name;
        }

        private async Task<string> FromVersions(int modelId, int versionId)
        {
            var result = (await _webmotorsService.GetVersions(modelId)).FirstOrDefault(_ => _.Id == versionId);

            return result.Name;
        }
        #endregion
    }
}
