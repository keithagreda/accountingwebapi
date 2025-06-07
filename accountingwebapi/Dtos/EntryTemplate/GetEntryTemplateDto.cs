using accountingwebapi.Dtos.EntryTemplateLine;

namespace accountingwebapi.Dtos.EntryTemplate
{
    public class GetEntryTemplateDto
    {
        public Ulid Id { get; set; }
        public string EntryType { get; set; }
        public int Score { get; set; }
        public ICollection<GetEntryTemplateLineDto> GetEntryTemplateLineDtos { get; set; } = new List<GetEntryTemplateLineDto>();
    }
}
