namespace FinanceBilling.Core.DTOs.User;

public class UserDto
{
    public int UserId { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? Role { get; set; }

    public bool IsApproved { get; set; }
}