using System.ComponentModel.DataAnnotations;

namespace BobaShopApi.Models{

    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public decimal Salary { get; set; }
        public string? Shift { get; set; }
    }
}