using Microsoft.AspNetCore.Mvc;
using SecureBankingAPI.Data;
using SecureBankingAPI.Models;
using SecureBankingAPI.Security;
using SecureBankingAPI.Services;

namespace SecureBankingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordService _passwordService;
        private readonly EncryptionService _encryptionService;
        private readonly HmacService _hmacService;

        public AuthController(
            ApplicationDbContext context,
            PasswordService passwordService,
            EncryptionService encryptionService,
            HmacService hmacService)
        {
            _context = context;
            _passwordService = passwordService;
            _encryptionService = encryptionService;
            _hmacService = hmacService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            if (!InputValidation.IsSafe(dto.Username))
            {
                return BadRequest("Invalid Input");
            }

            User user = new User
            {
                Username = dto.Username,

                Email = dto.Email,

                PasswordHash =
                _passwordService.HashPassword(dto.Password),

                CreditCardNumber =
                _encryptionService.Encrypt(
                    dto.CreditCardNumber),

                HmacSignature =
                _hmacService.GenerateHmac(
                    dto.CreditCardNumber)
            };

            _context.Users.Add(user);

            _context.SaveChanges();

            return Ok("User Registered Successfully");
        }
    }
}