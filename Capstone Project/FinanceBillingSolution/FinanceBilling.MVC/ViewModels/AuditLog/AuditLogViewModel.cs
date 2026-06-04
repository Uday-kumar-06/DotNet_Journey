using Microsoft.AspNetCore.Mvc;

namespace FinanceBilling.MVC.ViewModels.AuditLog
{
    public class AuditLogViewModel
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
