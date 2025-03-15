using BookSummary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookSummary.Infrastructure.DataAccess
{
    public class DayConfiguration : IEntityTypeConfiguration<Day>
    {
        public void Configure(EntityTypeBuilder<Day> builder)
        {
            builder.ToTable("Days");
            builder.HasKey(d => d.DayId);
            builder.Property(d => d.Date).IsRequired();
            builder.Property(d => d.Summary).HasMaxLength(500);
            builder.HasOne(d => d.Subject).WithMany(s => s.Days).HasForeignKey(d => d.SubjectId);
        }
    }
}
