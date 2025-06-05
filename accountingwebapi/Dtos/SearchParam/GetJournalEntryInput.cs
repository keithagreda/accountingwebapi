namespace accountingwebapi.Dtos.SearchParam
{
    public class GetJournalEntryInput : GenericSearchParam
    {
        public Ulid? IndividualAccountId { get; set; }
    }
}
