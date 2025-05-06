using BobaShopApi.Models;
using BobaShopApi.Repositories;

namespace BobaShopApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee);
            return employee;
        }

        public async Task<Employee?> UpdateEmployeeAsync(int id, Employee employee)
        {
            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (existingEmployee == null)
            {
                return null;
            }

            await _employeeRepository.UpdateEmployeeAsync(employee);
            return employee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (existingEmployee == null)
            {
                return false;
            }

            await _employeeRepository.DeleteEmployeeAsync(id);
            return true;
        }

        public async Task<List<Employee>> GetFilteredEmployeesAsync(int? id, string? name, string? position, decimal? salary, string? shift)
        {
            return await _employeeRepository.GetFilteredEmployeesAsync(id, name, position, salary, shift);
        }
    }
}