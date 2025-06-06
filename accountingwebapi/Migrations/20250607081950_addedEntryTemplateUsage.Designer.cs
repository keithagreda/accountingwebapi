﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using accountingwebapi.Context;

#nullable disable

namespace accountingwebapi.Migrations
{
    [DbContext(typeof(AcctgContext))]
    [Migration("20250607081950_addedEntryTemplateUsage")]
    partial class addedEntryTemplateUsage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CustomerCompany", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("character varying(26)");

                    b.Property<string>("CompanyId")
                        .HasColumnType("character varying(26)");

                    b.HasKey("CustomerId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("CustomerCompanies", (string)null);
                });

            modelBuilder.Entity("accountingwebapi.Models.App.AccountingPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("ClosedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ClosedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("AccountingPeriods");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.Company", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("character varying(26)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamptz");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletionTime")
                        .HasColumnType("timestamptz");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamptz");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("character varying(26)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamptz");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletionTime")
                        .HasColumnType("timestamptz");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamptz");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.CustomerContactDetail", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("character varying(26)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamptz");

                    b.Property<string>("CustomerId")
                        .HasColumnType("character varying(26)");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletionTime")
                        .HasColumnType("timestamptz");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamptz");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerContactDetail");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.EntryTemplate", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("character varying(26)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EntryType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("EntryTemplates");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.EntryTemplateLine", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("character varying(26)");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("character varying(26)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamptz");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletionTime")
                        .HasColumnType("timestamptz");

                    b.Property<bool>("IsDebit")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamptz");

                    b.Property<string>("TemplateId")
                        .IsRequired()
                        .HasColumnType("character varying(26)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("TemplateId");

                    b.ToTable("EntryTemplateLines");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.EntryTemplateUsageStats", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("character varying(26)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamptz");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletionTime")
                        .HasColumnType("timestamptz");

                    b.Property<string>("EntryTemplateId")
                        .IsRequired()
                        .HasColumnType("character varying(26)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamptz");

                    b.Property<int>("UsageCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("EntryTemplateUsageStats");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.IndividualAccount", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("character varying(26)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamptz");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletionTime")
                        .HasColumnType("timestamptz");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamptz");

                    b.Property<string>("SubAccountId")
                        .IsRequired()
                        .HasColumnType("character varying(26)");

                    b.HasKey("Id");

                    b.HasIndex("SubAccountId");

                    b.ToTable("IndividualAccounts");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.JournalEntry", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("character varying(26)");

                    b.Property<int>("AccountingPeriodId")
                        .HasColumnType("integer");

                    b.Property<string>("AdjustsEntryId")
                        .HasColumnType("character varying(26)");

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasColumnType("character varying(26)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamptz");

                    b.Property<string>("CustomerId")
                        .HasColumnType("character varying(26)");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletionTime")
                        .HasColumnType("timestamptz");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAdjustment")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsVoided")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamptz");

                    b.Property<DateTimeOffset>("TransactionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("VoidedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("VoidedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("VoidedReason")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AccountingPeriodId");

                    b.HasIndex("AdjustsEntryId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("JournalEntries");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.JournalEntryLine", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("character varying(26)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,5)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamptz");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletionTime")
                        .HasColumnType("timestamptz");

                    b.Property<string>("IndividualAccountId")
                        .IsRequired()
                        .HasColumnType("character varying(26)");

                    b.Property<bool>("IsDebit")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<string>("JournalEntryId")
                        .IsRequired()
                        .HasColumnType("character varying(26)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamptz");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IndividualAccountId");

                    b.HasIndex("JournalEntryId");

                    b.ToTable("JournalEntryLines");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.SubAccount", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("character varying(26)");

                    b.Property<int>("AccountCateg")
                        .HasColumnType("integer");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreationTime")
                        .HasColumnType("timestamptz");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletionTime")
                        .HasColumnType("timestamptz");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsModified")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamptz");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SubAccounts");
                });

            modelBuilder.Entity("CustomerCompany", b =>
                {
                    b.HasOne("accountingwebapi.Models.App.Company", null)
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CustomerCompany_Company");

                    b.HasOne("accountingwebapi.Models.App.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CustomerCompany_Customer");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.CustomerContactDetail", b =>
                {
                    b.HasOne("accountingwebapi.Models.App.Customer", "CustomerFk")
                        .WithMany("CustomerContactDetails")
                        .HasForeignKey("CustomerId");

                    b.Navigation("CustomerFk");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.EntryTemplateLine", b =>
                {
                    b.HasOne("accountingwebapi.Models.App.IndividualAccount", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("accountingwebapi.Models.App.EntryTemplate", "Template")
                        .WithMany("Lines")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.IndividualAccount", b =>
                {
                    b.HasOne("accountingwebapi.Models.App.SubAccount", "SubAccountFk")
                        .WithMany()
                        .HasForeignKey("SubAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubAccountFk");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.JournalEntry", b =>
                {
                    b.HasOne("accountingwebapi.Models.App.AccountingPeriod", "AccountingPeriodFk")
                        .WithMany()
                        .HasForeignKey("AccountingPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("accountingwebapi.Models.App.JournalEntry", "AdjustsEntryFk")
                        .WithMany("AdjustingEntries")
                        .HasForeignKey("AdjustsEntryId");

                    b.HasOne("accountingwebapi.Models.App.Company", "CompanyFk")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("accountingwebapi.Models.App.Customer", "CustomerFk")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("AccountingPeriodFk");

                    b.Navigation("AdjustsEntryFk");

                    b.Navigation("CompanyFk");

                    b.Navigation("CustomerFk");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.JournalEntryLine", b =>
                {
                    b.HasOne("accountingwebapi.Models.App.IndividualAccount", "IndividualAccountFk")
                        .WithMany()
                        .HasForeignKey("IndividualAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("accountingwebapi.Models.App.JournalEntry", "JournalEntryFk")
                        .WithMany("Lines")
                        .HasForeignKey("JournalEntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IndividualAccountFk");

                    b.Navigation("JournalEntryFk");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.Customer", b =>
                {
                    b.Navigation("CustomerContactDetails");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.EntryTemplate", b =>
                {
                    b.Navigation("Lines");
                });

            modelBuilder.Entity("accountingwebapi.Models.App.JournalEntry", b =>
                {
                    b.Navigation("AdjustingEntries");

                    b.Navigation("Lines");
                });
#pragma warning restore 612, 618
        }
    }
}
