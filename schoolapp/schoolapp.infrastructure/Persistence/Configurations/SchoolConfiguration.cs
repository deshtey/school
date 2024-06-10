using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using schoolapp.Domain.Entities.Base;

public static class ModelBuilderExtensions
{
    public static void ConfigureOwnedAddress(this ModelBuilder modelBuilder, IMutableEntityType entity)
    {
        var addressProperty = entity.ClrType.GetProperty("Address");
        if (addressProperty != null && addressProperty.PropertyType == typeof(Address))
        {
            modelBuilder.Entity(entity.ClrType).OwnsOne(
                
                //.OwnsOne(
                addressProperty.Name,"address", addressMapping =>
                {
                    addressMapping.Property("Street").HasColumnName("street");
                    addressMapping.Property("City").HasColumnName("city");
                    addressMapping.Property("ZipCode").HasColumnName("zipcode");
                    addressMapping.Property("PostalCode").HasColumnName("postalcode");
                    addressMapping.Property("Country").HasColumnName("country");
                    addressMapping.Property("Phone").HasColumnName("phone");
                    addressMapping.Property("Fax").HasColumnName("fax");
                });
        }
    }
}
