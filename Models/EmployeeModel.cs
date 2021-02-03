using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace LabbTsb.Models
{
    public class EmployeeModel : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Section> Sections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data source=emp.db");
    }
}
