using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Interfaces.Repositories;
using Webmotors.Back9944.Business.Interfaces.Services;
using Webmotors.Back9944.Business.Models;
using Webmotors.Back9944.Validations;
using System;

namespace Webmotors.Back9944.Business.Services
{
    public class AdvertisingService : IAdvertisingService
    {
        private readonly AdvertisingValidation _validator;
        private readonly IAdvertisingRepository _repository;
        private readonly IWebmotorsService _service;
        public IEnumerable<string> _errors;
        
        public AdvertisingService(IAdvertisingRepository repository, IWebmotorsService service)
        {
            _validator = new AdvertisingValidation();
            _repository = repository;
            _service = service;
            _errors = new List<string>();
        }

        private async Task<Advertising> Change(Advertising advertising)
        {
            var marca = (await _service.GetMakers()).FirstOrDefault(c => c.Id == Convert.ToInt32(advertising.Marca));
            var modelo = (await _service.GetModels(Convert.ToInt32(advertising.Marca))).FirstOrDefault(m => m.Id == Convert.ToInt32(advertising.Modelo));
            var versao = (await _service.GetVersions(Convert.ToInt32(advertising.Modelo))).FirstOrDefault(v => v.Id == Convert.ToInt32(advertising.Versao));

            advertising.Marca = marca.Name;
            advertising.Modelo = modelo.Name;
            advertising.Versao = versao.Name;

            return advertising;
        }

        public async Task<Advertising> Get(int id) => await _repository.Get(id);

        public async Task<IEnumerable<Advertising>> Get() => await _repository.Get();

        public async Task Create(Advertising advertising)
        {
            ValidationResult validation = _validator.Validate(advertising);
            
            if (!validation.IsValid)
            {
                _errors = validation?.Errors.Select(e => e.ErrorMessage);
                return;
            }
                
            Advertising newAdvertising = await Change(advertising);

            await _repository.Create(newAdvertising);
        }

        public async Task Update(Advertising advertising)
        {
            ValidationResult validation = _validator.Validate(advertising);
            
            if (!validation.IsValid)
            {
                _errors = validation?.Errors.Select(e => e.ErrorMessage);
                return;
            }

            Advertising newAdvertising = await Change(advertising);

            await _repository.Update(newAdvertising);
        }

        public async Task Delete(Advertising advertising)
        {
            await _repository.Delete(advertising);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<string> GetErrors()
        {
            return _errors;
        }
    }
}
