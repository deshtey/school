using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Library;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class LibraryMemberConfiguration : IEntityTypeConfiguration<LibraryMember>
    {
        public void Configure(EntityTypeBuilder<LibraryMember> libraryMemberConfiguration)
        {
            libraryMemberConfiguration.ToTable("library_members", "library");

            libraryMemberConfiguration.Property(s => s.MemberId)
                .HasColumnName("member_id")
                .HasMaxLength(50);
        }
    }
}