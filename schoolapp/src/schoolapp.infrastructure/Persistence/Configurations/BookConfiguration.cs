using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Library;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> bookConfiguration)
        {
            bookConfiguration.ToTable("books", "library");

            bookConfiguration.Property(s => s.Title)
                .HasColumnName("title")
                .HasMaxLength(200);

            bookConfiguration.Property(s => s.Author)
                .HasColumnName("author")
                .HasMaxLength(100);

            bookConfiguration.Property(s => s.ISBN)
                .HasColumnName("isbn")
                .HasMaxLength(20);

            bookConfiguration.Property(s => s.Edition)
                .HasColumnName("edition")
                .HasMaxLength(20);

            bookConfiguration.Property(s => s.Publisher)
                .HasColumnName("publisher")
                .HasMaxLength(100);

            bookConfiguration.Property(s => s.Location)
                .HasColumnName("location")
                .HasMaxLength(100);
        }
    }
}