namespace accountingwebapi.Dtos.JournalEntry
{
    public class CreateOrEditJournalEntryLineDto
    {
        public Ulid? Id { get; set; }
        public Ulid JournalEntryId { get; set; }
        public Ulid IndividualAccountId { get; set; }
        public decimal Amount { get; set; } // Always positive
        public bool IsDebit { get; set; }   // true = debit, false = credit
        public string Remarks { get; set; }
    }
}
