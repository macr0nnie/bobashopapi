using Microsoft.AspNetCore.Mvc;
using BobaShopApi.Repositories;
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