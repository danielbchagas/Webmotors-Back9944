using System.Collections.Generic;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Interfaces.Services
{
    public interface IAdvertisingService : IService<Advertising>
    {
        IEnumerable<string> GetErrors();
    }
}
