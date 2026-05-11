using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstMVCWebApp.Dto
{
    public record UserLoginResponseDto(
        [Required]
        [EmailAddress]
        string Email,
        [Required]
        string Password
        );
}
