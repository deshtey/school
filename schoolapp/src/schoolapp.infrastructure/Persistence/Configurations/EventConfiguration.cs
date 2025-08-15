using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Events;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> eventConfiguration)
        {
            eventConfiguration.ToTable("events", "events");

            eventConfiguration.Property(s => s.EventName)
                .HasColumnName("event_name")
                .HasMaxLength(200);

            eventConfiguration.Property(s => s.Description)
                .HasColumnName("description")
                .HasMaxLength(1000);

            eventConfiguration.Property(s => s.Location)
                .HasColumnName("location")
                .HasMaxLength(200);
        }
    }
}