using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities;

namespace schoolapp.Infrastructure.Persistence.Configurations;
class SchoolSettingConfiguration
    : IEntityTypeConfiguration<SchoolSetting>
{
    public void Configure(EntityTypeBuilder<SchoolSetting> schoolConfiguration)
    {
        schoolConfiguration.ToTable("school_settings", "school");

        schoolConfiguration
            .HasOne(s => s.School)
            .WithOne(s => s.ExtraSettings)
            .HasForeignKey<SchoolSetting>(s => s.ParentSchoolId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}