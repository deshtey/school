using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Infrastructure.Persistence.Configurations;
class ParentEntityConfiguration
    : IEntityTypeConfiguration<Parent>
{
    public void Configure(EntityTypeBuilder<Parent> parentConfiguration)
    {
        parentConfiguration.ToTable("parents");

        //parentConfiguration
        //    .OwnsOne(o => o.ParentAddress);

        parentConfiguration.Property(s => s.Name)
            .HasColumnName("name")
            .HasMaxLength(20);

        parentConfiguration.Property(s => s.Email)
         .HasColumnName("email")
         .HasMaxLength(100);
        parentConfiguration.Property(s => s.Phone)
         .HasColumnName("phone")
         .HasMaxLength(20);
 
    }
}