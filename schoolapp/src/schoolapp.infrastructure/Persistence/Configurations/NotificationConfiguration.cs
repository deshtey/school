using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Notifications;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> notificationConfiguration)
        {
            notificationConfiguration.ToTable("notifications", "notifications");

            notificationConfiguration.Property(s => s.Title)
                .HasColumnName("title")
                .HasMaxLength(200);

            notificationConfiguration.Property(s => s.Message)
                .HasColumnName("message")
                .HasMaxLength(1000);

            notificationConfiguration.Property(s => s.Recipient)
                .HasColumnName("recipient")
                .HasMaxLength(100);
        }
    }
}