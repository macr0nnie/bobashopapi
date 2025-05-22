using BobaShopApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BobaShopApi.Repositories
{
    public interface IDrinkRepository
    {
        Task<List<Drink>> GetAllDrinksAsync();
        Task<Drink> GetDrinkByIdAsync(int id);
        Task AddDrinkAsync(Drink drink);
        Task UpdateDrinkAsync(Drink drink);
        Task DeleteDrinkAsync(int id);
        
    }
}