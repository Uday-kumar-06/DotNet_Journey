using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private static List<string> employees =
        new()
        {
            "John",
            "David",
            "Smith"
        };

        [Authorize]
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddEmployee(string name)
        {
            employees.Add(name);

            return Ok("Employee Added");
        }
    }
}