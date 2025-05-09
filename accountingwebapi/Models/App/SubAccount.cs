using accountingwebapi.Enum;

namespace accountingwebapi.Models.App
{
    public class SubAccount : AuditedEntity
    {
        public Ulid Id { get; set; }
        public AccountCategory AccountCateg { get; set; }
        public string Name { get; set; }
    }
}
