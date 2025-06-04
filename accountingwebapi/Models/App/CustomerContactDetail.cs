using accountingwebapi.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace accountingwebapi.Models.App
{
    public class CustomerContactDetail : AuditedEntityUlid
    {
        public string Details { get; set; }
        public ContactDetailType Type { get; set; }

        public Ulid? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer CustomerFk { get; set; }
    }
}
