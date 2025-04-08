using Microsoft.EntityFrameworkCore;
using BobaShopApi.Models;

namespace BobaShopApi.Data
{
    public class BobaShopDbContext : DbContext
    {
        public BobaShopDbContext(DbContextOptions<BobaShopDbContext> options) : base(options) { }

        public DbSet<Drink> Drinks { get; set; }
    }
}