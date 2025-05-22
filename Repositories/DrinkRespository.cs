using BobaShopApi.Models;
using BobaShopApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BobaShopApi.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly BobaShopContext _context;
        //always include the dependency injection
        public DrinkRepository(BobaShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Drink> GetDrinkByIdAsync(int id)
        {
            var drinks = await _context.Drinks
                .FromSqlRaw("EXEC get_drink_by_id @Id = {0}", id)
                .AsNoTracking()
                .ToListAsync();
            return drinks.FirstOrDefault();
        }
        public async Task AddDrinkAsync(Drink drink)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync(
                $"EXEC {StoredProcedures.AddDrink} @Name = {drink.Name}, @ImageUrl = {drink.ImageUrl}, @Price = {drink.Price}");
        }
        public Task DeleteDrinkAsync(int id)
        {
            return _context.Drinks
                .FromSqlInterpolated($"EXEC {StoredProcedures.DeleteDrink} @Id={id}").ToListAsync();
        }
        public Task UpdateDrinkAsync(Drink drink)
        {
            return _context.Drinks
                .FromSqlInterpolated
                ($"EXEC {StoredProcedures.UpdateDrink} @Id={drink.Id}, @Name={drink.Name}, @ImageUrl={drink.ImageUrl}, @Price={drink.Price}")
                .ToListAsync();
        }
        public Task<List<Drink>> GetAllDrinksAsync()
        {
            return _context.Drinks.FromSqlRaw($"EXEC {StoredProcedures.GetAllDrinks}").ToListAsync();
        }
    }
}