using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Api.Models
{
    public class Card
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(2000)]
        public string? Description { get; set; }
        
        public int Position { get; set; } = 0;
        
        public DateTime? DueDate { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // Foreign key
        public int ListId { get; set; }
        
        // Navigation properties
        public List List { get; set; } = null!;
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<CardMember> CardMembers { get; set; } = new List<CardMember>();
    }
}
