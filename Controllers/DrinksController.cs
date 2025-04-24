using Microsoft.AspNetCore.Mvc;
using BobaShopApi.Models;
namespace BobaShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinkRepository _drinkRepository;
        public DrinksController(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDrinksAsync()
        {
            var drinks = await _drinkRepository.GetAllDrinksAsync();
            return Ok(drinks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDrinkByIdAsync(int id)
        {
            var drink = await _drinkRepository.GetDrinkByIdAsync(id);
            if (drink == null)
            {
                return NotFound();
            }
            return Ok(drink);
        }
        [HttpPost]
        public async Task<IActionResult> AddDrinkAsync([FromBody] Drink drink)
        {
            if (drink == null)
            {
                return BadRequest("Drink cannot be null.");
            }
            await _drinkRepository.AddDrinkAsync(drink);
            return CreatedAtAction(nameof(GetDrinkByIdAsync), new { id = drink.Id }, drink);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDrinkAsync(int id, [FromBody] Drink drink)
        {
            if (drink == null || drink.Id != id)
            {
                return BadRequest("Drink data is invalid.");
            }
            var existingDrink = await _drinkRepository.GetDrinkByIdAsync(id);
            if (existingDrink == null)
            {
                return NotFound();
            }
            await _drinkRepository.UpdateDrinkAsync(drink);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrinkAsync(int id)
        {
            var existingDrink = await _drinkRepository.GetDrinkByIdAsync(id);
            if (existingDrink == null)
            {
                return NotFound();
            }
            await _drinkRepository.DeleteDrinkAsync(id);
            return NoContent();
        }
        
    }
}

