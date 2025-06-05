using accountingwebapi.Context;
using accountingwebapi.Interfaces.Repositories;
using accountingwebapi.Repository;
using System.Threading.Tasks;

namespace accountingwebapi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AcctgContext _context;
        public UnitOfWork(AcctgContext context)
        {
            _context = context;
            AccountingPeriod = new AccountingPeriodRepository(_context);
            ChartOfAccount = new ChartOfAccountRepository(_context);
            CustomerContractDetail = new CustomerContactDetailRepository(_context);
            CustomerRepository = new CustomerRepository(_context);
            IndividualAccount = new IndividualAccountRepository(_context);
            JournalEntry = new JournalEntryRepository(_context);
            Notification = new NotificationRepository(_context);
            SubAccount = new SubAccountRepository(_context);
            JournalEntryLine = new JournalEntryLineRepository(_context);
            EntryTemplate = new EntryTemplateRepository(_context);
            EntryTemplateLine = new EntryTemplateLineRepository(_context);
        }

        public IAccountingPeriodRepository AccountingPeriod { get; private set; }
        public IChartOfAccountRepository ChartOfAccount { get; private set; }
        public ICustomerContactDetailRepository CustomerContractDetail { get; private set; }
        public ICustomerRepository CustomerRepository { get; private set; }
        public IIndividualAccountRepository IndividualAccount { get; private set; }
        public IJournalEntryRepository JournalEntry { get; private set; }
        public INotificationRepository Notification { get; private set; }
        public ISubAccountRepository SubAccount { get; private set; }
        public IJournalEntryLineRepository JournalEntryLine { get; private set; }
        public IEntryTemplateLineRepository EntryTemplateLine { get; private set; }
        public IEntryTemplateRepository EntryTemplate { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
