using FinanceBilling.Core.Entities;
using FinanceBilling.Core.Interfaces.Repositories;
using FinanceBilling.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceBilling.Infrastructure.Repositories;

public class AuditLogRepository : IAuditLogRepository
{
    private readonly FinanceBillingDbContext _context;

    public AuditLogRepository(FinanceBillingDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AuditLog auditLog)
    {
        await _context.AuditLogs.AddAsync(auditLog);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<AuditLog>> GetAllAsync()
    {
        return await _context.AuditLogs
            .Include(x => x.User)
            .OrderByDescending(x => x.ChangedAt)
            .ToListAsync();
    }
}