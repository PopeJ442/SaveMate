using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SaveMate.ApplicationDbContext;
using SaveMate.Models;
using SaveMate.Repositories.IRepository;
using System;
using System.Runtime.InteropServices;

namespace SaveMate.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly SaveMateDbContext _context;
        private readonly DbSet<T> _dbSet;


        public BaseRepository(SaveMateDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

         public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null) 
            {
            _dbSet.Remove(entity);
                await SaveAsync();
            }
           
        }
        
    }
}

