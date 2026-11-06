using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


public class AppDbContext : DbContext
{
    public DbSet<Stack> Stacks => Set<Stack>();
    public DbSet<Flashcard> Flashcards => Set<Flashcard>();
    public DbSet<StudySession> StudySessions => Set<StudySession>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        optionsBuilder.UseSqlServer(config.GetConnectionString("Flashcards"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stack>(entity =>
        {
            entity.ToTable("Stack");
            entity.Property(s => s.Name).HasMaxLength(50);
            entity.HasIndex(s => s.Name).IsUnique();
        });

        modelBuilder.Entity<Flashcard>(entity =>
        {
            entity.ToTable("Flashcard");
            entity.Property(f => f.Front).HasMaxLength(500);
            entity.Property(f => f.Back).HasMaxLength(500);
        });

        modelBuilder.Entity<StudySession>(entity =>
        {
            entity.ToTable("StudySession");
        });
    }
}