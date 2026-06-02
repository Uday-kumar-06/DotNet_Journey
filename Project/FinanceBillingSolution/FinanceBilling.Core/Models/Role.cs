using System.ComponentModel.DataAnnotations;

namespace FinanceBilling.Core.Models;

public class Role
{
    [Key]
    public int RoleId { get; set; }

    [Required]
    [StringLength(50)]
    public string RoleName { get; set; } = string.Empty;

    public ICollection<User>? Users { get; set; }
}