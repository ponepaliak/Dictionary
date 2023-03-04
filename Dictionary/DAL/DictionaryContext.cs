using Dictionary.Models;
using Microsoft.EntityFrameworkCore;

namespace Dictionary.DAL
{
    public class DictionaryContext : DbContext
    {
        public DictionaryContext(DbContextOptions<DictionaryContext> options) : base(options) { }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionSet> SessionSets { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WordsPair> WordsPairs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordsPair>()
                .HasOne(c => c.FirstLanguage)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WordsPair>()
                .HasOne(c => c.SecondLanguage)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SessionSet>()
                .HasOne(c => c.WordsPair)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WordsPair>()
                .HasMany(c => c.Tags)
                .WithMany(i => i.WordsPairs)
                .UsingEntity<Dictionary<string, object>>(
                    "WordsPairTag",
                    j => j
                        .HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("WordsPairID")
                        .OnDelete(DeleteBehavior.NoAction),
                    j => j
                        .HasOne<WordsPair>()
                        .WithMany()
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.NoAction),
                    j =>
                    {
                        j.HasKey("TagID", "WordsPairID");
                        j.ToTable("WordsPairTag");
                    }
                );
        }
    }
}
