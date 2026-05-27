using System.ComponentModel.DataAnnotations;
using OnlineBookStore.Validation;

namespace OnlineBookStore.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
        [IsbnValidation]
        public string ISBN { get; set; }
        [PriceValidation]
        public decimal Price { get; set; }
    }
}