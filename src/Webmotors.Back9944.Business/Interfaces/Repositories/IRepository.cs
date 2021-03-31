using System;
using Webmotors.Back9944.Business.Interfaces.Actions;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable, ICreate<T>, IDelete<T>, IUpdate<T>, IGet<T> where T : Entity
    {
    }
}
