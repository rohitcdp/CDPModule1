using CDPModule1.Shared;

namespace CDPModule1.Server.IServices
{
    public interface ITenantService
    {
        Task<List<Tenant>> GetAllTenants();
        Task<Tenant> GetById(Guid Id);
    }
}
