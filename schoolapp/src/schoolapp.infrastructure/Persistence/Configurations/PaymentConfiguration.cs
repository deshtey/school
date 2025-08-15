using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Financial;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> paymentConfiguration)
        {
            paymentConfiguration.ToTable("payments", "financial");

            paymentConfiguration.Property(s => s.ReferenceNumber)
                .HasColumnName("reference_number")
                .HasMaxLength(100);

            paymentConfiguration.Property(s => s.Remarks)
                .HasColumnName("remarks")
                .HasMaxLength(500);
        }
    }
}