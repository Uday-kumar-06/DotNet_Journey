namespace FinanceBilling.Core.DTOs.User;

public class ApproveUserDto
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string? Remarks { get; set; }
}