using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webmotors.Back9944.Interfaces.Repositories;
using Webmotors.Back9944.Interfaces.Services;
using Webmotors.Back9944.Models;
using Webmotors.Back9944.Validations;
using FluentValidation.Results;

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

        public Task<int> Create(Advertising entity)
        {
            ValidationResult validation = _validator.Validate(entity);

            if (!validation.IsValid)
            {
                IEnumerable<string> errors = validation.Errors.Select(e => e.ErrorMessage);
                // Notificar
            }

            return _repository.Create(entity);
        }

        public Task<int> Delete(Advertising entity)
        {
            ValidationResult validation = _validator.Validate(entity);

            if (!validation.IsValid)
            {
                IEnumerable<string> errors = validation.Errors.Select(e => e.ErrorMessage);
                // Notificar
            }

            return _repository.Delete(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public async Task<Advertising> Get(int id) => await _repository.Get(id);

        public async Task<IEnumerable<Advertising>> Get() => await _repository.Get();

        public Task<int> Update(Advertising entity)
        {
            ValidationResult validation = _validator.Validate(entity);

            if (!validation.IsValid)
            {
                IEnumerable<string> errors = validation.Errors.Select(e => e.ErrorMessage);
                // Notificar
            }

            return _repository.Update(entity);
        }
    }
}
