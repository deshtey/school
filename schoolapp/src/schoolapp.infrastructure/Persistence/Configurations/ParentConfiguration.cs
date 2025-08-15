using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Infrastructure.Persistence.Configurations;
class ParentEntityConfiguration
    : IEntityTypeConfiguration<Parent>
{
    public void Configure(EntityTypeBuilder<Parent> parentConfiguration)
    {
        parentConfiguration.ToTable("parents", "people");

        //parentConfiguration
        //    .OwnsOne(o => o.ParentAddress);

        parentConfiguration.Property(s => s.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(100);
        parentConfiguration.Property(s => s.LastName)
    .HasColumnName("last_name")
    .HasMaxLength(100);
        parentConfiguration.Property(s => s.OtherNames)
    .HasColumnName("other_names")
    .HasMaxLength(100);

        parentConfiguration.Property(s => s.Email)
         .HasColumnName("email")
         .HasMaxLength(100);
        parentConfiguration.Property(s => s.Phone)
         .HasColumnName("phone")
         .HasMaxLength(20);
         
        // Configure new properties
        parentConfiguration.Property(s => s.Occupation)
            .HasColumnName("occupation")
            .HasMaxLength(100);

        parentConfiguration.Property(s => s.Workplace)
            .HasColumnName("workplace")
            .HasMaxLength(200);

        parentConfiguration.Property(s => s.RelationshipToStudent)
            .HasColumnName("relationship_to_student");

        parentConfiguration.Property(s => s.AlternatePhone)
            .HasColumnName("alternate_phone")
            .HasMaxLength(20);

        parentConfiguration.Property(s => s.AlternateEmail)
            .HasColumnName("alternate_email")
            .HasMaxLength(100);
 
    }
}