using BobaShopApi.Models;

namespace BobaShopApi{
    public interface IDrinkRepository
    {
        Task<List<Drink>> GetAllDrinksAsync();
        Task<Drink> GetDrinkByIdAsync(int id);
        Task AddDrinkAsync(Drink drink);
        Task UpdateDrinkAsync(Drink drink);
        Task DeleteDrinkAsync(int id);
        
    }
}