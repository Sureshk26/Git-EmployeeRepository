using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
    public class EmployeeDbContext : DbContext
    {
        
            public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
            {

            }
            public DbSet<EmployeeModel> employeeModel { get; set; }
        
    }
}
