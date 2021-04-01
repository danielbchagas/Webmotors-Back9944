using System;
using Webmotors.Back9944.Business.Interfaces.Actions;
using Webmotors.Back9944.Business.Models;

namespace Webmotors.Back9944.Business.Interfaces.Repositories
{
    public interface IAdvertisingRepository : IDisposable, ICreate<Advertising>, IDelete<Advertising>, IUpdate<Advertising>, IGet<Advertising>
    {  
    } 
}