using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> Emps = new List<Employee>
        {
            new Employee(){EmpId=3,EmpName="Vehan",EmpDesignation="manager"},
          new Employee(){EmpId=9,EmpName="Miruthesh",EmpDesignation="Developer"},
          new Employee(){EmpId=6,EmpName="Rakesh",EmpDesignation="Tester"},
        };
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return Ok(Emps);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Invalid Employee data.");
            }

            employee.EmpId = Emps.Max(e => e.EmpId) + 1; // Generate a new ID
            Emps.Add(employee);

            return CreatedAtAction(nameof(Get), new { id = employee.EmpId }, employee);
        }
    }
}
   