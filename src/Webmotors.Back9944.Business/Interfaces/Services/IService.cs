using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Interfaces.Services
{
    public interface IService<TEntity> : IDisposable where TEntity : Entity
    {
        Task<bool> Create(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> Get();
    }
}
