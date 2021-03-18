using System.Threading.Tasks;
using Webmotors.Back9944.Models;

namespace Webmotors.Back9944.Interfaces.Actions {
    public interface IUpdate<T> where T : Entity
    {
        Task Update(T entity);
    }
}