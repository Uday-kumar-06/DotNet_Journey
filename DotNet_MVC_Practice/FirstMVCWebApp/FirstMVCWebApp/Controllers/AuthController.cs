using FirstMVCWebApp.Data;
using FirstMVCWebApp.Dto;
using FirstMVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCWebApp.Controllers
{
    public class AuthController(AppDbContext dbContext): Controller
    {
        //private readonly AppDbContext _dbContext;

        //public AuthController(AppDbContext dbContext)
        //{
        //    this._dbContext = dbContext;
        //}

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> CreateUser(UserRequestDto dto)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (existingUser == null){ 
                var user = new User
                {
                    UserName = dto.UserName,
                    Email = dto.Email,
                    Password = dto.Password
                };
                dbContext.Users.Add(user);
                await dbContext.SaveChangesAsync();
            }
            //else
            //{

            //}
            return RedirectToAction("Login");
        }
    }
}
