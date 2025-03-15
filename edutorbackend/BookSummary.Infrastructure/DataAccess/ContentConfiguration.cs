using BookSummary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookSummary.Infrastructure.DataAccess
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.ToTable("Contents");
            builder.HasKey(c => c.ContentId);
            builder.Property(c => c.Title).IsRequired().HasMaxLength(200);
            builder
                .HasOne(c => c.Subject)
                .WithMany(s => s.Contents)
                .HasForeignKey(c => c.SubjectId);
        }
    }
}
