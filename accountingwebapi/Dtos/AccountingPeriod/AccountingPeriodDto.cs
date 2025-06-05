namespace accountingwebapi.Dtos.AccountingPeriod
{
    public class AccountingPeriodDto
    {
        public int Id { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public bool IsClosed { get; set; }
        public Guid ClosedBy { get; set; }
        public DateTimeOffset? ClosedOn { get; set; }
    }
}
