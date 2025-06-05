using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace accountingwebapi.Migrations
{
    /// <inheritdoc />
    public partial class addedJournalEntryLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_IndividualAccounts_IndividualAccountId",
                table: "JournalEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_JournalEntries_AdjustsEntryFkId",
                table: "JournalEntries");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntries_AdjustsEntryFkId",
                table: "JournalEntries");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntries_IndividualAccountId",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "AdjustsEntryFkId",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "AmountCredit",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "AmountDebit",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "IndividualAccountId",
                table: "JournalEntries");

            migrationBuilder.AlterColumn<string>(
                name: "AdjustsEntryId",
                table: "JournalEntries",
                type: "character varying(26)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(26)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "JournalEntries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "JournalEntryLine",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    JournalEntryId = table.Column<string>(type: "character varying(26)", nullable: false),
                    IndividualAccountId = table.Column<string>(type: "character varying(26)", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,5)", nullable: false),
                    IsDebit = table.Column<bool>(type: "boolean", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreationTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    IsModified = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeletionTime = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalEntryLine_IndividualAccounts_IndividualAccountId",
                        column: x => x.IndividualAccountId,
                        principalTable: "IndividualAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalEntryLine_JournalEntries_JournalEntryId",
                        column: x => x.JournalEntryId,
                        principalTable: "JournalEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_AdjustsEntryId",
                table: "JournalEntries",
                column: "AdjustsEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_IndividualAccountId",
                table: "JournalEntryLine",
                column: "IndividualAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntryLine_JournalEntryId",
                table: "JournalEntryLine",
                column: "JournalEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_JournalEntries_AdjustsEntryId",
                table: "JournalEntries",
                column: "AdjustsEntryId",
                principalTable: "JournalEntries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_JournalEntries_AdjustsEntryId",
                table: "JournalEntries");

            migrationBuilder.DropTable(
                name: "JournalEntryLine");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntries_AdjustsEntryId",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "JournalEntries");

            migrationBuilder.AlterColumn<string>(
                name: "AdjustsEntryId",
                table: "JournalEntries",
                type: "character varying(26)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(26)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdjustsEntryFkId",
                table: "JournalEntries",
                type: "character varying(26)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountCredit",
                table: "JournalEntries",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AmountDebit",
                table: "JournalEntries",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "IndividualAccountId",
                table: "JournalEntries",
                type: "character varying(26)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_AdjustsEntryFkId",
                table: "JournalEntries",
                column: "AdjustsEntryFkId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_IndividualAccountId",
                table: "JournalEntries",
                column: "IndividualAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_IndividualAccounts_IndividualAccountId",
                table: "JournalEntries",
                column: "IndividualAccountId",
                principalTable: "IndividualAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_JournalEntries_AdjustsEntryFkId",
                table: "JournalEntries",
                column: "AdjustsEntryFkId",
                principalTable: "JournalEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
