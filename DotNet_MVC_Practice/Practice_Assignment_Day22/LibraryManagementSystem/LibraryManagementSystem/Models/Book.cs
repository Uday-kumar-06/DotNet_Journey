using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        public int AuthorID { get; set; }
        [ForeignKey("AuthorID")]
        public Author Author { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}