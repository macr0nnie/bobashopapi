using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BobaShopApi.Models;
using BobaShopApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BobaShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinksController : ControllerBase
    {
        private readonly BobaShopContext _context;

        public DrinksController(BobaShopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drink>>> GetAllDrinks()
        {
            return await _context.Drinks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Drink>> GetDrinkById(int id)
        {
            var drink = await _context.Drinks.FindAsync(id);
            if (drink == null)
            {
                return NotFound();
            }
            return Ok(drink);
        }

        [HttpPost]
        public async Task<ActionResult<Drink>> CreateDrink([FromBody] Drink newDrink)
        {
            if (newDrink == null || string.IsNullOrEmpty(newDrink.Name) || newDrink.Price <= 0)
            {
                return BadRequest("Invalid drink data.");
            }

            _context.Drinks.Add(newDrink);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDrinkById), new { id = newDrink.Id }, newDrink);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Drink>> UpdateDrink(int id, [FromBody] Drink updatedDrink)
        {
            if (updatedDrink == null || string.IsNullOrEmpty(updatedDrink.Name) || updatedDrink.Price <= 0)
            {
                return BadRequest("Invalid drink data.");
            }

            var existingDrink = await _context.Drinks.FindAsync(id);
            if (existingDrink == null)
            {
                return NotFound();
            }

            existingDrink.Name = updatedDrink.Name;
            existingDrink.Price = updatedDrink.Price;

            await _context.SaveChangesAsync();

            return Ok(existingDrink);
        }
    }
}