using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Bio { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}