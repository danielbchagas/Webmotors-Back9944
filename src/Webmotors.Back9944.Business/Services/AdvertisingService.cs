using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Interfaces.Repositories;
using Webmotors.Back9944.Business.Interfaces.Services;
using Webmotors.Back9944.Business.Models;
using Webmotors.Back9944.Business.Validations.AdvertisingRules;

namespace Webmotors.Back9944.Business.Services
{
    public class AdvertisingService : IAdvertisingService
    {
        private readonly AdvertisingPropertiesValidation _propertiesValidator;
        private readonly AdvertisingCreateValidation _createValidator;
        private readonly AdvertisingUpdateDeleteValidation _updateValidator;
        private readonly IAdvertisingRepository _repository;
        private readonly IWebmotorsService _service;
        public IEnumerable<string> _errors;
        
        public AdvertisingService(IAdvertisingRepository repository, IWebmotorsService service)
        {
            _propertiesValidator = new AdvertisingPropertiesValidation();
            _createValidator = new AdvertisingCreateValidation();
            _updateValidator = new AdvertisingUpdateDeleteValidation();

            _repository = repository;
            _service = service;
            _errors = new List<string>();
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

        public async Task<Advertising> Get(int id) => await _repository.Get(id);

        public async Task<IEnumerable<Advertising>> Get() => await _repository.Get();

        public async Task Create(Advertising advertising)
        {
            ValidationResult idValidation = _createValidator.Validate(advertising);
            ValidationResult propertiesValidation = _propertiesValidator.Validate(advertising);
            
            if (!idValidation.IsValid || !propertiesValidation.IsValid)
            {
                _errors = ConcatErrors(new List<ValidationResult> { idValidation, propertiesValidation });
                return;
            }
                
            Advertising newAdvertising = await FromIdToName(advertising);

            await _repository.Create(newAdvertising);
        }

        public async Task Update(Advertising advertising)
        {
            ValidationResult idValidation = _updateValidator.Validate(advertising);
            ValidationResult propertiesValidation = _propertiesValidator.Validate(advertising);
            
            if (!(idValidation.IsValid || propertiesValidation.IsValid))
            {
                _errors = ConcatErrors(new List<ValidationResult> { idValidation, propertiesValidation });
                return;
            }

            Advertising newAdvertising = await FromIdToName(advertising);

            await _repository.Update(newAdvertising);
        }

        public async Task Delete(Advertising advertising)
        {
            ValidationResult idValidation = _updateValidator.Validate(advertising);

            if (!idValidation.IsValid)
            {
                _errors = ConcatErrors(new List<ValidationResult> { idValidation });
                return;
            }

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

        private IEnumerable<string> ConcatErrors(IEnumerable<ValidationResult> validations)
        {
            IEnumerable<string> response = new List<string>();

            foreach(ValidationResult validation in validations)
            {
                response = response.Concat(validation?.Errors.Select(e => e.ErrorMessage));
            }

            return response;
        }
    }
}
