using Microsoft.EntityFrameworkCore;
using EfCoreCompiledModelNaming;

using var context = new LanguageDbContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

context.Sentences.Add(new Sentence { Text = "Hello, World!" });

context.SaveChanges();

var sentences = context.Sentences.ToList();

foreach (var sentence in sentences)
{
    Console.WriteLine(sentence.Text);
}


namespace EfCoreCompiledModelNaming
{
    public class Sentence
    {
        public int Id { get; set; }

        public required string Text { get; set; }

        public AnotherNamespace.Sentence SentenceType { get; set; }
    }

    public class LanguageDbContext : DbContext
    {
        public DbSet<Sentence> Sentences { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlite("DataSource=temp.db");
        }
    }
}

namespace AnotherNamespace
{
    public enum Sentence
    {
        None
    }
}
