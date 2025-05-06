using BobaShopApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BobaShopApi.Services
{
    public interface IDrinkService
    {
        Task<List<Drink>> GetAllDrinksAsync();
        Task<Drink?> GetDrinkByIdAsync(int id);
        Task<Drink> CreateDrinkAsync(Drink drink);
        Task<Drink?> UpdateDrinkAsync(int id, Drink drink);
        Task<bool> DeleteDrinkAsync(int id);
    }
}