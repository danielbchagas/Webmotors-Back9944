using System.Threading.Tasks;
using Webmotors.Back9944.Models;
using System.Collections.Generic;

namespace Webmotors.Back9944.Interfaces.Services {
    public interface IWebmotorsService
    {
        Task<IEnumerable<VehicleMaker>> GetMakers();
        Task<IEnumerable<VehicleModel>> GetModels(int makerId);
        Task<IEnumerable<VehicleVersion>> GetVersions(int modelId);
        Task<IEnumerable<Vehicle>> GetVehicles(int pageIndex);
    }
}