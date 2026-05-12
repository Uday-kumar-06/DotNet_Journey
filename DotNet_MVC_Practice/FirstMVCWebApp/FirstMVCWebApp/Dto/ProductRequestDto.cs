using System.ComponentModel.DataAnnotations;

namespace FirstMVCWebApp.Dto
{
    public record ProductRequestDto(
        [Required]
        string ProductName,
        [Required]
        string Description,
        [Required]
        decimal Price,
        [Required]
        string Color
    );
}
