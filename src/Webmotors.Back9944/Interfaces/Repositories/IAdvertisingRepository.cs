using Webmotors.Back9944.Models;
using Webmotors.Back9944.Interfaces.Actions;
using System;

namespace Webmotors.Back9944.Interfaces.Repositories {
    public interface IAdvertisingRepository : IDisposable, ICreate<Advertising>, IDelete<Advertising>, IUpdate<Advertising>, IGet<Advertising>
    {
        
    } 
}