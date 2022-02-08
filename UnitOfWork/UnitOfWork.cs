using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbCotext dbContext;
        public IEmployeeRepository employeeRepository { get; private set; }
        public IGenericRepository<Department> departmentRepository { get; private set; }
        public UnitOfWork(AppDbCotext appDbContext)
        {
            this.dbContext = appDbContext;
            employeeRepository = new EmployeeReository(dbContext);
            departmentRepository = new GenericRepository<Department>(dbContext);
        }

       

        public async void Dispose()
        {
            await dbContext.DisposeAsync();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

      
    }
}
