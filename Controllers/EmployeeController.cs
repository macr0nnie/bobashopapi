using BobaShopApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace BobaShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private BobaShopContext _context;
        public EmployeeController(BobaShopContext context)
        {
            _context = context;
        }
    
    }

}