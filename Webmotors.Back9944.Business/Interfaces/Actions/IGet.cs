using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Interfaces.Actions
{
    public interface IGet<T> where T : Entity 
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();
    } 
}