namespace accountingwebapi.Models.App
{
    public class Notification : AuditedEntity
    {
        public Ulid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool Read { get; set; }
        public Guid SentTo { get; set; }
    }
}
