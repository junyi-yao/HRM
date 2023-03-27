using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> GetExistsAsync(Expression<Func<T, bool>>? filter = null);
        Task<T> AddtAsync(T Entity);
        Task<T> UpdatetAsync(T Entity);
        Task<T> DeleteAsync(int id);

    }
}
