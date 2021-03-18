using System;
using Webmotors.Back9944.Interfaces.Actions;
using Webmotors.Back9944.Models;

namespace Webmotors.Back9944.Interfaces.Services
{
    public interface IAdvertisingService : IDisposable, ICreate<Advertising>, IDelete<Advertising>, IUpdate<Advertising>, IGet<Advertising>
    {

    }
}
