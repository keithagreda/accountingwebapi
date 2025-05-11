namespace accountingwebapi.Dtos.SubAccount
{
    public class GetSubAccountForViewDto
    {
        public Ulid Id { get; set; }
        public string AccountCategory { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreationTime { get; set; }
        public string CreatedBy { get; set; }
    }
}
