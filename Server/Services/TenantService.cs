using CDPModule1.Server.IRepository;
using CDPModule1.Server.IServices;
using CDPModule1.Server.Utils;
using CDPModule1.Shared;

namespace CDPModule1.Server.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ITenantRepository tenantRepository)
        {
           _tenantRepository = tenantRepository;
        }
        public async Task<List<Tenant>> GetAllTenants()
        {
            List<Tenant> tenants = await _tenantRepository.GetAllTenants();
            if(tenants.Count > 0)
            {
                return tenants;
            }
            return new List<Tenant>();

        }
    }
}
