using BobaShopApi.Models;
namespace BobaShopApi.Repositories{
public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllEmployeesAsync();
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task AddEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(int id);
}
}
