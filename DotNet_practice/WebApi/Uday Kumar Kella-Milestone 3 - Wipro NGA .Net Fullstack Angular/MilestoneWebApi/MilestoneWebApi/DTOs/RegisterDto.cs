using System.ComponentModel.DataAnnotations;

namespace MilestoneWebApi.DTOs
{
    public class RegisterDto
    {
        [Required]
        [MinLength(5)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MinLength(8)]
        public string Password { get; set; } = string.Empty;
    }
}