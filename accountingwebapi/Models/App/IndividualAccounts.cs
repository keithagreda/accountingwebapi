using NUlid;
using System.ComponentModel.DataAnnotations.Schema;

namespace accountingwebapi.Models.App
{
    public class IndividualAccounts : AuditedEntity
    {
        public Ulid Id { get; set; }
        public string Description { get; set; }
        public Ulid SubAccountId { get; set; }
        [ForeignKey("SubAccountId")]
        public SubAccounts SubAccountFk { get; set; }
    }
}
