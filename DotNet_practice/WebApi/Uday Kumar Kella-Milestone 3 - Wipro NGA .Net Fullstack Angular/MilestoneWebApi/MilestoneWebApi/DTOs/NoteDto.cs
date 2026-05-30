using System.ComponentModel.DataAnnotations;

namespace MilestoneWebApi.DTOs
{
    public class NoteDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;
    }
}