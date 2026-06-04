using System.Text.Json;
using FinanceBilling.MVC.Services;
using FinanceBilling.MVC.ViewModels.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBilling.MVC.Controllers;

[Authorize]
public class PaymentController : Controller
{
    private readonly ApiService _apiService;

    public PaymentController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var token =
            User.Claims
                .FirstOrDefault(
                    x => x.Type == "JwtToken")
                ?.Value;

        var response =
            await _apiService.GetAsync(
                "api/payments",
                token);

        if (!response.IsSuccessStatusCode)
        {
            return View(
                new List<PaymentViewModel>());
        }

        var json =
            await response.Content.ReadAsStringAsync();

        var payments =
            JsonSerializer.Deserialize<
                List<PaymentViewModel>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        return View(
            payments ??
            new List<PaymentViewModel>());
    }

    [HttpPost]
    [Authorize(Roles = "Manager")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [FromBody] CreatePaymentViewModel model)
    {
        var token =
            User.Claims
                .FirstOrDefault(
                    x => x.Type == "JwtToken")
                ?.Value;

        var response =
            await _apiService.PostAsync(
                "api/payments",
                model,
                token);

        if (!response.IsSuccessStatusCode)
        {
            return Json(new
            {
                success = false,
                message = "Payment failed."
            });
        }

        return Json(new
        {
            success = true,
            message = "Payment recorded."
        });
    }
}