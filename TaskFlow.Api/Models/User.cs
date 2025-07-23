using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public ICollection<Board> Boards { get; set; } = new List<Board>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<CardMember> CardMemberships { get; set; } = new List<CardMember>();
        public ICollection<BoardMember> BoardMemberships { get; set; } = new List<BoardMember>();
    }
}
