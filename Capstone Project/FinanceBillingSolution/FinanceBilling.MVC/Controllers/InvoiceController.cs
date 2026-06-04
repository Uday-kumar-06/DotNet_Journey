using FinanceBilling.MVC.Services;
using FinanceBilling.MVC.ViewModels.Invoice;
using FinanceBilling.MVC.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FinanceBilling.MVC.Controllers;

[Authorize]
public class InvoiceController : Controller
{
    private readonly ApiService _apiService;

    public InvoiceController(ApiService apiService)
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
                "api/invoices",
                token);

        if (!response.IsSuccessStatusCode)
        {
            return View(
                new List<InvoiceViewModel>());
        }

        var json =
            await response.Content.ReadAsStringAsync();

        var invoices =
            JsonSerializer.Deserialize<
                List<InvoiceViewModel>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        return View(
            invoices ??
            new List<InvoiceViewModel>());
    }

    [HttpPost]
    [Authorize(Roles = "Manager,Admin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
    [FromBody] CreateInvoiceViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return Json(new
            {
                success = false,
                message = "Invalid invoice data."
            });
        }

        var token =
            User.Claims
                .FirstOrDefault(
                    x => x.Type == "JwtToken")
                ?.Value;

        var response =
            await _apiService.PostAsync(
                "api/invoices",
                model,
                token);

        if (!response.IsSuccessStatusCode)
        {
            return Json(new
            {
                success = false,
                message = "Failed to create invoice."
            });
        }

        return Json(new
        {
            success = true,
            message = "Invoice created successfully."
        });
    }

    [HttpGet]
    [Authorize(Roles = "Manager,Admin")]
    public async Task<IActionResult> GetClients()
    {
        var token =
            User.Claims
                .FirstOrDefault(x => x.Type == "JwtToken")
                ?.Value;

        var response =
            await _apiService.GetAsync(
                "api/users/clients",
                token);

        if (!response.IsSuccessStatusCode)
        {
            return Json(new List<object>());
        }

        var json =
            await response.Content.ReadAsStringAsync();

        var clients =
            JsonSerializer.Deserialize<
                List<ClientLookupViewModel>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        return Json(clients);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllInvoices()
    {
        var token =
            User.Claims
                .FirstOrDefault(
                    x => x.Type == "JwtToken")
                ?.Value;

        var response =
            await _apiService.GetAsync(
                "api/invoices",
                token);

        if (!response.IsSuccessStatusCode)
        {
            return Json(new List<object>());
        }

        var json =
            await response.Content.ReadAsStringAsync();

        return Content(
            json,
            "application/json");
    }
}