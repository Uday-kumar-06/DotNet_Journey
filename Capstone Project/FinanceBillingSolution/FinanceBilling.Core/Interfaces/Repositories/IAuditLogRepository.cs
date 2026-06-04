using FinanceBilling.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.Interfaces.Repositories
{
    public interface IAuditLogRepository
    {
        Task AddAsync(AuditLog auditLog);

        Task<IEnumerable<AuditLog>> GetAllAsync();
    }
}
