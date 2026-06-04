using FinanceBilling.Core.DTOs.Payment;
using FinanceBilling.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinanceBilling.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(
            IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments =
                await _paymentService.GetAllAsync();

            return Ok(payments);
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpPost]
        public async Task<IActionResult> AddPayment(
            CreatePaymentDto dto)
        {
            var userId =
                int.Parse(
                    User.FindFirst(
                        ClaimTypes.NameIdentifier)!
                        .Value);

            await _paymentService.AddPaymentAsync(
                userId,
                dto);

            return Ok();
        }
    }
}