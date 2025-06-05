using accountingwebapi.Models.App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace accountingwebapi.ModelBuilderExtensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyAuditedEntityConfiguration<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : AuditedEntity
        {
            builder.Property(e => e.CreationTime).HasColumnType("timestamptz");
            builder.Property(e => e.ModifiedTime).HasColumnType("timestamptz");
            builder.Property(e => e.DeletionTime).HasColumnType("timestamptz");
        }
    }
}
