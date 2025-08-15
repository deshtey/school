using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Financial;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class FeeStructureConfiguration : IEntityTypeConfiguration<FeeStructure>
    {
        public void Configure(EntityTypeBuilder<FeeStructure> feeStructureConfiguration)
        {
            feeStructureConfiguration.ToTable("fee_structures", "financial");

            feeStructureConfiguration.Property(s => s.Description)
                .HasColumnName("description")
                .HasMaxLength(500);
        }
    }
}