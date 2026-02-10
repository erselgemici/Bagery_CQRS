using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyAcademyCQRS.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);

        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);

        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
