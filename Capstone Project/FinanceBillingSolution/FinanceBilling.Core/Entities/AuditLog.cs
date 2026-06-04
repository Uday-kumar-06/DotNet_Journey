namespace FinanceBilling.Core.Entities;

public class AuditLog
{
    public int AuditLogId { get; set; }

    public int UserId { get; set; }

    public string Action { get; set; } = string.Empty;

    public string EntityName { get; set; } = string.Empty;

    public int? EntityId { get; set; }

    public string? Details { get; set; }

    public DateTime ChangedAt { get; set; }
    public User User { get; set; } = null!;
}