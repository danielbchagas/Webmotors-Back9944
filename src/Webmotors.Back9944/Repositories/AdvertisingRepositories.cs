using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Back9944.Data;
using Webmotors.Back9944.Interfaces.Repositories;
using Webmotors.Back9944.Models;

namespace Webmotors.Back9944.Repositories 
{
    public class AdvertisingRepository : IAdvertisingRepository
    {
        private readonly ApplicationContext _context;

        public AdvertisingRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Advertising entity)
        {
            await _context.Advertisings.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Advertising entity)
        {
            _context.Advertisings.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<Advertising> Get(int id) => await _context.Advertisings.FindAsync(id);

        public async Task<IEnumerable<Advertising>> Get() => await _context.Advertisings.ToListAsync();

        public async Task<int> Update(Advertising entity)
        {
            _context.Entry<Advertising>(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}