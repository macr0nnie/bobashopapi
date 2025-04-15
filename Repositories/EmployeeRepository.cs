using BobaShopApi.Data;
using BobaShopApi.Models;
using Microsoft.EntityFrameworkCore;
namespace BobaShopApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly BobaShopContext _context;
        public EmployeeRepository(BobaShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public  Task AddEmployeeAsync(Employee employee)
        {
            return _context.Employees.FromSqlRaw($"EXEC {StoredProcedures.AddEmployee} @Name = {employee.Name}, @Position = {employee.Position}, @Salary = {employee.Salary}, @Shift = {employee.Shift}").ToListAsync();
        }

        public Task DeleteEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {  
            return await _context.Employees.FromSqlRaw($"EXEC {StoredProcedures.GetAllEmployees}").ToListAsync();
        }

        public Task<Employee> GetEmployeeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}

