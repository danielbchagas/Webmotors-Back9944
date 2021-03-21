using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Interfaces.Services
{
    public interface IWebmotorsService
    {
        Task<IEnumerable<Maker>> GetMakers();
        Task<IEnumerable<Model>> GetModels(int makerId);
        Task<IEnumerable<Version>> GetVersions(int modelId);
        Task<IEnumerable<Vehicle>> GetVehicles(int pageIndex);
    }
}