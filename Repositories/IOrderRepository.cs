using System.Collections.Generic;
using System.Threading.Tasks;
using BobaShopApi.Models;

namespace BobaShopApi.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
        Task<IEnumerable<Order>> GetFilteredOrdersAsync(string filter);
        Task<Order?> GetOrderDetailsAsync(int orderId);
    }
}