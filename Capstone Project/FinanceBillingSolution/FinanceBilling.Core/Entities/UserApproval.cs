namespace FinanceBilling.Core.Entities;

public class UserApproval
{
    public int ApprovalId { get; set; }

    public int UserId { get; set; }

    public int ApprovedByUserId { get; set; }

    public int AssignedRoleId { get; set; }

    public DateTime ApprovedAt { get; set; }

    public string? Remarks { get; set; }
    public User User { get; set; } = null!;

    public User ApprovedByUser { get; set; } = null!;

    public Role AssignedRole { get; set; } = null!;
}