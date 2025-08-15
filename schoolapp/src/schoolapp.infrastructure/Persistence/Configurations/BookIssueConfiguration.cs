using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Library;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class BookIssueConfiguration : IEntityTypeConfiguration<BookIssue>
    {
        public void Configure(EntityTypeBuilder<BookIssue> bookIssueConfiguration)
        {
            bookIssueConfiguration.ToTable("book_issues", "library");

            bookIssueConfiguration.Property(s => s.Remarks)
                .HasColumnName("remarks")
                .HasMaxLength(500);
        }
    }
}