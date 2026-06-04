using FinanceBilling.Core.DTOs.Invoice;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.Interfaces.Services
{
    public interface IInvoiceService
    {
        Task CreateInvoiceAsync(
            int managerId,
            CreateInvoiceDto dto);

        Task<IEnumerable<InvoiceDto>> GetAllAsync();

        Task<IEnumerable<InvoiceDto>> GetClientInvoicesAsync(
            int clientId);
    }
}
