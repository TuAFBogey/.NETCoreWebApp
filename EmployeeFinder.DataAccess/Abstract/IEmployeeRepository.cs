using EmployeeFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeFinder.DataAccess.Abstract
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();

        Employee GetEmployeeById(int id);

        Employee GetEmployeeByDepartment(string department);

        Employee CreateEmployee(Employee employee);

        Employee UpdateEmployee(Employee employee);

        void DeleteEmployee(int id);
    }
}
