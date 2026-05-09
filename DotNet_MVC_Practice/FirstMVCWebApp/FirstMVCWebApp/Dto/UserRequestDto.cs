using System.ComponentModel.DataAnnotations;

namespace FirstMVCWebApp.Dto
{
    public record UserRequestDto(
        [Required]
        [StringLength(20, MinimumLength = 3)]
        string UserName,

        [Required]
        [EmailAddress]
        string Email,

        [Required]
        [MinLength(8)]
        string Password
        );
}
