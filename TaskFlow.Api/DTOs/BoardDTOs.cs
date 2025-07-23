namespace TaskFlow.Api.DTOs
{
    public class CreateBoardRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int UserId { get; set; }
    }

    public class UpdateBoardRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class BoardResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int ListsCount { get; set; }
    }
}
