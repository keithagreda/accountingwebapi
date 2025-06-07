using accountingwebapi.Dtos.CustomerContactDetails;

namespace accountingwebapi.Dtos.Customer
{
    public class CreateOrEditCustomerDto
    {
        public Ulid? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Ulid> CompanyIds { get; set; } = new List<Ulid>();
        public ICollection<CustomerContactDetailsDto> ContactDetails { get; set; } = new List<CustomerContactDetailsDto>();
    }

}
