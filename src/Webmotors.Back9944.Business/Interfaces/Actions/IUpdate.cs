using System.Threading.Tasks;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Interfaces.Actions
{
    public interface IUpdate<T> where T : Entity
    {
        Task<bool> Update(T entity);
    }
}