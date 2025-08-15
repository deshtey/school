using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Transportation;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class StudentTransportConfiguration : IEntityTypeConfiguration<StudentTransport>
    {
        public void Configure(EntityTypeBuilder<StudentTransport> studentTransportConfiguration)
        {
            studentTransportConfiguration.ToTable("student_transport", "transportation");

            studentTransportConfiguration.Property(s => s.Remarks)
                .HasColumnName("remarks")
                .HasMaxLength(500);
        }
    }
}