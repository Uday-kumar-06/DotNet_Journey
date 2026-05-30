using System.ComponentModel.DataAnnotations;

namespace MilestoneWebApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public List<Note>? Notes { get; set; }
    }
}