namespace accountingwebapi.Models.App
{
    public class EntryTemplateLine : AuditedEntityUlid
    {
        public Ulid TemplateId { get; set; }
        public EntryTemplate Template { get; set; }

        public Ulid AccountId { get; set; }
        public IndividualAccount Account { get; set; }

        public bool IsDebit { get; set; }
    }
}
