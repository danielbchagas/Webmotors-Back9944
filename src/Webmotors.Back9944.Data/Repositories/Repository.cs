using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Back9944.Business.Interfaces.Repositories;
using Webmotors.Back9944.Business.Models;
using Webmotors.Back9944.Data.Contexts;
using System;

namespace Webmotors.Back9944.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentException();

            await _context.Set<TEntity>().AddAsync(entity);
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentException();

            _context.Set<TEntity>().Remove(entity);
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentException();

            _context.Entry<TEntity>(entity).State = EntityState.Modified;
            int rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public virtual async Task<TEntity> Get(int id)
        {
            if (id < 0) throw new ArgumentException();

            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> Get()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
