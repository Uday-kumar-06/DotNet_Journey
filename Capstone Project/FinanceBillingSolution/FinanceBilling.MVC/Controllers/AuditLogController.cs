using System.Text.Json;
using FinanceBilling.MVC.Services;
using FinanceBilling.MVC.ViewModels.AuditLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBilling.MVC.Controllers;

[Authorize(Roles = "Admin")]
public class AuditLogController : Controller
{
    private readonly ApiService _apiService;

    public AuditLogController(ApiService apiService)
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
                "api/auditlogs",
                token);

        if (!response.IsSuccessStatusCode)
        {
            return View(
                new List<AuditLogViewModel>());
        }

        var json =
            await response.Content
                .ReadAsStringAsync();

        var logs =
            JsonSerializer.Deserialize<
                List<AuditLogViewModel>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        return View(
            logs ??
            new List<AuditLogViewModel>());
    }
}