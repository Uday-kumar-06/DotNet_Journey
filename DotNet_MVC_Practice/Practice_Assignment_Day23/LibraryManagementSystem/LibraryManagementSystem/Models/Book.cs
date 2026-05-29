using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int AuthorId { get; set; }

        public Author? Author { get; set; }

        public int GenreId { get; set; }

        public Genre? Genre { get; set; }
    }
}