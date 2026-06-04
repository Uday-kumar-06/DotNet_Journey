using FinanceBilling.Core.DTOs.Invoice;
using FinanceBilling.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBilling.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoicesController(
            IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(
            CreateInvoiceDto dto)
        {
            var managerId =
                int.Parse(
                    User.FindFirst(
                        System.Security.Claims.ClaimTypes
                            .NameIdentifier)!
                        .Value);

            await _invoiceService
                .CreateInvoiceAsync(
                    managerId,
                    dto);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoices =
                await _invoiceService.GetAllAsync();

            return Ok(invoices);
        }
    }
}
