using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MilestoneWebApi.Data;
using MilestoneWebApi.DTOs;
using MilestoneWebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MilestoneWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(
            ApplicationDbContext context,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _context.Users
                .AnyAsync(x => x.Username == dto.Username))
            {
                return BadRequest(
                    new { message = "Username already exists" });
            }

            var user = new User
            {
                Username = dto.Username,
                PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message =
                "User registered successfully. Please log in."
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x =>
                x.Username == dto.Username);

            if (user == null ||
                !BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    user.PasswordHash))
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.Id.ToString()),

                new Claim(
                    ClaimTypes.Name,
                    user.Username)
            };

            var key =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        _configuration["Jwt:Key"]!));

            var creds =
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

            var expires =
                DateTime.UtcNow.AddHours(1);

            var token =
                new JwtSecurityToken(
                    issuer:
                    _configuration["Jwt:Issuer"],

                    audience:
                    _configuration["Jwt:Audience"],

                    claims: claims,

                    expires: expires,

                    signingCredentials: creds);

            var jwt =
                new JwtSecurityTokenHandler()
                .WriteToken(token);

            return Ok(new
            {
                token = jwt,
                expires_in = 3600,
                user = new
                {
                    username = user.Username
                }
            });
        }
    }
}