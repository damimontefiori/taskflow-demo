namespace TaskFlow.Api.Models
{
    public class BoardMember
    {
        public int Id { get; set; }
        
        public string Role { get; set; } = "Member"; // Admin, Member
        
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
        
        // Foreign keys
        public int BoardId { get; set; }
        public int UserId { get; set; }
        
        // Navigation properties
        public Board Board { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
