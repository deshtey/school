using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.People;

namespace schoolapp.Infrastructure.Persistence.Configurations;
class SupportStaffEntityConfiguration
    : IEntityTypeConfiguration<SupportStaff>
{
    public void Configure(EntityTypeBuilder<SupportStaff> supportStaffConfiguration)
    {
        supportStaffConfiguration.ToTable("supportstaffs");

        supportStaffConfiguration.Property(s => s.Name)
            .HasColumnName("name")
            .HasMaxLength(20);

        supportStaffConfiguration.Property(s => s.Email)
         .HasColumnName("email")
         .HasMaxLength(100);

        supportStaffConfiguration.Property(s => s.Phone)
         .HasColumnName("phone")
         .HasMaxLength(20);
    }
}