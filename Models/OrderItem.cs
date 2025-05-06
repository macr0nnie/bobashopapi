using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BobaShopApi.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; } 
        public int OrderId { get; set; }
        public int DrinkId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; } = null!;

        [ForeignKey("DrinkId")]
        public Drink Drink { get; set; } = null!;
    }
}