using accountingwebapi.Dtos.EntryTemplateLine;

namespace accountingwebapi.Dtos.EntryTemplate
{
    public class CreateOrEditEntryTemplateDto
    {
        public Ulid? Id { get; set; }
        public string EntryType { get; set; }

        public ICollection<CreateOrEditEntryTemplateLineDto> EntryTemplateLineDtos { get; set; } = new List<CreateOrEditEntryTemplateLineDto>();

    }

    
}
