using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Library;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> bookCategoryConfiguration)
        {
            bookCategoryConfiguration.ToTable("book_categories", "library");

            bookCategoryConfiguration.Property(s => s.Name)
                .HasColumnName("name")
                .HasMaxLength(100);

            bookCategoryConfiguration.Property(s => s.Description)
                .HasColumnName("description")
                .HasMaxLength(500);
        }
    }
}