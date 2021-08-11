using System;
using System.Collections.Generic;
using System.Text;
using EmployeeFinder.Entities;
using Microsoft.EntityFrameworkCore;



namespace EmployeeFinder.DataAccess
{
    public class EmployeeDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-PB7ARVU; Database=EmployeeDb;uid=bogey;pwd=1234;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
