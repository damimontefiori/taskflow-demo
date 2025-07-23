using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Api.Models
{
    public class Board
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string? Description { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // Foreign key
        public int UserId { get; set; }
        
        // Navigation properties
        public User User { get; set; } = null!;
        public ICollection<List> Lists { get; set; } = new List<List>();
        public ICollection<BoardMember> BoardMembers { get; set; } = new List<BoardMember>();
    }
}
