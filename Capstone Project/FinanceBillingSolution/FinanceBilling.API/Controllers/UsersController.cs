using FinanceBilling.Core.DTOs.User;
using FinanceBilling.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBilling.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(
            IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingUsers()
        {
            var users =
                await _userService.GetPendingUsersAsync();

            return Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("approve")]
        public async Task<IActionResult> Approve(
            ApproveUserDto dto)
        {
            var adminId =
                int.Parse(
                    User.FindFirst(
                        System.Security.Claims.ClaimTypes
                            .NameIdentifier)!
                        .Value);

            await _userService.ApproveUserAsync(
                adminId,
                dto);

            return Ok();
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpGet("clients")]
        public async Task<IActionResult> GetClients()
        {
            var clients =
                await _userService.GetClientsAsync();

            return Ok(clients);
        }


    }
}
