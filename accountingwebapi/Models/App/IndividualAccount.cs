using System.ComponentModel.DataAnnotations.Schema;

namespace accountingwebapi.Models.App
{
    public class IndividualAccount : AuditedEntityUlid
    {
        public string Description { get; set; }
        public Ulid SubAccountId { get; set; }
        [ForeignKey("SubAccountId")]
        public SubAccount SubAccountFk { get; set; }
    }
}
