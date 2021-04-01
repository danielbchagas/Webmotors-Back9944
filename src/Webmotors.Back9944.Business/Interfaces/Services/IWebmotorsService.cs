using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Interfaces.Services
{
    public interface IWebmotorsService
    {
        Task<IEnumerable<WmMaker>> GetMakers();
        Task<IEnumerable<WmModel>> GetModels(int makerId);
        Task<IEnumerable<WmVersion>> GetVersions(int modelId);
        Task<IEnumerable<WmVehicle>> GetVehicles(int pageIndex);
    }
}