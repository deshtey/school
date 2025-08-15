using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Health;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class MedicalConditionConfiguration : IEntityTypeConfiguration<MedicalCondition>
    {
        public void Configure(EntityTypeBuilder<MedicalCondition> medicalConditionConfiguration)
        {
            medicalConditionConfiguration.ToTable("medical_conditions", "health");

            medicalConditionConfiguration.Property(s => s.ConditionName)
                .HasColumnName("condition_name")
                .HasMaxLength(200);

            medicalConditionConfiguration.Property(s => s.Description)
                .HasColumnName("description")
                .HasMaxLength(500);
        }
    }
}