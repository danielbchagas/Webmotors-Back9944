using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<bool> Create(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Update(T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();
    }
}
