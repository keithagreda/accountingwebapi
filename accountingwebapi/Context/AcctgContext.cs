using accountingwebapi.ModelBuilderExtensions;
using accountingwebapi.Models.App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        public DbSet<JournalEntryLine> JournalEntryLines { get; set; }

        public DbSet<EntryTemplate> EntryTemplates { get; set; }
        public DbSet<EntryTemplateLine> EntryTemplateLines { get; set; }
        public DbSet<SubAccount> SubAccounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContactDetail> CustomerContactDetail { get; set; }
        public DbSet<AccountingPeriod> AccountingPeriods { get; set; }
        public DbSet<Company> Companies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EntryTemplate>(entity =>
            {
                entity.Property(e => e.Id).HasConversion<UlidToStringConverter>();
            });

            modelBuilder.Entity<EntryTemplateLine>(entity =>
            {
                entity.ApplyAuditedEntityConfiguration();
                entity.Property(e => e.Id).HasConversion<UlidToStringConverter>();
                entity.Property(e => e.TemplateId).HasConversion<UlidToStringConverter>();
                entity.Property(e => e.AccountId).HasConversion<UlidToStringConverter>();
            });

            modelBuilder.Entity<JournalEntry>(entity =>
            {
                entity.ApplyAuditedEntityConfiguration();
                entity.Property(e => e.Id).HasConversion<UlidToStringConverter>();
                entity.Property(e => e.AdjustsEntryId).HasConversion<UlidToStringConverter>();
                entity.Property(e => e.CompanyId).HasConversion<UlidToStringConverter>();
                entity.Property(e => e.CustomerId).HasConversion<UlidToStringConverter>();
            });

            modelBuilder.Entity<JournalEntryLine>(entity =>
            {
                entity.ApplyAuditedEntityConfiguration();
                entity.Property(e => e.Id).HasConversion<UlidToStringConverter>();
                entity.Property(e => e.JournalEntryId).HasConversion<UlidToStringConverter>();
                entity.Property(e => e.IndividualAccountId).HasConversion<UlidToStringConverter>();

                // Optional: enforce required debit/credit behavior
                entity.Property(e => e.Amount).HasColumnType("decimal(18,5)").IsRequired();
                entity.Property(e => e.IsDebit).IsRequired();
            });

            modelBuilder.Entity<IndividualAccount>(entity =>
            {
                entity.ApplyAuditedEntityConfiguration();
                entity.Property(e => e.Id).HasConversion<UlidToStringConverter>();
                entity.Property(e => e.SubAccountId).HasConversion<UlidToStringConverter>();
            });

            modelBuilder.Entity<CustomerContactDetail>(entity =>
            {
                entity.ApplyAuditedEntityConfiguration();
                entity.Property(e => e.Id).HasConversion<UlidToStringConverter>();
                entity.Property(e => e.CustomerId).HasConversion<UlidToStringConverter>();
            });

            modelBuilder.Entity<SubAccount>(entity =>
            {
                entity.ApplyAuditedEntityConfiguration();
                entity.Property(e => e.Id).HasConversion<UlidToStringConverter>();
            });


            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ApplyAuditedEntityConfiguration();
                entity.Property(e => e.Id).HasConversion<UlidToStringConverter>();
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ApplyAuditedEntityConfiguration();
                entity.Property(e => e.Id).HasConversion<UlidToStringConverter>();
            });

            modelBuilder.Entity<EntryTemplateUsageStats>(entity =>
            {
                entity.ApplyAuditedEntityConfiguration();
                entity.Property(e => e.Id).HasConversion<UlidToStringConverter>();
                entity.Property(e => e.EntryTemplateId).HasConversion<UlidToStringConverter>();
            });

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.AffiliatedCompanies)
                .WithMany(c => c.Customers)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerCompany",
                    j => j
                        .HasOne<Company>()
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_CustomerCompany_Company")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Customer>()
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_CustomerCompany_Customer")
                        .OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey("CustomerId", "CompanyId");
                        j.ToTable("CustomerCompanies");

                        // ULID as string conversion
                        j.Property("CustomerId").HasConversion<UlidToStringConverter>();
                        j.Property("CompanyId").HasConversion<UlidToStringConverter>();
                    });

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
