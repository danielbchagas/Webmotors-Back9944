using System.Threading.Tasks;
using Webmotors.Back9944.Models;
using System.Collections.Generic;

namespace Webmotors.Back9944.Interfaces.Actions {
    public interface IGet<T> where T : Entity {
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();
    } 
}