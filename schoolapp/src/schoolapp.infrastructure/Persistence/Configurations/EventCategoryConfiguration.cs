using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Events;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class EventCategoryConfiguration : IEntityTypeConfiguration<EventCategory>
    {
        public void Configure(EntityTypeBuilder<EventCategory> eventCategoryConfiguration)
        {
            eventCategoryConfiguration.ToTable("event_categories", "events");

            eventCategoryConfiguration.Property(s => s.CategoryName)
                .HasColumnName("category_name")
                .HasMaxLength(100);

            eventCategoryConfiguration.Property(s => s.Description)
                .HasColumnName("description")
                .HasMaxLength(500);
        }
    }
}