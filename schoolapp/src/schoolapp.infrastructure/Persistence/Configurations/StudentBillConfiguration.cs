using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Financial;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class StudentBillConfiguration : IEntityTypeConfiguration<StudentBill>
    {
        public void Configure(EntityTypeBuilder<StudentBill> studentBillConfiguration)
        {
            studentBillConfiguration.ToTable("student_bills", "financial");

            studentBillConfiguration.Property(s => s.Description)
                .HasColumnName("description")
                .HasMaxLength(500);

            studentBillConfiguration.Property(s => s.Remarks)
                .HasColumnName("remarks")
                .HasMaxLength(500);
        }
    }
}