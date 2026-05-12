using System.ComponentModel.DataAnnotations;

namespace FirstMVCWebApp.Dto
{
    public record ProductResponseDto(
     [Required]
     int Id,
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
