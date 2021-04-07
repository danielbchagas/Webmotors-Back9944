using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Interfaces.Services
{
    public interface IWebmotorsService
    {
        Task<IEnumerable<MakerDto>> GetMakers();
        Task<IEnumerable<ModelDto>> GetModels(int makerId);
        Task<IEnumerable<VersionDto>> GetVersions(int modelId);
        Task<IEnumerable<VehicleDto>> GetVehicles(int pageIndex);
    }
}