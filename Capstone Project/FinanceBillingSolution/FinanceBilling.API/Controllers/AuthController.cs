using FinanceBilling.Core.DTOs.Auth;
using FinanceBilling.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBilling.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(
            IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegisterRequestDto dto)
        {
            await _authService.RegisterAsync(dto);

            return Ok(
                "Registration submitted. Awaiting approval.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginRequestDto dto)
        {
            var result =
                await _authService.LoginAsync(dto);

            if (result == null)
                return Unauthorized();

            return Ok(result);
        }
    }
}
