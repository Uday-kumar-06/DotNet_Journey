using FinanceBilling.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetByIdAsync(int paymentId);

        Task<IEnumerable<Payment>> GetByInvoiceIdAsync(int invoiceId);

        Task AddAsync(Payment payment);
        Task<IEnumerable<Payment>> GetAllAsync();
    }
}
