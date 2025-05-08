using accountingwebapi.Models.App;
using Microsoft.EntityFrameworkCore;
using POSIMSWebApi.Interceptors;

namespace accountingwebapi.Context
{
    public class AcctgContext : DbContext
    {
        private readonly AuditInterceptor _auditInterceptor;
        static AcctgContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public AcctgContext(DbContextOptions<AcctgContext> options, AuditInterceptor auditInterceptor) : base(options)
        {
            _auditInterceptor = auditInterceptor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditInterceptor);
        }


        public DbSet<IndividualAccount> IndividualAccounts { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<SubAccount> SubAccounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContactDetail> CustomerContactDetail { get; set; }
        public DbSet<AccountingPeriod> AccountingPeriods { get; set; }

    }
}
