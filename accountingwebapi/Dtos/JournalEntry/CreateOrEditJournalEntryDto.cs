namespace accountingwebapi.Dtos.JournalEntry
{
    public class CreateOrEditJournalEntryDto
    {
        public Ulid? Id { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public string? Description { get; set; }
        public Ulid CompanyId { get; set; }
        public Ulid? CustomerId { get; set; }

        //public int AccountingPeriodId { get; set; }

        // Adjustments (Self-referencing)
        public Ulid? AdjustsEntryId { get; set; }
        public bool IsAdjustment { get; set; }

        // Void
        public bool IsVoided { get; set; } = false;
        public string? VoidedReason { get; set; }
        public DateTime? VoidedOn { get; set; }
        public Guid? VoidedBy { get; set; }

        public ICollection<CreateOrEditJournalEntryLineDto> Lines { get; set; } = new List<CreateOrEditJournalEntryLineDto>();
    }
}
