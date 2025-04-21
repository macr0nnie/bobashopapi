using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace BobaShopApi.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}