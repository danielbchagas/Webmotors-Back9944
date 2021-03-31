using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Interfaces.Repositories;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Repositories
{
    public class AdvertisingRepository : IAdvertisingRepository
    {
        private readonly IRepository<Advertising> _repository;

        public AdvertisingRepository(IRepository<Advertising> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Create(Advertising entity) 
            => await _repository.Create(entity);

        public async Task<bool> Delete(Advertising entity) 
            => await _repository.Delete(entity);

        public async Task<Advertising> Get(int id) 
            => await _repository.Get(id);

        public async Task<IEnumerable<Advertising>> Get()
            => await _repository.Get();

        public async Task<bool> Update(Advertising entity) 
            => await _repository.Update(entity);

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}