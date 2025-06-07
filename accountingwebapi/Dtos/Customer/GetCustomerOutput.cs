namespace accountingwebapi.Dtos.Customer
{
    public class GetCustomerOutput
    {
        public Ulid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<string> ContactDetails { get; set; } = new List<string>();
        public ICollection<string> AffiliatedCompanies { get; set; }= new List<string>();   
    }

}
