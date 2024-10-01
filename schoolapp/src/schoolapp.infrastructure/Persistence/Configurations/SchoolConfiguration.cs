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
    }
}