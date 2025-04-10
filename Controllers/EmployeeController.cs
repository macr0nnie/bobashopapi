using Microsoft.AspNetCore.Mvc;
using bobashopapi.Models;
using bobashopapi.Data;
namespace BobaShopApi;

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