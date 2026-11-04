using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Stack> Stacks => Set<Stack>();
    public DbSet<Flashcard> Flashcards => Set<Flashcard>();
    public DbSet<StudySession> StudySessions => Set<StudySession>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stack>().ToTable("Stack");
        modelBuilder.Entity<Flashcard>().ToTable("Flashcard");
        modelBuilder.Entity<StudySession>().ToTable("StudySession");
    }
}