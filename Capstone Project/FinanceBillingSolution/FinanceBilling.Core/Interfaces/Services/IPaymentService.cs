using FinanceBilling.Core.DTOs.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.Interfaces.Services
{
    public interface IPaymentService
    {
        Task AddPaymentAsync(int userId, CreatePaymentDto dto);

        Task<IEnumerable<PaymentDto>> GetInvoicePaymentsAsync(
            int invoiceId);

        Task<IEnumerable<PaymentDto>> GetAllAsync();
    }
}
