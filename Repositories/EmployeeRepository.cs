using System.Collections.Generic;
using BobaShopApi.Models;
using BobaShopApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BobaShopApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository  
    {
        private readonly BobaShopContext _context;
        public EmployeeRepository(BobaShopContext context)
        {
          _context = context;
        }
       
        public IEnumerable<Employee> GetALL()
        {
            
            return _context.Employees.ToList();
        }
        public Employee GetID(int id)
        {
            return _context.Employees.Find(id);
        }
        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }
        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Employee> GetALlEmployees()
        {
            throw new NotImplementedException();
        }
    }
}