using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDPModule1.Server.Migrations
{
    /// <inheritdoc />
    public partial class tenantdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GstNumber",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PanNumber",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GstNumber",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "PanNumber",
                table: "Tenants");
        }
    }
}
