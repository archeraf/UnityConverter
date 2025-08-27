using Microsoft.AspNetCore.Mvc;
using UnityConverter.Application.Interface;

namespace UnityConverter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;
        public ConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        //TODO: Fix fromUnit and toUnit captions, 
        [HttpGet("convert/{value}/{fromUnit}/{toUnit}")]
        public IActionResult Convert(double value, string fromUnit, string toUnit)
        {
            try
            {
                var result = _conversionService.Convert(value, fromUnit, toUnit);
                return Ok(new { Result = result, FromUnit = fromUnit, ToUnit = toUnit });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "Internal server error: " + ex.Message });
            }
        }
    }
}
