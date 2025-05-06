using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using BobaShopApi.Data;
using BobaShopApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BobaShopApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BobaShopContext _context;

        public OrderRepository(BobaShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.FromSqlRaw($"EXEC {StoredProcedures.GetAllOrders}").ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            var parameter = new SqlParameter("@OrderId", orderId);
            return await _context.Orders.FromSqlRaw($"EXEC {StoredProcedures.GetOrderById} @OrderId", parameter).FirstOrDefaultAsync();
        }

        public async Task AddOrderAsync(Order order)
        {
            var parameters = new[]
            {
                new SqlParameter("@CustomerName", order.CustomerName ?? (object)DBNull.Value),
                new SqlParameter("@TotalAmount", order.TotalAmount),
                new SqlParameter("@OrderDate", order.OrderDate)
            };
            await _context.Database.ExecuteSqlRawAsync($"EXEC {StoredProcedures.AddOrder} @CustomerName, @TotalAmount, @OrderDate", parameters);
        }

        public async Task UpdateOrderAsync(Order order)
        {
            var parameters = new[]
            {
                new SqlParameter("@OrderId", order.Id),
                new SqlParameter("@CustomerName", order.CustomerName ?? (object)DBNull.Value),
                new SqlParameter("@TotalAmount", order.TotalAmount),
                new SqlParameter("@OrderDate", order.OrderDate)
            };
            await _context.Database.ExecuteSqlRawAsync($"EXEC {StoredProcedures.UpdateOrder} @OrderId, @CustomerName, @TotalAmount, @OrderDate", parameters);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var parameter = new SqlParameter("@OrderId", orderId);
            await _context.Database.ExecuteSqlRawAsync($"EXEC {StoredProcedures.DeleteOrder} @OrderId", parameter);
        }

        public async Task<IEnumerable<Order>> GetFilteredOrdersAsync(string filter)
        {
            var parameter = new SqlParameter("@Filter", filter);
            return await _context.Orders.FromSqlRaw($"EXEC {StoredProcedures.GetFilteredOrders} @Filter", parameter).ToListAsync();
        }

        public async Task<Order?> GetOrderDetailsAsync(int orderId)
        {
            var parameter = new SqlParameter("@OrderId", orderId);
            return await _context.Orders.FromSqlRaw($"EXEC {StoredProcedures.GetOrderDetails} @OrderId", parameter).FirstOrDefaultAsync();
        }
    }
}