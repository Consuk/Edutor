using BookSummary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookSummary.Infrastructure.DataAccess
{
    public class BookSummaryContext : DbContext
    {
        public DbSet<Content> Contents { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }

        public BookSummaryContext(DbContextOptions<BookSummaryContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add Fluent API configurations here
            modelBuilder.ApplyConfiguration(new ContentConfiguration());
            modelBuilder.ApplyConfiguration(new DayConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
