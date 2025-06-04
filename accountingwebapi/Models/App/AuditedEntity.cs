namespace accountingwebapi.Models.App
{
    public abstract class AuditedEntity
    {
        public DateTimeOffset CreationTime { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeOffset? ModifiedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool IsModified { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletionTime { get; set; }
        public Guid? DeletedBy { get; set; }
    }

    public abstract class AuditedEntityUlid : AuditedEntity
    {
        public Ulid Id { get; set; } = Ulid.NewUlid();
    }

}
