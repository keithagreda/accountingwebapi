using System.ComponentModel.DataAnnotations.Schema;

namespace accountingwebapi.Models.App
{
    public class JournalEntry : AuditedEntityUlid
    {
        public DateTimeOffset TransactionDate { get; set; }
        public string Description { get; set; }

        public Ulid CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company CompanyFk { get; set; }

        public Ulid? CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer CustomerFk { get; set; }

        public int AccountingPeriodId { get; set; }
        [ForeignKey(nameof(AccountingPeriodId))]
        public AccountingPeriod AccountingPeriodFk { get; set; }

        // Adjustments (Self-referencing)
        public Ulid? AdjustsEntryId { get; set; }
        [ForeignKey(nameof(AdjustsEntryId))]
        public JournalEntry AdjustsEntryFk { get; set; }
        public ICollection<JournalEntry> AdjustingEntries { get; set; } = new List<JournalEntry>();
        public bool IsAdjustment { get; set; }

        // Void
        public bool IsVoided { get; set; } = false;
        public string? VoidedReason { get; set; }
        public DateTime? VoidedOn { get; set; }
        public Guid? VoidedBy { get; set; }

        public ICollection<JournalEntryLine> Lines { get; set; } = new List<JournalEntryLine>();
    }
}
