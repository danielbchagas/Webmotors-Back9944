using System;
using System.Collections.Generic;
using Webmotors.Back9944.Business.Interfaces.Actions;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Interfaces.Services
{
    public interface IAdvertisingService : IDisposable, ICreate<Advertising>, IDelete<Advertising>, IUpdate<Advertising>, IGet<Advertising>
    {
        IEnumerable<string> GetErrors();
    }
}
