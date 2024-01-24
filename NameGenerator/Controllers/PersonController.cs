using Microsoft.AspNetCore.Mvc;
using MyApplication.Core.Logging;
using NameGenerator.Core.Interfaces;
using NameGenerator.Core.Services;

namespace NameGenerator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonGeneratorService _personGeneratorService;
        private readonly LoggerService _loggerService;

        public PersonController(IPersonGeneratorService personGeneratorService, LoggerService loggerService)
        {
            _personGeneratorService = personGeneratorService;
            _loggerService = loggerService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GeneratePersons(int count)
        {
            try
            {
                string? ipAddress = GetClientIpAddress();
                await _personGeneratorService.GenerateAndSavePersons(count, ipAddress);
            }
            catch (Exception ex)
            {                
                _loggerService.LogError(ex, "Wystąpił błąd podczas generowania osób");
                return StatusCode(500, "Wystąpił błąd podczas przetwarzania żądania");
            }
            
            return Ok("People generated, saved in Database.");
        }

        private string? GetClientIpAddress()
        {
            var forwardedHeader = Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (!string.IsNullOrEmpty(forwardedHeader))
            {
                return forwardedHeader.Split(',').FirstOrDefault();
            }

            return Request.HttpContext.Connection.RemoteIpAddress?.ToString();
        }
    }
}
