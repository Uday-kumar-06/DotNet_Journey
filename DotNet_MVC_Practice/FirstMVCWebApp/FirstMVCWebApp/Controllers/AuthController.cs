using FirstMVCWebApp.Data;
using FirstMVCWebApp.Dto;
using FirstMVCWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FirstMVCWebApp.Controllers
{
    
    public class AuthController(AppDbContext dbContext) : Controller
    {
        //private readonly AppDbContext _dbContext;

        //public AuthController(AppDbContext dbContext)
        //{
        //    this._dbContext = dbContext;
        //}
        
        public IActionResult Login()
        {
            
            ViewBag.SuccessMessage = TempData["successMessage"];
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> CreateUser(UserRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Please fill in all required fields.";
                return View("Register");
            }
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (existingUser == null)
            {
                var user = new User
                {
                    UserName = dto.UserName,
                    Email = dto.Email,
                    Password = dto.Password
                };
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                ViewBag.ErrorMessage = "Email already exists. Please use a different email.";
                return View("Register");
            }
            TempData["successMessage"] = "User created successfully. Please log in.";
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> LoginUser(UserLoginResponseDto user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Please fill in all required fields.";
                return View("Login");
            }
            var isUserExists = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (isUserExists == null)
            {
                ViewBag.ErrorMessage = "Invalid email, User with Email Doesnot Exsist..";
                return View("Login");
            }
            else
            {
                if (isUserExists.Password == user.Password)
                {
                    var token = GenerateJwtToken(user);

                    Response.Cookies.Append("jwt_key", token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddHours(0.5)
                    });
                    TempData["successMessage"] = "Login successful. Welcome back!";
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid password. Please try again.";
                    return View("Login");
                }
            }

        }

        private string GenerateJwtToken(UserLoginResponseDto user)
        {
            // Implement JWT token generation logic here
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("PvViWpihSgrkBV73wzv230lWKdpaBBL8gxK1hyLF9Ye");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                }),
                Expires = DateTime.UtcNow.AddHours(0.5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtHandler.CreateToken(tokenDescriptor);
            return jwtHandler.WriteToken(token);
        }

        public IActionResult LogoutUser()
        {
            Response.Cookies.Delete("jwt_key");
            TempData["successMessage"] = "Logout successful.";
            return RedirectToAction("Login");
        }
    }
}
