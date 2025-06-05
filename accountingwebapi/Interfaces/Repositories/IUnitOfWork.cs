namespace accountingwebapi.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountingPeriodRepository AccountingPeriod { get; }
        IChartOfAccountRepository ChartOfAccount { get; }
        ICustomerContactDetailRepository CustomerContractDetail { get; }
        ICustomerRepository CustomerRepository { get; }
        IIndividualAccountRepository IndividualAccount { get; }
        IJournalEntryRepository JournalEntry { get; }
        INotificationRepository Notification { get; }
        ISubAccountRepository SubAccount { get; }
        IJournalEntryLineRepository JournalEntryLine { get; }
        IEntryTemplateRepository EntryTemplate { get; }
        IEntryTemplateLineRepository EntryTemplateLine { get; }

        int Complete();
        Task<int> CompleteAsync();
        void Dispose();
        Task DisposeAsync();
    }
}