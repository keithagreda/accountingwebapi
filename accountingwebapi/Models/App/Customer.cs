
namespace accountingwebapi.Models.App
{
    public class Customer : AuditedEntity
    {
        public Ulid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<CustomerContactDetail> CustomerContactDetails { get; set; } = new List<CustomerContactDetail>();

    }
}
