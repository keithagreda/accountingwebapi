using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace accountingwebapi.Migrations
{
    /// <inheritdoc />
    public partial class addedTimeStamptz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "SubAccounts",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "SubAccounts",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "SubAccounts",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "JournalEntryLines",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "JournalEntryLines",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "JournalEntryLines",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "VoidedReason",
                table: "JournalEntries",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "JournalEntries",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "JournalEntries",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "JournalEntries",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "IndividualAccounts",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "IndividualAccounts",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "IndividualAccounts",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "EntryTemplateLines",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "EntryTemplateLines",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "EntryTemplateLines",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "Customers",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "Customers",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "Customers",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "CustomerContactDetail",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "CustomerContactDetail",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "CustomerContactDetail",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "Company",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "Company",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "Company",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "SubAccounts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "SubAccounts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "SubAccounts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "JournalEntryLines",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "JournalEntryLines",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "JournalEntryLines",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<string>(
                name: "VoidedReason",
                table: "JournalEntries",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "JournalEntries",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "JournalEntries",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "JournalEntries",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "IndividualAccounts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "IndividualAccounts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "IndividualAccounts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "EntryTemplateLines",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "EntryTemplateLines",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "EntryTemplateLines",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "Customers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "Customers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "Customers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "CustomerContactDetail",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "CustomerContactDetail",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "CustomerContactDetail",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ModifiedTime",
                table: "Company",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DeletionTime",
                table: "Company",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreationTime",
                table: "Company",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamptz");
        }
    }
}
