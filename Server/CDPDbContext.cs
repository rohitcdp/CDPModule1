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
    }
}
