using accountingwebapi.Dtos.SearchParam;

namespace accountingwebapi.Dtos.Customer
{
    public class GetCustomerInput : GenericSearchParam
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ContactDetails { get; set; }
        public string? AffiliatedCompanies { get; set; }
    }

}
