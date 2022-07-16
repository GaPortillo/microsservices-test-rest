using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class SubtracaoController : ControllerBase
{

    private readonly ILogger<SubtracaoController> _logger;
    

    public SubtracaoController(ILogger<SubtracaoController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Subtração")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sub = convertToDecimal(firstNumber) - convertToDecimal(secondNumber);
            return Ok(sub.ToString());
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
