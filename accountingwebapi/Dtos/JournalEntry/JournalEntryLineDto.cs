namespace accountingwebapi.Dtos.JournalEntry
{
    public class JournalEntryLineDto
    {
        public Ulid Id { get; set; }

        public Ulid JournalEntryId { get; set; }
        public string IndividualAccountDesc { get; set; }
        public decimal Amount { get; set; } // Always positive
        public bool IsDebit { get; set; }   // true = debit, false = credit

        public string Remarks { get; set; }
    }
}
