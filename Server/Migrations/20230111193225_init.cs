using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDPModule1.Server.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTemplateInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    XPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTemplateInfo", x => x.Id);
                });

            

            migrationBuilder.CreateTable(
                name: "AgencyBilling",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Channel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    Daypart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDetails = table.Column<string>(name: "Plan_Details", type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fct = table.Column<int>(type: "int", nullable: true),
                    SpotStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcitivityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaidBonus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Impact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossRate = table.Column<int>(type: "int", nullable: true),
                    NetRate = table.Column<int>(type: "int", nullable: true),
                    GrossCost = table.Column<double>(type: "float", nullable: true),
                    NetCost = table.Column<double>(type: "float", nullable: true),
                    ESTNO = table.Column<int>(name: "EST_NO", type: "int", nullable: true),
                    CampaginName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonRepNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonTelecastTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullBillNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupBno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientGstn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientPos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayableAmt = table.Column<int>(type: "int", nullable: true),
                    AorComm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NettCost = table.Column<int>(type: "int", nullable: true),
                    AorBillDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampStartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampEndDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyBilling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgencyBilling_InvoiceTemplate_Id",
                        column: x => x.Id,
                        principalTable: "InvoiceTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgencyInvoiceData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Channel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Program = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<TimeSpan>(type: "time", nullable: true),
                    Hour = table.Column<int>(type: "int", nullable: true),
                    NetRate = table.Column<int>(type: "int", nullable: true),
                    Dur = table.Column<int>(type: "int", nullable: true),
                    NetCost = table.Column<int>(type: "int", nullable: true),
                    GrossRate = table.Column<int>(type: "int", nullable: true),
                    Daypart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyInvoiceData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgencyInvoiceData_InvoiceTemplate_Id",
                        column: x => x.Id,
                        principalTable: "InvoiceTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    AgencyDiscount = table.Column<double>(type: "float", nullable: true),
                    CashDiscount = table.Column<double>(type: "float", nullable: true),
                    CGST = table.Column<double>(type: "float", nullable: false),
                    SGST = table.Column<double>(type: "float", nullable: false),
                    IGST = table.Column<double>(type: "float", nullable: false),
                    TotalTax = table.Column<double>(type: "float", nullable: false),
                    PayableAmount = table.Column<double>(type: "float", nullable: false),
                    TotalPages = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UplodedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceTemplate_Id",
                        column: x => x.Id,
                        principalTable: "InvoiceTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpotType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelecastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationInSec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatePerTenSec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceData_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceData_InvoiceId",
                table: "InvoiceData",
                column: "InvoiceId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgencyBilling");

            migrationBuilder.DropTable(
                name: "AgencyInvoiceData");

            migrationBuilder.DropTable(
                name: "InvoiceData");

            migrationBuilder.DropTable(
                name: "InvoiceTemplateInfo");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "InvoiceTemplate");

           
        }
    }
}
