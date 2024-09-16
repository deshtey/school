using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.People;
using schoolapp.Domain.Entities.Departments;
using schoolapp.Domain.Entities.Other;

namespace schoolapp.Infrastructure.Persistence.Configurations;
class PermissionConfiguration
    : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> permissionConfiguration)
    {
        permissionConfiguration.ToTable("permissions", "auth");

       permissionConfiguration.HasKey(p => p.Id);  

    }
}