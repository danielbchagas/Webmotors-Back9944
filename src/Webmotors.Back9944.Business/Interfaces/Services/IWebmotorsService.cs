using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.DTOs;

namespace Webmotors.Back9944.Business.Interfaces.Services
{
    public interface IWebmotorsService
    {
        Task<IEnumerable<MakerDTO>> GetMakers();
        Task<IEnumerable<ModelDTO>> GetModels(int makerId);
        Task<IEnumerable<VersionDTO>> GetVersions(int modelId);
        Task<IEnumerable<VehicleDTO>> GetVehicles(int pageIndex);
    }
}