using MarketPlace.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class, IBaseEntity
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return await _context.SaveChangesAsync() != 0;
        }
        public async Task<bool> CreateRangeAsync(TEntity entity)//поки незнаю де використати
        {
            await _context.Set<TEntity>().AddRangeAsync();
            return await _context.SaveChangesAsync() != 0;
        }

        public IQueryable<TEntity> GetAllAsync()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }
        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var e = await GetByIdAsync(id);
            if (e != null)
            {
                _context.Set<TEntity>().Remove(e);
                return await _context.SaveChangesAsync() != 0;
            }
            return false;
        }
    }
}
