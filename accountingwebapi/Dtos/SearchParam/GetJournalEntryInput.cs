namespace accountingwebapi.Dtos.SearchParam
{
    public class GetJournalEntryInput : GenericSearchParam
    {
        public Ulid? IndividualAccountId { get; set; }
        public Ulid? CompanyId { get; set; }
        public Ulid? CustomerId { get; set; }
    }
}
