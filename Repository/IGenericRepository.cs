using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    }
   
   
}
