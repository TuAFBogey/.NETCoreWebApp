using EmployeeFinder.Business.Abstract;
using EmployeeFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeFinder.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        /// <summary>
        /// Get All Employess
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var employee = _employeeService.GetAllEmployee();
            return Ok(employee);//200 + data
        }

        /// <summary>
        /// Get Employee By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound();

        }

        /// <summary>
        /// Get Employee By Department
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{department}")]
        public IActionResult GetEmployeeByDepartment(string department)
        {
            var employee = _employeeService.GetEmployeeByDepartment(department);
            if (employee != null)
            {
                return Ok(employee);//200 + data
            }
            return NotFound();
        }

        /// <summary>
        /// Create an Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            var createdEmployee = _employeeService.CreateEmployee(employee);
            return CreatedAtAction("Get", new { id = createdEmployee.Id }, createdEmployee);//201 + data
        }

        /// <summary>
        /// Update the Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            if (_employeeService.GetEmployeeById(employee.Id) != null)
            {
                return Ok(_employeeService.UpdateEmployee(employee));//200 + data
            }
            return NotFound();
        }

        /// <summary>
        /// Delete the Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_employeeService.GetEmployeeById(id) != null)
            {
                _employeeService.DeleteEmployee(id);
                return Ok();//200 + data
            }
            return NotFound();
            ;
        }
    }
}
