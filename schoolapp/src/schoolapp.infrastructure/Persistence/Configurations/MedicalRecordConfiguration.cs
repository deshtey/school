using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Health;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> medicalRecordConfiguration)
        {
            medicalRecordConfiguration.ToTable("medical_records", "health");

            medicalRecordConfiguration.Property(s => s.Condition)
                .HasColumnName("condition")
                .HasMaxLength(200);

            medicalRecordConfiguration.Property(s => s.Doctor)
                .HasColumnName("doctor")
                .HasMaxLength(100);

            medicalRecordConfiguration.Property(s => s.Prescription)
                .HasColumnName("prescription")
                .HasMaxLength(500);

            medicalRecordConfiguration.Property(s => s.Remarks)
                .HasColumnName("remarks")
                .HasMaxLength(500);
        }
    }
}