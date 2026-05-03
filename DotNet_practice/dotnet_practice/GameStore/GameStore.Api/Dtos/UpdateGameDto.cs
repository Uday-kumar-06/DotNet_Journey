using System.ComponentModel.DataAnnotations;
public record UpdateGameDto(
    [Required][StringLength(50)]
    string Name,
    [Required][StringLength(50)]
    string Genre,
    [Range(1,2000)]
    decimal Price,
    DateOnly ReleaseDate
);