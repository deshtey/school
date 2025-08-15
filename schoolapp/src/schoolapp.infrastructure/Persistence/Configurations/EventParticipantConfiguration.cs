using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Events;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class EventParticipantConfiguration : IEntityTypeConfiguration<EventParticipant>
    {
        public void Configure(EntityTypeBuilder<EventParticipant> eventParticipantConfiguration)
        {
            eventParticipantConfiguration.ToTable("event_participants", "events");

            eventParticipantConfiguration.Property(s => s.Remarks)
                .HasColumnName("remarks")
                .HasMaxLength(500);
        }
    }
}