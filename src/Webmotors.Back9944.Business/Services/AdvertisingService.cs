using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Interfaces.Repositories;
using Webmotors.Back9944.Business.Interfaces.Services;
using Webmotors.Back9944.Business.Models;
using Webmotors.Back9944.Business.Validations;

namespace Webmotors.Back9944.Business.Services
{
    public class AdvertisingService : IAdvertisingService
    {
        private readonly AdvertisingValidation _validation;
        private readonly IAdvertisingRepository _repository;
        private readonly IWebmotorsService _service;
        
        public AdvertisingService(IAdvertisingRepository repository, IWebmotorsService service)
        {
            _validation = new AdvertisingValidation();
            _repository = repository;
            _service = service;
        }

        public async Task<Advertising> Get(int id) => await _repository.Get(id);

        public async Task<IEnumerable<Advertising>> Get() => await _repository.Get();

        public async Task<bool> Create(Advertising advertising)
        {
            ValidationResult validation = _validation.Validate(advertising);

            if (!validation.IsValid)
            {
                throw FormattedException(validation);
            }

            Advertising newAdvertising = await FromIdToName(advertising);

            return await _repository.Create(newAdvertising);
        }

        public async Task<bool> Update(Advertising advertising)
        {
            ValidationResult validation = _validation.Validate(advertising);

            if (!validation.IsValid)
            {
                throw FormattedException(validation);
            }

            Advertising newAdvertising = await FromIdToName(advertising);

            return await _repository.Update(newAdvertising);
        }

        public async Task<bool> Delete(Advertising advertising)
        {
            ValidationResult validation = _validation.Validate(advertising);

            if (!validation.IsValid)
            {
                throw FormattedException(validation);
            }

            return await _repository.Delete(advertising);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        private async Task<Advertising> FromIdToName(Advertising advertising)
        {
            advertising.Marca = (await _service.GetMakers())
                .FirstOrDefault(c => c.Id == Convert.ToInt32(advertising.Marca))?.Name;
            advertising.Modelo = (await _service.GetModels(Convert.ToInt32(advertising.Marca)))
                .FirstOrDefault(m => m.Id == Convert.ToInt32(advertising.Modelo))?.Name;
            advertising.Versao = (await _service.GetVersions(Convert.ToInt32(advertising.Modelo)))
                .FirstOrDefault(v => v.Id == Convert.ToInt32(advertising.Versao))?.Name;

            return advertising;
        }

        private ArgumentException FormattedException(ValidationResult validation)
        {
            return new ArgumentException(string.Join(" - ", validation?.Errors.Select(e => e.ErrorMessage)));
        }
    }
}
