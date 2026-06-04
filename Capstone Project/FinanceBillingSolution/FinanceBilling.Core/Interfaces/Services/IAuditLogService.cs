using FinanceBilling.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.Interfaces.Services
{
    public interface IAuditLogService
    {
        Task<IEnumerable<AuditLogDto>> GetAllAsync();
    }
}
