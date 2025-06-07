
namespace accountingwebapi.Models.App
{
    public class Customer : AuditedEntityUlid
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<CustomerContactDetail> CustomerContactDetails { get; set; } = new List<CustomerContactDetail>();
        public ICollection<Company> AffiliatedCompanies { get; set; } = new List<Company>();
    }

    public class Company : AuditedEntityUlid
    {
        public string Name { get; set; }
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
