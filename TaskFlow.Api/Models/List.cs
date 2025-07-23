using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Api.Models
{
    public class List
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        public int Position { get; set; } = 0;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // Foreign key
        public int BoardId { get; set; }
        
        // Navigation properties
        public Board Board { get; set; } = null!;
        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
