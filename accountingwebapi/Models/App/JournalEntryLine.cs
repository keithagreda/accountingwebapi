using System.ComponentModel.DataAnnotations.Schema;

namespace accountingwebapi.Models.App
{
    public class JournalEntryLine : AuditedEntityUlid
    {
        public Ulid JournalEntryId { get; set; }
        [ForeignKey(nameof(JournalEntryId))]
        public JournalEntry JournalEntryFk { get; set; }

        public Ulid IndividualAccountId { get; set; }
        [ForeignKey(nameof(IndividualAccountId))]
        public IndividualAccount IndividualAccountFk { get; set; }

        public decimal Amount { get; set; } // Always positive
        public bool IsDebit { get; set; }   // true = debit, false = credit

        public string Remarks { get; set; }
    }
}
