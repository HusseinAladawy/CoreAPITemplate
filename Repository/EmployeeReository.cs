using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class EmployeeReository:GenericRepository<Employee>,IEmployeeRepository
    {
        public EmployeeReository(AppDbCotext appDbContext):base(appDbContext)
        {

        }
        public override async Task<Employee> GetByID(int id)
        {
          
            return await table.Include(t=>t.Department).SingleOrDefaultAsync(x=>x.EmployeeId==id);
        }
    }
}
