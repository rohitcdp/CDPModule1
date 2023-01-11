using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDPModule1.Server.Migrations
{
    /// <inheritdoc />
    public partial class amt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgencyInvoiceData_InvoiceTemplate_Id",
                table: "AgencyInvoiceData");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "AgencyInvoiceData",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "AgencyInvoiceData");

            migrationBuilder.AddForeignKey(
                name: "FK_AgencyInvoiceData_InvoiceTemplate_Id",
                table: "AgencyInvoiceData",
                column: "Id",
                principalTable: "InvoiceTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
