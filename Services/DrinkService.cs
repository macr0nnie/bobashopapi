using BobaShopApi.Models;
using BobaShopApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BobaShopApi.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IDrinkRepository _drinkRepository;

        public DrinkService(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public async Task<List<Drink>> GetAllDrinksAsync()
        {
            return await _drinkRepository.GetAllDrinksAsync();
        }

        public async Task<Drink?> GetDrinkByIdAsync(int id)
        {
            return await _drinkRepository.GetDrinkByIdAsync(id);
        }

        public async Task<Drink> CreateDrinkAsync(Drink drink)
        {
            await _drinkRepository.AddDrinkAsync(drink);
            return drink;
        }

        public async Task<Drink?> UpdateDrinkAsync(int id, Drink drink)
        {
            var existingDrink = await _drinkRepository.GetDrinkByIdAsync(id);
            if (existingDrink == null)
            {
                return null;
            }

            await _drinkRepository.UpdateDrinkAsync(drink);
            return drink;
        }

        public async Task<bool> DeleteDrinkAsync(int id)
        {
            var existingDrink = await _drinkRepository.GetDrinkByIdAsync(id);
            if (existingDrink == null)
            {
                return false;
            }

            await _drinkRepository.DeleteDrinkAsync(id);
            return true;
        }
    }
}