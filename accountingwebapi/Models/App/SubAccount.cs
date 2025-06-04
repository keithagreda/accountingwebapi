using accountingwebapi.Enum;

namespace accountingwebapi.Models.App
{
    public class SubAccount : AuditedEntityUlid
    {
        public AccountCategory AccountCateg { get; set; }
        public string Name { get; set; }
    }
}
