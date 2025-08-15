using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Health;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class MedicationConfiguration : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> medicationConfiguration)
        {
            medicationConfiguration.ToTable("medications", "health");

            medicationConfiguration.Property(s => s.MedicationName)
                .HasColumnName("medication_name")
                .HasMaxLength(200);

            medicationConfiguration.Property(s => s.Dosage)
                .HasColumnName("dosage")
                .HasMaxLength(100);

            medicationConfiguration.Property(s => s.Frequency)
                .HasColumnName("frequency")
                .HasMaxLength(100);

            medicationConfiguration.Property(s => s.Remarks)
                .HasColumnName("remarks")
                .HasMaxLength(500);
        }
    }
}