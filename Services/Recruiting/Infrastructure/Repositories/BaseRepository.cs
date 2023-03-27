using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly RecruitingDbContext _dbContext;
        public BaseRepository(RecruitingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddtAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> GetExistsAsync(Expression<Func<T, bool>>? filter = null)
        {
            if(filter == null)
            {
                return false;
            }
            return await _dbContext.Set<T>().Where(filter).AnyAsync();
            
        }

        public async Task<T> UpdatetAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
