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
            if (tenants.Count > 0)
            {
                return tenants;
            }
            return new List<Tenant>();

        }

        public Task<Tenant> GetById(Guid Id)
        {
            return _tenantRepository.GetById(Id);
        }

        public async Task<ResponseModal> UpdateTenant(Tenant tenant)
        {
            try
            {
                return new ResponseModal { Data = await _tenantRepository.UpdateTenant(tenant), Message = StatusConstant.SUCCESS, StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new ResponseModal { Data = ex.Message, Message = StatusConstant.FAILED, StatusCode = 200 };

            }
        }

        public async Task<ResponseModal> DeleteTenant(Tenant tenant)
        {
            try
            {
                var result = await _tenantRepository.DeleteTenant(tenant);
                return new ResponseModal { Data = result ? "Succesfully Deleted" : "Tenant Has User. Not Deleted !!", Message = StatusConstant.SUCCESS, StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new ResponseModal { Data = ex.Message, Message = StatusConstant.FAILED, StatusCode = 200 };

            }
        }
    }
}