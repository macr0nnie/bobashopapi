using Microsoft.AspNetCore.Mvc;
using BobaShopApi.Repositories;
using BobaShopApi.Models; //fix so it doesnt have to use this

namespace BobaShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            return employee == null ? NotFound() : Ok(employee);
        }

        [HttpPost]
    public async Task<IActionResult> AddEmployeeAsync([FromBody] Employee employee)
    {
        if (employee == null)
        {
            return BadRequest("Employee cannot be null.");
        }
        await _employeeRepository.AddEmployeeAsync(employee);
        return CreatedAtAction(
            nameof(GetEmployeeByIdAsync),  // Action name
            new { id = employee.Id },     // Route values
            employee);                   // Created object
    }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id, [FromBody] Employee employee)
        {
            if (employee == null || employee.Id != id)
            {
                return BadRequest("Employee data is invalid.");
            }
            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            await _employeeRepository.UpdateEmployeeAsync(employee);
            return NoContent();
        }
        //delete employee
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            await _employeeRepository.DeleteEmployeeAsync(id);
            return NoContent();
        } 
        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredEmployeesAsync([FromQuery] int? id, [FromQuery] string? name, [FromQuery] string? position, [FromQuery] decimal? salary, [FromQuery] string? shift)
        {
        
            var employees = await _employeeRepository.GetFilteredEmployeesAsync(id, name, position, salary, shift);
            return Ok(employees);  
        }
    }
    }