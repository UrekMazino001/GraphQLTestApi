using HotChocolateGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace HotChocolateGQL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Author>()
                .HasMany(x => x.Books)
                .WithOne(x => x.Author!)
                .HasForeignKey(x => x.Id);

            builder.Entity<Book>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}
