using BobaShopApi.Data;
using BobaShopApi.Models;
using Microsoft.EntityFrameworkCore;
namespace BobaShopApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly BobaShopContext _context;

        public Task AddEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.FromSql($"EXEC{StoredProcedures.GetAllEmployees}").ToListAsync(); //all employees

            //all employees
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

