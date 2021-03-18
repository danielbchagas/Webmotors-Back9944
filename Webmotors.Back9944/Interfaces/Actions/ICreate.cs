using System.Threading.Tasks;
using Webmotors.Back9944.Models;

namespace Webmotors.Back9944.Interfaces.Actions {
    public interface ICreate<T> where T : Entity {
        Task<int> Create(T entity);
    } 
}