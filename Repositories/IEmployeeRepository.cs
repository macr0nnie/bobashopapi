using BobaShopApi.Models;

namespace BobaShopApi.Repositories
{

    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetALlEmployees();
        Employee GetID(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}


