using EmployeeFinder.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeFinder.Business.Abstract;
using EmployeeFinder.DataAccess.Abstract;
using EmployeeFinder.Entities;

namespace EmployeeFinder.Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private EmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = new EmployeeRepository();
        }

        public Employee CreateEmployee(Employee employee)
        {
            return _employeeRepository.CreateEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }

        public List<Employee> GetAllEmployee()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public Employee GetEmployeeById(int id)
        {
            if (id > 0)
            {
                return _employeeRepository.GetEmployeeById(id);
            }

            throw new Exception("id can not be less than 1");
        }

        public Employee GetEmployeeByDepartment(string department)
        {
            return _employeeRepository.GetEmployeeByDepartment(department);
        }

        public Employee UpdateEmployee(Employee employee)
        {
            return _employeeRepository.UpdateEmployee(employee);
        }
    }
}
