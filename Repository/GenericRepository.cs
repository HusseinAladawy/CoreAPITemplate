using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext context;
        internal DbSet<T> table;
        public GenericRepository(
              DbContext context)
        {
            this.context = context;
            table = context.Set<T>();

        }
        public async Task Delete(int id)
        {
          var  entity = table.Find(id);
             table.Remove(entity);
            await Task.CompletedTask;

        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await table.Where(predicate).ToListAsync();
            
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public virtual async Task<T> GetByID(int id)
        {
            return await table.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            await table.AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            //context.Attach(entity);

            //context.Entry(entity).State = EntityState.Modified;

            table.Update(entity);

           await Task.CompletedTask;
        }
    }


    
    

}

