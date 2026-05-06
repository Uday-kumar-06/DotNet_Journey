using System.ComponentModel.DataAnnotations;
public record UpdateGameDto(
    [Required][StringLength(50)]
    string Name,
    [Range(1,50)]
    int GenreId,
    [Range(1,2000)]
    decimal Price,
    DateOnly ReleaseDate
);