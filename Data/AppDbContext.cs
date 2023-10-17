using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CollegeWebsite.Models;

namespace CollegeWebsite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        public DbSet<CollegeWebsite.Models.StudentModel> StudentModel { get; set; } = default!;
        public DbSet<CollegeWebsite.Models.EmployeeModel> EmployeeModel { get; set; } = default!;

    }
}
