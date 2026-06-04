using FinanceBilling.Core.Entities;
using FinanceBilling.Core.Interfaces.Repositories;
using FinanceBilling.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceBilling.Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly FinanceBillingDbContext _context;

    public PaymentRepository(FinanceBillingDbContext context)
    {
        _context = context;
    }

    public async Task<Payment?> GetByIdAsync(int paymentId)
    {
        return await _context.Payments
            .FirstOrDefaultAsync(x => x.PaymentId == paymentId);
    }

    public async Task<IEnumerable<Payment>> GetByInvoiceIdAsync(int invoiceId)
    {
        return await _context.Payments
            .Where(x => x.InvoiceId == invoiceId)
            .ToListAsync();
    }

    public async Task AddAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Payment>> GetAllAsync()
    {
        return await _context.Payments
            .ToListAsync();
    }
}