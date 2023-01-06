using CDPModule1.Shared;
using Microsoft.EntityFrameworkCore;

namespace CDPModule1.Server
{
    public class CDPDbContext:DbContext
    {
        public CDPDbContext(DbContextOptions<CDPDbContext> options) : base(options)
        {  }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AgencyBilling> AgencyBilling { get; set; }
        public DbSet<AgencyInvoiceData> AgencyInvoiceData { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceData> InvoiceData { get; set; }
        public DbSet<InvoiceTemplate> InvoiceTemplate { get; set; }
        public DbSet<InvoiceTemplateInfo> InvoiceTemplateInfo { get; set; }
    }
}
