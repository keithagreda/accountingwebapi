using NUlid;
using System.ComponentModel.DataAnnotations.Schema;

namespace accountingwebapi.Models.App
{
    public class IndividualAccount : AuditedEntity
    {
        public Ulid Id { get; set; }
        public string Description { get; set; }
        public Ulid SubAccountId { get; set; }
        [ForeignKey("SubAccountId")]
        public SubAccount SubAccountFk { get; set; }
        public Ulid? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer CustomerFk { get; set; }

    }
}
