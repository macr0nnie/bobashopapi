using BobaShopApi.Models;

public interface IOrderService
{
    Task<Order> CreateOrderAsync(Order order);

}