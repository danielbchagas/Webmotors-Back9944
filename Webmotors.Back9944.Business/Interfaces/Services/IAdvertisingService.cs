using System.Threading.Tasks;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Interfaces.Services
{
    public interface IAdvertisingService
    {
        Task Create(Advertising advertising);
        Task Update(Advertising advertising);
        Task Delete(Advertising advertising);
    }
}
