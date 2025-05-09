﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.People;
using schoolapp.Domain.Entities.Departments;

namespace schoolapp.Infrastructure.Persistence.Configurations;
class SupportStaffEntityConfiguration
    : IEntityTypeConfiguration<SupportStaff>
{
    public void Configure(EntityTypeBuilder<SupportStaff> supportStaffConfiguration)
    {
        supportStaffConfiguration.ToTable("supportstaffs", "people");

        supportStaffConfiguration.Property(s => s.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(100);
        supportStaffConfiguration.Property(s => s.LastName)
    .HasColumnName("last_name")
    .HasMaxLength(100);
        supportStaffConfiguration.Property(s => s.OtherNames)
    .HasColumnName("other_names")
    .HasMaxLength(100);

        supportStaffConfiguration.Property(s => s.Email)
         .HasColumnName("email")
         .HasMaxLength(100);

        supportStaffConfiguration.Property(s => s.Phone)
         .HasColumnName("phone")
         .HasMaxLength(20);
        supportStaffConfiguration
.HasMany(s => s.Departments)
 .WithMany(s => s.Staff)
 .UsingEntity<StaffDepartment>(
     s => s.ToTable("staff_department"));
    }
}