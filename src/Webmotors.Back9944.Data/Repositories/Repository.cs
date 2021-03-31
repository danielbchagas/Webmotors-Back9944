using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Interfaces.Repositories;
using Webmotors.Back9944.Business.Models;
using Webmotors.Back9944.Data.Contexts;

namespace Webmotors.Back9944.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(T entity)
        {
            if (entity == null) return false;

            await _context.Set<T>().AddAsync(entity);
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> Delete(T entity)
        {
            if (entity == null) return false;

            _context.Set<T>().Remove(entity);
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> Update(T entity)
        {
            if (entity == null) return false;

            _context.Entry<T>(entity).State = EntityState.Modified;
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public virtual async Task<T> Get(int id)
        {
            if (id < 0) return new T();

            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
