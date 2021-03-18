using System.Threading.Tasks;
using Webmotors.Back9944.Models;
using Webmotors.Back9944.Services.Results;

namespace Webmotors.Back9944.Interfaces.Services
{
    public interface IAdvertisingService
    {
        Task<AdvertisingResult> Create(Advertising advertising);
        Task<AdvertisingResult> Update(Advertising advertising);
        Task<AdvertisingResult> Delete(Advertising advertising);
    }
}
