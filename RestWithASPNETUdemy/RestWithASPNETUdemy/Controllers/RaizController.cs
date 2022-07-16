using Microsoft.AspNetCore.Mvc;


namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class RaizController : ControllerBase
{

    private readonly ILogger<RaizController> _logger;
    

    public RaizController(ILogger<RaizController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Raiz Quadrada")]
    public IActionResult Get(string firstNumber)
    {
        if (IsNumeric(firstNumber))
        {
            var raiz = Math.Sqrt((double)convertToDecimal(firstNumber));
            return Ok(raiz.ToString());
        }
       
        return BadRequest("Invalid Input");
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(
            strNumber, 
            System.Globalization.NumberStyles.Any, 
            System.Globalization.NumberFormatInfo.InvariantInfo, 
            out number);
        
        return isNumber;
        
        throw new NotImplementedException();
    }

    private decimal convertToDecimal(string strNumber)
    {
        decimal decimalValue;
        if(decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }
        return 0;
    }
}
