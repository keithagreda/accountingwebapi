using Microsoft.EntityFrameworkCore;
using NUlid;

namespace accountingwebapi.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyUlidConversion(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.GetProperties()
                    .Where(p => p.PropertyInfo.PropertyType == typeof(Ulid));

                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.ClrType)  // Use entityType.ClrType instead of entityType.Name
                        .Property(property.Name)
                        .HasConversion(
                            id => id.ToString(),  // Convert Ulid to string for storage
                            str => Ulid.Parse(str)  // Convert string back to Ulid when reading from DB
                        );
                }
            }
        }
    }

}
