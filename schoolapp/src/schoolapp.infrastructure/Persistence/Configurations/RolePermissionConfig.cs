using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Other;

namespace schoolapp.Infrastructure.Persistence.Configurations;
class RolePermissionEntityConfiguration
    : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> rolepermissionConfiguration)
    {
        rolepermissionConfiguration.ToTable("role_permissions", "auth");
        rolepermissionConfiguration.HasKey(r => r.Id);
       // rolepermissionConfiguration.Ignore(r => r.Role);

    }
}