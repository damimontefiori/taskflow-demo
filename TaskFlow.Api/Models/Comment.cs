using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(1000)]
        public string Content { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // Foreign keys
        public int CardId { get; set; }
        public int UserId { get; set; }
        
        // Navigation properties
        public Card Card { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
