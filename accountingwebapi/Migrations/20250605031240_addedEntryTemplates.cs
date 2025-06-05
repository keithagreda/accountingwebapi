using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace accountingwebapi.Migrations
{
    /// <inheritdoc />
    public partial class addedEntryTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryLine_IndividualAccounts_IndividualAccountId",
                table: "JournalEntryLine");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryLine_JournalEntries_JournalEntryId",
                table: "JournalEntryLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalEntryLine",
                table: "JournalEntryLine");

            migrationBuilder.RenameTable(
                name: "JournalEntryLine",
                newName: "JournalEntryLines");

            migrationBuilder.RenameIndex(
                name: "IX_JournalEntryLine_JournalEntryId",
                table: "JournalEntryLines",
                newName: "IX_JournalEntryLines_JournalEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_JournalEntryLine_IndividualAccountId",
                table: "JournalEntryLines",
                newName: "IX_JournalEntryLines_IndividualAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalEntryLines",
                table: "JournalEntryLines",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EntryTemplates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    EntryType = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_EntryTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntryTemplateLines",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(26)", nullable: false),
                    TemplateId = table.Column<string>(type: "character varying(26)", nullable: false),
                    AccountId = table.Column<string>(type: "character varying(26)", nullable: false),
                    IsDebit = table.Column<bool>(type: "boolean", nullable: false),
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
                    table.PrimaryKey("PK_EntryTemplateLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryTemplateLines_EntryTemplates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "EntryTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryTemplateLines_IndividualAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "IndividualAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntryTemplateLines_AccountId",
                table: "EntryTemplateLines",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryTemplateLines_TemplateId",
                table: "EntryTemplateLines",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryLines_IndividualAccounts_IndividualAccountId",
                table: "JournalEntryLines",
                column: "IndividualAccountId",
                principalTable: "IndividualAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryLines_JournalEntries_JournalEntryId",
                table: "JournalEntryLines",
                column: "JournalEntryId",
                principalTable: "JournalEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryLines_IndividualAccounts_IndividualAccountId",
                table: "JournalEntryLines");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntryLines_JournalEntries_JournalEntryId",
                table: "JournalEntryLines");

            migrationBuilder.DropTable(
                name: "EntryTemplateLines");

            migrationBuilder.DropTable(
                name: "EntryTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalEntryLines",
                table: "JournalEntryLines");

            migrationBuilder.RenameTable(
                name: "JournalEntryLines",
                newName: "JournalEntryLine");

            migrationBuilder.RenameIndex(
                name: "IX_JournalEntryLines_JournalEntryId",
                table: "JournalEntryLine",
                newName: "IX_JournalEntryLine_JournalEntryId");

            migrationBuilder.RenameIndex(
                name: "IX_JournalEntryLines_IndividualAccountId",
                table: "JournalEntryLine",
                newName: "IX_JournalEntryLine_IndividualAccountId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalEntryLine",
                table: "JournalEntryLine",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryLine_IndividualAccounts_IndividualAccountId",
                table: "JournalEntryLine",
                column: "IndividualAccountId",
                principalTable: "IndividualAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntryLine_JournalEntries_JournalEntryId",
                table: "JournalEntryLine",
                column: "JournalEntryId",
                principalTable: "JournalEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
