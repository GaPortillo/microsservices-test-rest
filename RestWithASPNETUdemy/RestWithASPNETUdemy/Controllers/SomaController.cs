using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class SomaController : ControllerBase
{

    private readonly ILogger<SomaController> _logger;
    

    public SomaController(ILogger<SomaController> logger)
    {
        _logger = logger;
    }

    [HttpGet("SOMA")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = convertToDecimal(firstNumber) + convertToDecimal(secondNumber);
            return Ok(sum.ToString());
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
