using FluentValidation;
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
        
        public AdvertisingService(IAdvertisingRepository repository)
        {
            _validation = new AdvertisingValidation();
            _repository = repository;
        }

        public async Task<Advertising> Get(int id) => await _repository.Get(id);

        public async Task<IEnumerable<Advertising>> Get() => await _repository.Get();

        public async Task<bool> Create(Advertising advertising)
        {
            _validation.ValidateAndThrow(advertising);

            return await _repository.Create(advertising);
        }

        public async Task<bool> Update(Advertising advertising)
        {
            _validation.ValidateAndThrow(advertising);

            return await _repository.Update(advertising);
        }

        public async Task<bool> Delete(Advertising advertising)
        {
            _validation.ValidateAndThrow(advertising);

            return await _repository.Delete(advertising);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
