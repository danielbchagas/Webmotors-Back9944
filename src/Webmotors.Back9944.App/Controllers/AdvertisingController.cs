using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        private readonly IMapper _mapper;

        public AdvertisingController(IAdvertisingService service, IWebmotorsService webmotorsService, IMapper mapper)
        {
            _service = service;
            _webmotorsService = webmotorsService;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(IEnumerable<Advertising>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var result = await _service.Get();

            return Ok(result);
        }

        [ProducesResponseType(typeof(Advertising), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("Get/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.Get(id);

            return Ok(result);
        }

        [ProducesResponseType(typeof(Advertising), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Post(AdvertisingViewModel advertising)
        {
            await _service.Create(await FromIdToName(advertising));

            return Created(nameof(Get), advertising.Id);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put(AdvertisingViewModel advertising)
        {
            await _service.Update(await FromIdToName(advertising));

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var advertising = await _service.Get(id);

            await _service.Delete(advertising);

            return NoContent();
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
