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
    }
}
