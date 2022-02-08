using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public class DepartmentRepository:GenericRepository<Department>
    {

        public DepartmentRepository(AppDbCotext appDbCotext):base(appDbCotext)
        {

        }
    }
}
