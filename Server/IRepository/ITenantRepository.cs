using CDPModule1.Shared;

namespace CDPModule1.Server.IRepository
{
    public interface ITenantRepository
    {
        Task<List<Tenant>> GetAllTenants();
        Task<Tenant> GetById(Guid Id);
        Task<Tenant> UpdateTenant(Tenant tenant);
        Task<bool> DeleteTenant(Tenant tenant);
    }
}
