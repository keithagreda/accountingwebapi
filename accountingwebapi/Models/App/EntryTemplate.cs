namespace accountingwebapi.Models.App
{
    public class EntryTemplate : AuditedEntityUlid
    {
        public string EntryType { get; set; }
        public ICollection<EntryTemplateLine> Lines { get; set; } = new List<EntryTemplateLine>();
    }
}
