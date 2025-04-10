using Microsoft.EntityFrameworkCore;
using BobaShopApi.Models;

namespace BobaShopApi.Data
{
    public class BobaShopContext : DbContext
    {
        public BobaShopContext(DbContextOptions<BobaShopContext> options) : base(options) { }

        // Define a DbSet for each model you want to map to a database table
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //what is this for?
            //seed data
            modelBuilder.Entity<Drink>().HasData(
                new Drink { Id = 1, Name = "Classic Milk Tea", Price = 3.50m },
                new Drink { Id = 2, Name = "Taro Milk Tea", Price = 4.00m },
                new Drink { Id = 3, Name = "Matcha Latte", Price = 4.50m },
                new Drink { Id = 4, Name = "Mango Smoothie", Price = 5.00m },
                new Drink { Id = 5, Name = "Strawberry Lemonade", Price = 3.75m }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Alice", Department = "Sales" },
                new Employee { Id = 2, Name = "Bob", Department = "Marketing" },
                new Employee { Id = 3, Name = "Charlie", Department = "Operations" },
                new Employee { Id = 4, Name = "David", Department = "HR" },
                new Employee { Id = 5, Name = "Eve", Department = "Finance" }
            );
        }
    }
}