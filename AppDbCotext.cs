using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1
{
    public class AppDbCotext:DbContext
    {
        public AppDbCotext(DbContextOptions<AppDbCotext> options):base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}
