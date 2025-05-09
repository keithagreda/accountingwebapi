using accountingwebapi.Models.App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POSIMSWebApi.Interceptors;
using System.Xml;
using static accountingwebapi.Context.AcctgContext;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JournalEntry>(entity =>
            {
                entity.Property(e => e.Id).HasConversion<UlidToStringConverter>();
                entity.Property(e => e.AdjustsEntryId).HasConversion<UlidToStringConverter>();
            });

            modelBuilder.Entity<IndividualAccount>(entity =>
            {
                entity.Property(e => e.Id).HasConversion<UlidToStringConverter>();
                entity.Property(e => e.SubAccountId).HasConversion<UlidToStringConverter>();
            });

            modelBuilder.Entity<CustomerContactDetail>(entity =>
            {
                entity.Property(e => e.Id).HasConversion<UlidToStringConverter>();
                entity.Property(e => e.CustomerId).HasConversion<UlidToStringConverter>();
            });

            modelBuilder.Entity<SubAccount>()
                .Property(e => e.Id)
                .HasConversion<UlidToStringConverter>();

            modelBuilder.Entity<Customer>()
                .Property(e => e.Id)
                .HasConversion<UlidToStringConverter>();
        }

        public class UlidToBytesConverter : ValueConverter<Ulid, byte[]>
        {
            private static readonly ConverterMappingHints DefaultHints = new ConverterMappingHints(size: 16);

            public UlidToBytesConverter() : this(null)
            {
            }

            public UlidToBytesConverter(ConverterMappingHints? mappingHints)
                : base(
                        convertToProviderExpression: x => x.ToByteArray(),
                        convertFromProviderExpression: x => new Ulid(x),
                        mappingHints: DefaultHints.With(mappingHints))
            {
            }
        }

        public class UlidToStringConverter : ValueConverter<Ulid, string>
        {
            private static readonly ConverterMappingHints DefaultHints = new ConverterMappingHints(size: 26);

            public UlidToStringConverter() : this(null)
            {
            }

            public UlidToStringConverter(ConverterMappingHints? mappingHints)
                : base(
                        convertToProviderExpression: x => x.ToString(),
                        convertFromProviderExpression: x => Ulid.Parse(x),
                        mappingHints: DefaultHints.With(mappingHints))
            {
            }
        }

    }
}
