using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.Back9944.Interfaces.Repositories;
using Webmotors.Back9944.Interfaces.Services;
using Webmotors.Back9944.Models;
using Webmotors.Back9944.Services.Results;
using Webmotors.Back9944.Validations;

namespace Webmotors.Back9944.Services
{
    public class AdvertisingService : IAdvertisingService
    {
        private readonly AdvertisingValidation _validator;
        private readonly IAdvertisingRepository _repository;
        
        public AdvertisingService(IAdvertisingRepository repository)
        {
            _validator = new AdvertisingValidation();
            _repository = repository;
        }

        public async Task<Advertising> Get(int id) => await _repository.Get(id);

        public async Task<IEnumerable<Advertising>> Get() => await _repository.Get();

        public async Task<AdvertisingResult> Create(Advertising advertising)
        {
            ValidationResult validation = _validator.Validate(advertising);
            int result = 0;

            if (validation.IsValid)
                result = await _repository.Create(advertising);

            return new AdvertisingResult 
            {
                Errors = validation?.Errors.Select(e => e.ErrorMessage),
                AffectedRows = result
            };
        }

        public async Task<AdvertisingResult> Delete(Advertising advertising)
        {
            ValidationResult validation = _validator.Validate(advertising);
            int result = 0;
            
            if (validation.IsValid)
            {
                result = await _repository.Delete(advertising);
            }

            return new AdvertisingResult
            {
                Errors = validation?.Errors.Select(e => e.ErrorMessage),
                AffectedRows = result
            };
        }

        public async Task<AdvertisingResult> Update(Advertising advertising)
        {
            ValidationResult validation = _validator.Validate(advertising);
            int result = 0;

            if (validation.IsValid)
            {
                result = await _repository.Update(advertising);
            }

            return new AdvertisingResult
            {
                Errors = validation?.Errors.Select(e => e.ErrorMessage),
                AffectedRows = result
            };
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
