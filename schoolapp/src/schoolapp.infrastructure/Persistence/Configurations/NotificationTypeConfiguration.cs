using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Notifications;

namespace schoolapp.Infrastructure.Persistence.Configurations
{
    internal class NotificationTypeConfiguration : IEntityTypeConfiguration<NotificationType>
    {
        public void Configure(EntityTypeBuilder<NotificationType> notificationTypeConfiguration)
        {
            notificationTypeConfiguration.ToTable("notification_types", "notifications");

            notificationTypeConfiguration.Property(s => s.TypeName)
                .HasColumnName("type_name")
                .HasMaxLength(100);

            notificationTypeConfiguration.Property(s => s.Description)
                .HasColumnName("description")
                .HasMaxLength(500);
        }
    }
}