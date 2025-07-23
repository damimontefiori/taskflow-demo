namespace TaskFlow.Api.Models
{
    public class CardMember
    {
        public int Id { get; set; }
        
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
        
        // Foreign keys
        public int CardId { get; set; }
        public int UserId { get; set; }
        
        // Navigation properties
        public Card Card { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
