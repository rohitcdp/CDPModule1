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
            var t= await dbContext.Tenants.ToListAsync();
            return t;
        }

        public async Task<Tenant> GetById(Guid Id)
        {
            return await dbContext.Tenants.Where(x=>x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<Tenant> UpdateTenant(Tenant tenant)
        {
            dbContext.Tenants.Update(tenant);
            await dbContext.SaveChangesAsync();
            return tenant;
        }
        public async Task<bool> DeleteTenant(Tenant tenant)
        {
            try
            {
                var users = await dbContext.Users.Where(x => x.TenantId == tenant.Id).Select(x=>x).ToListAsync();
                if(users.Count <= 0)
                {
                    dbContext.Tenants.Remove(tenant);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
