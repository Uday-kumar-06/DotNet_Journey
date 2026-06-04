using FinanceBilling.Core.DTOs;
using FinanceBilling.Core.Interfaces.Repositories;
using FinanceBilling.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Infrastructure.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogService(
            IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public async Task<IEnumerable<AuditLogDto>>
            GetAllAsync()
        {
            var logs =
                await _auditLogRepository.GetAllAsync();

            return logs.Select(x =>
                new AuditLogDto
                {
                    AuditLogId = x.AuditLogId,
                    UserId = x.UserId,
                    Username =
                        x.User?.Username ?? "System",

                    Action = x.Action,
                    EntityName = x.EntityName,
                    EntityId = x.EntityId,
                    Details = x.Details,
                    ChangedAt = x.ChangedAt
                });
        }
    }
}
