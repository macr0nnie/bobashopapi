using Microsoft.AspNetCore.Mvc;
using BobaShopApi.Models;

namespace BobaShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinksController : ControllerBase
    {
        private static List<Drink> Drinks = new List<Drink>
        {
            new Drink { Id = 1, Name = "Classic Milk Tea", Price = 3.50m },
            new Drink { Id = 2, Name = "Taro Milk Tea", Price = 4.00m },
            new Drink { Id = 3, Name = "Matcha Latte", Price = 4.50m },
            new Drink { Id = 4, Name = "Mango Smoothie", Price = 5.00m },
            new Drink { Id = 5, Name = "Strawberry Lemonade", Price = 3.75m },
            new Drink { Id = 6, Name = "Peach Oolong Tea", Price = 4.25m }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Drink>> GetAllDrinks()
        {
            return Ok(Drinks);
        }

        [HttpGet("{id}")]
        public ActionResult<Drink> GetDrinkById(int id)
        {
            var drink = Drinks.FirstOrDefault(d => d.Id == id);
            if (drink == null)
            {
                return NotFound();
            }
            return Ok(drink);
        }
    }
}