using FinanceBilling.MVC.Services;
using FinanceBilling.MVC.ViewModels.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FinanceBilling.MVC.Controllers;

[Authorize]
public class DashboardController : Controller
{
    private readonly ApiService _apiService;

    public DashboardController(ApiService apiService)
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
                "api/dashboard/summary",
                token);

        if (!response.IsSuccessStatusCode)
        {
            return View(
                new DashboardSummaryViewModel());
        }

        var json =
            await response.Content
                .ReadAsStringAsync();

        var model =
            JsonSerializer.Deserialize<
                DashboardSummaryViewModel>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        return View(
            model ??
            new DashboardSummaryViewModel());
    }
}