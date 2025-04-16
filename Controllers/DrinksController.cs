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
     
    }
}

