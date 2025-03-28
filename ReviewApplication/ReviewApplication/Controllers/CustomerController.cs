using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using ReviewApplication.Application;
using ReviewApplication.Domain;
using System.Threading.Tasks;

namespace ReviewApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
 
    private readonly ILogger<CustomerController> _logger;
    private readonly CustomerService _customerService;

    public CustomerController(ILogger<CustomerController> logger, CustomerService customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }

    [HttpGet(Name = "GetCustomers")]
    public async Task<IActionResult>  Get()
    {
        _logger.LogInformation("Get customers execution");
        return Ok( await  _customerService.GetCustomers());
        
    }

    [HttpPost(Name = "SaveCustomer")]
    public async Task<Result<Customer>> Save(Customer customer)
    {
        _logger.LogInformation(" Save customer execution");
        return await _customerService.SaveCustomer(customer);

    }
}
