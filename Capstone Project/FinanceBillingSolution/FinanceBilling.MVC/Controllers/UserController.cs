using System.Text;
using System.Text.Json;
using FinanceBilling.MVC.Services;
using FinanceBilling.MVC.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBilling.MVC.Controllers;

[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly ApiService _apiService;

    public UserController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetPendingUsers()
    {
        var token =
            User.Claims
                .FirstOrDefault(
                    x => x.Type == "JwtToken")
                ?.Value;

        var response =
            await _apiService.GetAsync(
                "api/users/pending",
                token);

        if (!response.IsSuccessStatusCode)
        {
            return Json(
                new List<PendingUserViewModel>());
        }

        var json =
            await response.Content
                .ReadAsStringAsync();

        return Content(
            json,
            "application/json");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Approve(
        [FromBody]
        ApproveUserViewModel model)
    {
        var token =
            User.Claims
                .FirstOrDefault(
                    x => x.Type == "JwtToken")
                ?.Value;

        var response =
            await _apiService.PostAsync(
                "api/users/approve",
                model,
                token);

        if (!response.IsSuccessStatusCode)
        {
            return Json(new
            {
                success = false,
                message = "Approval failed."
            });
        }

        return Json(new
        {
            success = true,
            message = "User approved."
        });
    }
}