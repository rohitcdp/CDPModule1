using CDPModule1.Server.IRepository;
using CDPModule1.Shared;
using Microsoft.EntityFrameworkCore;

namespace CDPModule1.Server.Repository
{
    public class TenantRepository : ITenantRepository
    {
        private readonly CDPDbContext dbContext;

        public TenantRepository(CDPDbContext cdpContext)
        {
            dbContext = cdpContext;
        }

        public async Task<List<Tenant>> GetAllTenants()
        {
            return await dbContext.Tenants.ToListAsync();
        }
    }
}
