using schoolapp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace schoolapp.Infrastructure.Persistence.Configurations;

public class SchoolConfiguration : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.Property(t => t.SchoolName)
            .HasMaxLength(200)
            .IsRequired();

        //builder
        //    .OwnsOne(b => b.Colour);
    }
}
