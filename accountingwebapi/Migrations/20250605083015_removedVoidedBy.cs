using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace accountingwebapi.Migrations
{
    /// <inheritdoc />
    public partial class removedVoidedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoidedBy",
                table: "JournalEntries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VoidedBy",
                table: "JournalEntries",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
