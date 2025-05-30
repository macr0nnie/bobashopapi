using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BobaShopApi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; } 
        public string? CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public int DrinkId { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}