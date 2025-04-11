using Microsoft.EntityFrameworkCore;
using BobaShopApi.Models;

namespace BobaShopApi.Data
{
    public class BobaShopContext : DbContext
    {
        public BobaShopContext(DbContextOptions<BobaShopContext> options) : base(options) { }

        // Define a DbSet for each model you want to map to a database table
        public DbSet<Drink> Drinks { get; set; }
     

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

        }
    }
}