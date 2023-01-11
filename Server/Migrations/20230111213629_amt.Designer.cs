﻿// <auto-generated />
using System;
using CDPModule1.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CDPModule1.Server.Migrations
{
    [DbContext(typeof(CDPDbContext))]
    [Migration("20230111213629_amt")]
    partial class amt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CDPModule1.Shared.AgencyBilling", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AcitivityDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AorBillDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AorComm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CampEndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CampStartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CampaginName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Channel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientGstn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientPos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Daypart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EST_NO")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("EndTime")
                        .HasColumnType("time");

                    b.Property<int?>("Fct")
                        .HasColumnType("int");

                    b.Property<string>("FullBillNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("GrossCost")
                        .HasColumnType("float");

                    b.Property<int?>("GrossRate")
                        .HasColumnType("int");

                    b.Property<string>("Impact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonRepNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonTelecastTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("NetCost")
                        .HasColumnType("float");

                    b.Property<int?>("NetRate")
                        .HasColumnType("int");

                    b.Property<int?>("NettCost")
                        .HasColumnType("int");

                    b.Property<string>("PaidBonus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PayableAmt")
                        .HasColumnType("int");

                    b.Property<string>("Plan_Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Program")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpotStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("StartTime")
                        .HasColumnType("time");

                    b.Property<string>("SupBno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AgencyBilling");
                });

            modelBuilder.Entity("CDPModule1.Shared.AgencyInvoiceData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Channel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Daypart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Dur")
                        .HasColumnType("int");

                    b.Property<int?>("GrossRate")
                        .HasColumnType("int");

                    b.Property<int?>("Hour")
                        .HasColumnType("int");

                    b.Property<string>("InvoiceNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NetCost")
                        .HasColumnType("int");

                    b.Property<int?>("NetRate")
                        .HasColumnType("int");

                    b.Property<string>("PlanDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Program")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan?>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("AgencyInvoiceData");
                });

            modelBuilder.Entity("CDPModule1.Shared.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("AgencyDiscount")
                        .HasColumnType("float");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CGST")
                        .HasColumnType("float");

                    b.Property<double?>("CashDiscount")
                        .HasColumnType("float");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("IGST")
                        .HasColumnType("float");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("PayableAmount")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SGST")
                        .HasColumnType("float");

                    b.Property<Guid>("TemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TotalPages")
                        .HasColumnType("int");

                    b.Property<double>("TotalTax")
                        .HasColumnType("float");

                    b.Property<Guid>("UplodedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("CDPModule1.Shared.InvoiceData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DurationInSec")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ist")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RatePerTenSec")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("int");

                    b.Property<string>("SpotType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TelecastDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceData");
                });

            modelBuilder.Entity("CDPModule1.Shared.InvoiceTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedBy")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedBy")
                        .HasColumnType("datetime2");

                    b.Property<string>("TemplateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InvoiceTemplate");
                });

            modelBuilder.Entity("CDPModule1.Shared.InvoiceTemplateInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentIdentifier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("XPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InvoiceTemplateInfo");
                });

            modelBuilder.Entity("CDPModule1.Shared.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankingDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GstNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PanNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("CDPModule1.Shared.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CDPModule1.Shared.AgencyBilling", b =>
                {
                    b.HasOne("CDPModule1.Shared.InvoiceTemplate", "InvoiceTemplate")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoiceTemplate");
                });

            modelBuilder.Entity("CDPModule1.Shared.Invoice", b =>
                {
                    b.HasOne("CDPModule1.Shared.InvoiceTemplate", "InvoiceTemplate")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CDPModule1.Shared.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("InvoiceTemplate");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CDPModule1.Shared.InvoiceData", b =>
                {
                    b.HasOne("CDPModule1.Shared.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("CDPModule1.Shared.User", b =>
                {
                    b.HasOne("CDPModule1.Shared.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });
#pragma warning restore 612, 618
        }
    }
}
