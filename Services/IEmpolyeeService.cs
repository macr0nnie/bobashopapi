using System.Collections.Generic;
using System.Threading.Tasks;
using BobaShopApi.Models;

namespace BobaShopApi.Services
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> UpdateEmployeeAsync(int id, Employee employee);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<List<Employee>> GetFilteredEmployeesAsync(int? id, string? name, string? position, decimal? salary, string? shift);
    }
}