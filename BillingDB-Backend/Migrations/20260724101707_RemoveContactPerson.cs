using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingDB_Backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveContactPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactPerson",
                table: "Parties");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactPerson",
                table: "Parties",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
