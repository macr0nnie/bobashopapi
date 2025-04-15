using BobaShopApi.Data;
using BobaShopApi.Models;
using Microsoft.EntityFrameworkCore;
public class EmployeeRepository{
    private readonly BobaShopContext _context;
    public List<Order> GetOrders(){
        return _context.Orders.FromSqlRaw(StoredProcedures.GetCustomerOrders).ToList();
    }


}