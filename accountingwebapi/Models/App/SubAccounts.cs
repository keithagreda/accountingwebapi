using accountingwebapi.Enum;
using NUlid;

namespace accountingwebapi.Models.App
{
    public class SubAccounts : AuditedEntity
    {
        public Ulid Id { get; set; }
        public AccountCategory AccountCateg { get; set; }
        public string Name { get; set; }
    }
}
