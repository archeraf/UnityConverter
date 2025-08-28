using Microsoft.AspNetCore.Mvc;
using UnityConverter.Application.Interface;

namespace UnityConverter.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1")]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;
        public ConversionController(IConversionService conversionService)
        {
            _conversionService = conversionService;
        }


        [HttpGet("convert/{value}/{unitType}/{fromUnit}/{toUnit}")]
        public IActionResult Convert(double value, int unitType, int fromUnit, int toUnit)
        {
            try
            {
                var result = _conversionService.Convert(value,unitType, fromUnit, toUnit);
                return Ok(new { Result = result.ToString("N"), FromUnit = fromUnit, ToUnit = toUnit });
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
