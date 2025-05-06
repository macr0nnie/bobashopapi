using Microsoft.AspNetCore.Mvc;
using BobaShopApi.Services;
using BobaShopApi.Models;

namespace BobaShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return employee == null ? NotFound() : Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee cannot be null.");
            }
            var createdEmployee = await _employeeService.CreateEmployeeAsync(employee);
            return CreatedAtAction(
                nameof(GetEmployeeByIdAsync),
                new { id = createdEmployee.Id },
                createdEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody] Employee employee)
        {
            if (employee == null || employee.Id != id)
            {
                return BadRequest("Employee data is invalid.");
            }
            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(id, employee);
            if (updatedEmployee == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            var success = await _employeeService.DeleteEmployeeAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredEmployeesAsync([FromQuery] int? id, [FromQuery] string? name, [FromQuery] string? position, [FromQuery] decimal? salary, [FromQuery] string? shift)
        {
            var employees = await _employeeService.GetFilteredEmployeesAsync(id, name, position, salary, shift);
            return Ok(employees);
        }
    }
}