using Microsoft.EntityFrameworkCore;
using BobaShopApi.Models;

namespace BobaShopApi.Data
{
    public class BobaShopContext : DbContext
    {
        public BobaShopContext(DbContextOptions<BobaShopContext> options) : base(options) { }

        // Define a DbSet for each model you want to map to a database table
        public DbSet<Drink> Drinks { get; set; }
    }
}