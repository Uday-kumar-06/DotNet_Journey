using System.Security.Claims;
using System.Text.Json;
using FinanceBilling.MVC.Services;
using FinanceBilling.MVC.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBilling.MVC.Controllers;

public class AccountController : Controller
{
    private readonly ApiService _apiService;

    public AccountController(ApiService apiService)
    {
        _apiService = apiService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(
        RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var response =
            await _apiService.PostAsync(
                "api/auth/register",
                model);

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError(
                "",
                "Registration failed.");

            return View(model);
        }

        TempData["Success"] =
            "Registration submitted. Awaiting approval.";

        return RedirectToAction(nameof(Login));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(
        LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var response =
            await _apiService.PostAsync(
                "api/auth/login",
                model);

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError(
                "",
                "Invalid login credentials.");

            return View(model);
        }

        var json =
            await response.Content.ReadAsStringAsync();

        var result =
            JsonSerializer.Deserialize<LoginResponseViewModel>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        if (result == null)
        {
            ModelState.AddModelError(
                "",
                "Login failed.");

            return View(model);
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, result.Username),
            new(ClaimTypes.Role, result.Role),
            new("JwtToken", result.Token)
        };

        var identity =
            new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

        var principal =
            new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal);

        return RedirectToAction(
            "Index",
            "Dashboard");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction(nameof(Login));
    }
}