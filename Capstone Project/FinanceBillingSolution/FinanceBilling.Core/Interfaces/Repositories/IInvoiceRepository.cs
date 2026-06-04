using FinanceBilling.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.Interfaces.Repositories
{
    public interface IInvoiceRepository
    {
        Task<Invoice?> GetByIdAsync(int invoiceId);
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<IEnumerable<Invoice>> GetByClientIdAsync(int clientId);
        Task AddAsync(Invoice invoice);

        Task UpdateAsync(Invoice invoice);
    }
}
