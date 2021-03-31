using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Interfaces.Repositories;
using Webmotors.Back9944.Business.Models;
using Webmotors.Back9944.Data.Contexts;

namespace Webmotors.Back9944.Business.Repositories
{
    public class AdvertisingRepository : IAdvertisingRepository
    {
        private readonly ApplicationContext _context;

        public AdvertisingRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Advertising entity)
        {
            if (entity == null) return false;

            await _context.Advertisings.AddAsync(entity);
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> Delete(Advertising entity)
        {
            if (entity == null) return false;

            _context.Advertisings.Remove(entity);
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<Advertising> Get(int id) => id > 0 ? await _context.Advertisings.FindAsync(id) : new Advertising();

        public async Task<IEnumerable<Advertising>> Get() => await _context.Advertisings.ToListAsync();

        public async Task<bool> Update(Advertising entity)
        {
            if (entity == null) return false;

            _context.Entry<Advertising>(entity).State = EntityState.Modified;
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}