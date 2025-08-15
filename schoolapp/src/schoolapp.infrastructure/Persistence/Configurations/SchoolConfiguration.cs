using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities;

namespace schoolapp.Infrastructure.Persistence.Configurations;
class SchoolEntityConfiguration
    : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> schoolConfiguration)
    {
        schoolConfiguration.ToTable("schools", "school");
    
        schoolConfiguration.Property(s => s.SchoolName)
            .HasColumnName("schoolname")
            .HasMaxLength(200);
            
        // Configure new properties
        schoolConfiguration.Property(s => s.Motto)
            .HasColumnName("motto")
            .HasMaxLength(200);

        schoolConfiguration.Property(s => s.VisionStatement)
            .HasColumnName("vision_statement")
            .HasMaxLength(1000);

        schoolConfiguration.Property(s => s.MissionStatement)
            .HasColumnName("mission_statement")
            .HasMaxLength(1000);

        schoolConfiguration.Property(s => s.AccreditationInfo)
            .HasColumnName("accreditation_info")
            .HasMaxLength(500);

        schoolConfiguration.Property(s => s.BankAccountNumber)
            .HasColumnName("bank_account_number")
            .HasMaxLength(50);

        schoolConfiguration.Property(s => s.BankName)
            .HasColumnName("bank_name")
            .HasMaxLength(100);

        schoolConfiguration.Property(s => s.RegistrationNumber)
            .HasColumnName("registration_number")
            .HasMaxLength(50);
    }
}