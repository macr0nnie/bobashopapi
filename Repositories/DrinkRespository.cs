
using BobaShopApi.Models;
using BobaShopApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BobaShopApi
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly BobaShopContext _context;

        //always include the dependency injection
        public DrinkRepository(BobaShopContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
         public async Task<IEnumerable<Employee>> GetAllAsync()
        {  
            return await _context.Employees.FromSqlRaw($"EXEC {StoredProcedures.GetAllDrinks}").ToListAsync();
        }
        public Task<Drink> GetDrinkByIdAsync(int id)
        {
            return _context.Drinks.FromSqlRaw($"EXEC {StoredProcedures.GetDrinkById} @Id={id}").FirstOrDefaultAsync();
        }

        public Task AddDrinkAsync(Drink drink)
        {
            return _context.Drinks
                .FromSqlRaw($"EXEC {StoredProcedures.AddDrink} @Id = {drink.Id} , @Name={drink.Name}, @Price={drink.Price}")
                .ToListAsync();
        }

        public Task DeleteDrinkAsync(int id)
        {
            return _context.Drinks
                .FromSqlInterpolated($"EXEC {StoredProcedures.DeleteDrink} @Id={id}")
                    .ToListAsync();
        }

        public Task UpdateDrinkAsync(Drink drink)
        {
            return _context.Drinks
                .FromSqlInterpolated($"EXEC {StoredProcedures.UpdateDrink} @Id={drink.Id}, @Name={drink.Name}, @Price={drink.Price}")
                .ToListAsync();
        }

        public Task<List<Drink>> GetAllDrinksAsync()
        {
           return _context.Drinks.FromSqlRaw($"EXEC {StoredProcedures.GetAllDrinks}").ToListAsync();
        }
    }
}