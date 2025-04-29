using BobaShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class OrderService : IOrderService
{
   private readonly IOrderService _orderService;

   
   public OrderService(IOrderService orderService)
   {
       _orderService = orderService;
   }
    
    
    public async Task<Order> CreateOrderAsync(Order order)
    {

        return await Task.FromResult(order);
    }
}
