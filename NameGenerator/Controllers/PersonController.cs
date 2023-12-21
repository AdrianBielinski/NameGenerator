using Microsoft.AspNetCore.Mvc;
using NameGenerator.Core.Interfaces;
using NameGenerator.Core.Services;

namespace NameGenerator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonGeneratorService _personGeneratorService;

        public PersonController(IPersonGeneratorService personGeneratorService)
        {
            _personGeneratorService = personGeneratorService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GeneratePersons(int count)
        {
            string? ipAddress = GetClientIpAddress();
            await _personGeneratorService.GenerateAndSavePersons(count, ipAddress);
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
