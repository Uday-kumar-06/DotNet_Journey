using System.ComponentModel.DataAnnotations;

namespace Student_Registration_Search_System_AJAX.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
