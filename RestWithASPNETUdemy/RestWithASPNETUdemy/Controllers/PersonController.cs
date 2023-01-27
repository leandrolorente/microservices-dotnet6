using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    

    private readonly ILogger<PersonController> _logger;

    private IPersonService _personService;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet]
    public IActionResult Get()
    {            
        return Ok(_personService.FindAll()); 
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var person = _personService.FindByID(id);
        return person == null ? NotFound() : Ok(person); 
    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {       
        return person == null ? BadRequest() : Ok(_personService.Create(person)); 
    }
    
    [HttpPut]
    public IActionResult Put([FromBody] Person person)
    {       
        return person == null ? BadRequest() : Ok(_personService.Update(person)); 
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _personService.Delete(id);
        return NoContent(); 
    }

  

    private decimal ConvertToDecimal(string strNumber)
    {
        decimal number;
        if (decimal.TryParse(strNumber, out number))
            return number;
        return 0;
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber, out number);
        return isNumber;
    }
}
