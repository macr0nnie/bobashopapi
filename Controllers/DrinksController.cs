using Microsoft.AspNetCore.Mvc;
using BobaShopApi.Services;
using BobaShopApi.Models;

namespace BobaShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinkService _drinkService;
        public DrinksController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllDrinksAsync()
        {
            var drinks = await _drinkService.GetAllDrinksAsync();
            return Ok(drinks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDrinkByIdAsync(int id)
        {
            var drink = await _drinkService.GetDrinkByIdAsync(id);
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
            var createdDrink = await _drinkService.CreateDrinkAsync(drink);
            return CreatedAtAction(nameof(GetDrinkByIdAsync), new { id = createdDrink.Id }, createdDrink);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDrinkAsync(int id, [FromBody] Drink drink)
        {
            if (drink == null || drink.Id != id)
            {
                return BadRequest("Drink data is invalid.");
            }
            var updatedDrink = await _drinkService.UpdateDrinkAsync(id, drink);
            if (updatedDrink == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrinkAsync(int id)
        {
            var success = await _drinkService.DeleteDrinkAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

