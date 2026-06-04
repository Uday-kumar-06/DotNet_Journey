namespace FinanceBilling.Core.Entities;

public class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public int? RoleId { get; set; }

    public bool IsApproved { get; set; }

    public bool IsActive { get; set; }

    public Role? Role { get; set; }

    public ICollection<Invoice> ClientInvoices { get; set; }
        = new List<Invoice>();

    public ICollection<Invoice> ManagedInvoices { get; set; }
        = new List<Invoice>();

    public ICollection<AuditLog> AuditLogs { get; set; }
        = new List<AuditLog>();

    public DateTime CreatedAt { get; set; }

    public DateTime? LastLoginAt { get; set; }
}