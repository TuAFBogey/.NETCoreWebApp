using EmployeeFinder.DataAccess.Abstract;
using EmployeeFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeFinder.DataAccess.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee CreateEmployee(Employee employee)
        {
            using (var employeeDbContext = new EmployeeDbContext())
            {
                employeeDbContext.Employees.Add(employee);
                employeeDbContext.SaveChanges();
                return employee;
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var employeeDbContext = new EmployeeDbContext())
            {
                var deletedemployee = GetEmployeeById(id);
                employeeDbContext.Employees.Remove(deletedemployee);
                employeeDbContext.SaveChanges();
            }
        }

        public List<Employee> GetAllEmployees()
        {
            using (var employeeDbContext = new EmployeeDbContext())
            {
                return employeeDbContext.Employees.ToList();
            }
        }

        public Employee GetEmployeeById(int id)
        {
            using (var employeeDbContext = new EmployeeDbContext())
            {
                return employeeDbContext.Employees.Find(id);
            }
        }

        public Employee GetEmployeeByDepartment(string department)
        {
            using (var employeeDbContext = new EmployeeDbContext())
            {
                return employeeDbContext.Employees.FirstOrDefault(x => x.Department.ToLower() == department.ToLower());
            }
        }

        public Employee UpdateEmployee(Employee employee)
        {
            using (var employeeDbContext = new EmployeeDbContext())
            {
                employeeDbContext.Employees.Update(employee);
                employeeDbContext.SaveChanges();
                return employee;
            }
        }
    }
}
