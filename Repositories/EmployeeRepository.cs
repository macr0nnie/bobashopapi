using BobaShopApi.Data;
using BobaShopApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BobaShopApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly BobaShopContext _context;

        public EmployeeRepository(BobaShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC {StoredProcedures.AddEmployee}  @Name = {employee.Name}, @Position = {employee.Position}, @Salary = {employee.Salary}, @Shift = {employee.Shift}");
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC {StoredProcedures.DeleteEmployee} @Id = {id}");
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees
                .FromSqlRaw($"EXEC {StoredProcedures.GetAllEmployees}")
                .ToListAsync();
        }
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employees = await _context.Employees
                .FromSqlRaw($"EXEC {StoredProcedures.GetEmployeeById} @Id = {{0}}", id)
                .AsNoTracking()
                .ToListAsync();

            return employees.FirstOrDefault();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC {StoredProcedures.UpdateEmployee} @Id = {employee.Id}, @Name = {employee.Name}, @Position = {employee.Position}, @Salary = {employee.Salary}, @Shift = {employee.Shift}");
        }
        public async Task<List<Employee>> GetFilteredEmployeesAsync(int? id, string? name, string? position, decimal? salary, string? shift)
        {
            var employees = await _context.Employees
                .FromSqlRaw($"EXEC {StoredProcedures.GetFilteredEmployees} @Id = {{0}}, @Name = {{1}}, @Position = {{2}}, @Salary = {{3}}, @Shift = {{4}}",
                    id, name, position, salary, shift)
                .AsNoTracking()
                .ToListAsync();

            return employees;
        }

    }
}