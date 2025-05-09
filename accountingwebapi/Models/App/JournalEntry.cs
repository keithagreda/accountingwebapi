using System.ComponentModel.DataAnnotations.Schema;

namespace accountingwebapi.Models.App
{
    public class JournalEntry : AuditedEntity
    {
        public Ulid Id { get; set; }
        public decimal AmountDebit { get; set; }
        public decimal AmountCredit { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
        public int AccountingPeriodId { get; set; }

        [ForeignKey("AccountingPeriodId")]
        public AccountingPeriod AccountingPeriodFk { get; set; }

        //Adjustments
        public Ulid AdjustsEntryId { get; set; }
        public JournalEntry AdjustsEntryFk { get; set; }
        public ICollection<JournalEntry> AdjustingEntries { get; set; } // All entries that adjust this one
        public bool IsAdjustment { get; set; }

        //void
        public bool IsVoided { get; set; } = false;
        public string VoidedReason { get; set; }
        public DateTime? VoidedOn { get; set; }
        public string VoidedBy { get; set; }
    }
}
