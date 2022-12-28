using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDPModule1.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedInvoiceModal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankingDetails",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankingDetails",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Tenants");
        }
    }
}
