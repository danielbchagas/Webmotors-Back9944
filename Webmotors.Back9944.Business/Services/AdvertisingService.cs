using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Interfaces.Repositories;
using Webmotors.Back9944.Business.Interfaces.Services;
using Webmotors.Back9944.Business.Models;
using Webmotors.Back9944.Validations;

namespace Webmotors.Back9944.Business.Services
{
    public class AdvertisingService : IAdvertisingService
    {
        private readonly AdvertisingValidation _validator;
        private readonly IAdvertisingRepository _repository;
        public IEnumerable<string> _errors;
        
        public AdvertisingService(IAdvertisingRepository repository)
        {
            _validator = new AdvertisingValidation();
            _repository = repository;
            _errors = new List<string>();
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
                
            await _repository.Create(advertising);
        }

        public async Task Delete(Advertising advertising)
        {
            ValidationResult validation = _validator.Validate(advertising);
            
            if (!validation.IsValid)
            {
                _errors = validation?.Errors.Select(e => e.ErrorMessage);
                return;
            }
            
            await _repository.Delete(advertising);
        }

        public async Task Update(Advertising advertising)
        {
            ValidationResult validation = _validator.Validate(advertising);
            
            if (!validation.IsValid)
            {
                _errors = validation?.Errors.Select(e => e.ErrorMessage);
                return;
            }

            await _repository.Update(advertising);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
