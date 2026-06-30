using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        // In-memory list (acts like DB for now)
        private static List<Employee> employees = new List<Employee>();

        // GET: api/employee
        [HttpGet]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            return Ok(employees);
        }

        // GET: api/employee/1
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var emp = employees.FirstOrDefault(e => e.EmployeeId == id);

            if (emp == null)
                return NotFound("Employee not found");

            return Ok(emp);
        }

        // POST: api/employee
        [HttpPost]
        public ActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest("Invalid employee data");

            employees.Add(employee);

            return Ok("Employee added successfully");
        }
    }


    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }
}