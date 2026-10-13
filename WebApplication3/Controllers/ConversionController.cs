using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Model;
using WebApplication3.Service;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        public ConversionController(
            IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpPost("convert")]
        public IActionResult Convert(
            [FromBody] ConversionRequst request)
        {
            if (string.IsNullOrWhiteSpace(request.Category) ||
                string.IsNullOrWhiteSpace(request.FromUnit) ||
                string.IsNullOrWhiteSpace(request.ToUnit))
            {
                return BadRequest(new
                {
                    message =
                        "Category, FromUnit and ToUnit are required."
                });
            }

            try
            {
                double result = _conversionService.Convert(
                    request.Value,
                    request.Category,
                    request.FromUnit,
                    request.ToUnit);

                return Ok(new
                {
                    originalValue = request.Value,
                    category = request.Category,
                    fromUnit = request.FromUnit,
                    toUnit = request.ToUnit,
                    convertedValue = result
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }
    }
}
