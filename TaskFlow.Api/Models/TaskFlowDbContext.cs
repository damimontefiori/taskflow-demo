using Microsoft.EntityFrameworkCore;

namespace TaskFlow.Api.Models
{
    public class TaskFlowDbContext : DbContext
    {
        public TaskFlowDbContext(DbContextOptions<TaskFlowDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CardMember> CardMembers { get; set; }
        public DbSet<BoardMember> BoardMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User configurations
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // User 1:N Board (Owner relationship)
            modelBuilder.Entity<Board>()
                .HasOne(b => b.User)
                .WithMany(u => u.Boards)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete of boards when user is deleted

            // Board 1:N List
            modelBuilder.Entity<List>()
                .HasOne(l => l.Board)
                .WithMany(b => b.Lists)
                .HasForeignKey(l => l.BoardId)
                .OnDelete(DeleteBehavior.Cascade);

            // List 1:N Card
            modelBuilder.Entity<Card>()
                .HasOne(c => c.List)
                .WithMany(l => l.Cards)
                .HasForeignKey(c => c.ListId)
                .OnDelete(DeleteBehavior.Cascade);

            // Card 1:N Comment
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Card)
                .WithMany(card => card.Comments)
                .HasForeignKey(c => c.CardId)
                .OnDelete(DeleteBehavior.Cascade);

            // User 1:N Comment
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Many-to-Many: Card and User (Card Members)
            modelBuilder.Entity<CardMember>()
                .HasOne(cm => cm.Card)
                .WithMany(c => c.CardMembers)
                .HasForeignKey(cm => cm.CardId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CardMember>()
                .HasOne(cm => cm.User)
                .WithMany()
                .HasForeignKey(cm => cm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Unique constraint for CardMember (one user can be assigned to a card only once)
            modelBuilder.Entity<CardMember>()
                .HasIndex(cm => new { cm.CardId, cm.UserId })
                .IsUnique();

            // Many-to-Many: Board and User (Board Members)
            modelBuilder.Entity<BoardMember>()
                .HasOne(bm => bm.Board)
                .WithMany()
                .HasForeignKey(bm => bm.BoardId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BoardMember>()
                .HasOne(bm => bm.User)
                .WithMany()
                .HasForeignKey(bm => bm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Unique constraint for BoardMember (one user can be a member of a board only once)
            modelBuilder.Entity<BoardMember>()
                .HasIndex(bm => new { bm.BoardId, bm.UserId })
                .IsUnique();

            // Configure default values and constraints
            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Board>()
                .Property(b => b.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<List>()
                .Property(l => l.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Card>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Comment>()
                .Property(c => c.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}