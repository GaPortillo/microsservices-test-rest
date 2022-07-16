using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class MediaController : ControllerBase
{

    private readonly ILogger<MediaController> _logger;
    

    public MediaController(ILogger<MediaController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Media")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var media = (convertToDecimal(firstNumber) + convertToDecimal(secondNumber)) / 2;
        
            return Ok(media.ToString());
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
