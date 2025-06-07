namespace accountingwebapi.Dtos.EntryTemplate
{
    public class CreateOrEditEntryTemplateDto
    {
        public Ulid? Id { get; set; }
        public string EntryType { get; set; }

    }

    public class CreateOrEditEntryTemplateLineDto
    {
        public Ulid? Id { get; set; }
        public Ulid AccountId { get; set; }
        public bool IsDebit { get; set; }
    }
}
