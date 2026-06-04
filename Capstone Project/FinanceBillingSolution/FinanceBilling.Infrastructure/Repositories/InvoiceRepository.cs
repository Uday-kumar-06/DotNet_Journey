using FinanceBilling.Core.Entities;
using FinanceBilling.Core.Interfaces.Repositories;
using FinanceBilling.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceBilling.Infrastructure.Repositories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly FinanceBillingDbContext _context;

    public InvoiceRepository(FinanceBillingDbContext context)
    {
        _context = context;
    }

    public async Task<Invoice?> GetByIdAsync(int invoiceId)
    {
        return await _context.Invoices
            .FirstOrDefaultAsync(x => x.InvoiceId == invoiceId);
    }

    public async Task<IEnumerable<Invoice>> GetAllAsync()
    {
        return await _context.Invoices
            .Include(x => x.ClientUser)
            .ToListAsync();
    }

    public async Task<IEnumerable<Invoice>> GetByClientIdAsync(int clientId)
    {
        return await _context.Invoices
            .Include(x => x.ClientUser)
            .Where(x => x.ClientUserId == clientId)
            .ToListAsync();
    }

    public async Task AddAsync(Invoice invoice)
    {
        await _context.Invoices.AddAsync(invoice);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Invoice invoice)
    {
        _context.Invoices.Update(invoice);
        await _context.SaveChangesAsync();
    }
}