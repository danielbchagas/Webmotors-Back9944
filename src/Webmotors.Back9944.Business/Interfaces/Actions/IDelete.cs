using System.Threading.Tasks;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Interfaces.Actions
{
    public interface IDelete<T> where T : Entity 
    {
        Task<bool> Delete(T entity);
    } 
}