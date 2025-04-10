using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BobaShopApi.Models;
using BobaShopApi.Data;
using BobaShopApi.Repositories;

namespace BobaShopApi.Controllers{
[ApiController]
[Route("api/[controller]")]

    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
    
    }
}

