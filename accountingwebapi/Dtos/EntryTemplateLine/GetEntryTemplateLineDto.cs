namespace accountingwebapi.Dtos.EntryTemplateLine
{
    public class GetEntryTemplateLineDto
    {
        public Ulid Id { get; set; }
        public Ulid AccountId { get; set; }
        public bool IsDebit { get; set; }
    }
}
