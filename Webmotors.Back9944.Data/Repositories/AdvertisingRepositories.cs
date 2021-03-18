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

        public async Task Create(Advertising entity)
        {
            await _context.Advertisings.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Advertising entity)
        {
            _context.Advertisings.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<Advertising> Get(int id) => await _context.Advertisings.FindAsync(id);

        public async Task<IEnumerable<Advertising>> Get() => await _context.Advertisings.ToListAsync();

        public async Task Update(Advertising entity)
        {
            _context.Entry<Advertising>(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}