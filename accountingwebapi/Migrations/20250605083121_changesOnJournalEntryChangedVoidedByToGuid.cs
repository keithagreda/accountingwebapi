using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace accountingwebapi.Migrations
{
    /// <inheritdoc />
    public partial class changesOnJournalEntryChangedVoidedByToGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VoidedBy",
                table: "JournalEntries",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "JournalEntries");
        }
    }
}
