using BookSummary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookSummary.Infrastructure.DataAccess
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");
            builder.HasKey(s => s.SubjectId);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
            builder.Property(s => s.SchoolLevel).HasMaxLength(50);
            builder.Property(s => s.Grade).HasMaxLength(50);
        }
    }
}
