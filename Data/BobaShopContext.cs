using Microsoft.EntityFrameworkCore;
using BobaShopApi.Models;

namespace BobaShopApi.Data
{
    public class BobaShopContext : DbContext
    {
        public BobaShopContext(DbContextOptions<BobaShopContext> options) : base(options) { }
        // Define a DbSet for each model you want to map to a database table
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; } // Added DbSet for OrderItems

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //what is this for?

            // combine tables
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure precision and scale for decimal properties idk why chatpt said to do this
            modelBuilder.Entity<Drink>().Property(d => d.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Employee>().Property(e => e.Salary).HasPrecision(18, 2);
            modelBuilder.Entity<Order>().Property(o => o.TotalAmount).HasPrecision(18, 2);
            modelBuilder.Entity<OrderItem>().Property(oi => oi.Price).HasPrecision(18, 2);

            //seed data
            modelBuilder.Entity<Drink>().HasData(
                new Drink { Id = 7, Name = "Vegan Juice", Price = 20.8m, ImageUrl = "https://example.com/vegan-juice.jpg" },
                new Drink { Id = 8, Name = "Peach Oolong Tea", Price = 3.25m ,ImageUrl  = "https://www.bing.com/th/id/OIP.Gsl2sxyGt020l_KzrKqEHAHaFE?w=273&h=211&c=8&rs=1&qlt=90&o=6&dpr=2&pid=3.1&rm=2"}
            );
            //sample seed data for eomployees
            modelBuilder.Entity<Employee>().HasData(
                   new Employee { Id = 1, Name = "Jojo Siwa", Position = "Matcha Man", Salary = 10000, Shift = "Morning" },
                   new Employee { Id = 2, Name = "Bella", Position = "  Lawyer", Salary = 500000, Shift = "Evening" },
                   new Employee { Id = 3, Name = "Grayce Johnson", Position = "Taster", Salary = 250000, Shift = "Afternoon" },
                   new Employee { Id = 4, Name = "Cindy Cindy'sLastName", Position = "Delivery", Salary = 28000, Shift = "Morning" },
                   new Employee { Id = 5, Name = "General Trab", Position = "HR", Salary = 400000, Shift = "Evening" },
                   new Employee { Id = 6, Name = "Oliver JFK", Position = "RadStreamer", Salary = 320000, Shift = "Reasonable Hours" },
                   new Employee { Id = 7, Name = "Shelly Jarsky", Position = "Lead Scientist", Salary = 5500000, Shift = "Morning" },
                   new Employee { Id = 8, Name = "Creature Jarsky", Position = "Sad Intern", Salary = 10, Shift = "Graveyard" },
                   new Employee { Id = 9, Name = "Numi Toffe", Position = "Stay at Home Daughter", Salary = 5000, Shift = "24/7" },
                   new Employee { Id = 10, Name = "Tia", Position = "Writer", Salary = 1000000, Shift = "Evening" },
                   new Employee { Id = 11, Name = "Lexi", Position = "Vegan", Salary = 2000000, Shift = "Morning" },
                   new Employee { Id = 12, Name = "Jennifer Kanna", Position = "Estition", Salary = 2000000, Shift = "Morning" },
                   new Employee { Id = 13, Name = "Josh", Position = "Kanna's Assistant/Stay at Home Husband", Salary = 20, Shift = "Morning" },
                   new Employee { Id = 14, Name = "Yoni ", Position = "Streamer", Salary = 200000000, Shift = "Night" },
                   new Employee { Id = 15, Name = "Lev", Position = "Acedemic Weapon", Salary = 1000, Shift = "Morning" },
                   new Employee { Id = 16, Name = "Lochnessa", Position = "Manager", Salary = 100000, Shift = "Morning" },
                   new Employee { Id = 17, Name = "Zoe Catluv7", Position = "Marine Biologist", Salary = 100000, Shift = "Morning" },
                   new Employee { Id = 18, Name = "Esme", Position = "Japanese", Salary = 100000, Shift = "Morning" },
                   new Employee { Id = 19, Name = "Barbie", Position = "Being Hot", Salary = 10000000000, Shift = "Morning" },
                   new Employee { Id = 20, Name = "Megan", Position = "Stuff", Salary = 100000, Shift = "Morning" },
                   new Employee { Id = 21, Name = "Alf", Position = "Boba Maker", Salary = 50, Shift = "Graveyard" },
                   new Employee { Id = 22, Name = "Riley Catluv7", Position = "Boba Music/Zoe's Pet", Salary = 30, Shift = "Graveyard" },
                   new Employee { Id = 23, Name = "Avery", Position = "Professor", Salary = 300000, Shift = "Morning" },
                   new Employee { Id = 24, Name = "Megan Catluv7", Position = "Boba Music/Zoe's Pet", Salary = 30, Shift = "Graveyard" }
               );
        }

    }
}