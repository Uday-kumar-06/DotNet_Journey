using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.DTOs
{
    public class AuditLogDto
    {
        public int AuditLogId { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Action { get; set; } = string.Empty;

        public string EntityName { get; set; } = string.Empty;

        public int? EntityId { get; set; }

        public string? Details { get; set; }

        public DateTime ChangedAt { get; set; }
    }
}
