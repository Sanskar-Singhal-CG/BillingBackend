using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingDB_Backend.Migrations
{
    /// <inheritdoc />
    public partial class removeFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerContactPerson",
                table: "Invoices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerContactPerson",
                table: "Invoices",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
