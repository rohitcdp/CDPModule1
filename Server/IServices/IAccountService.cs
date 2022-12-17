using CDPModule1.Shared;
using CDPModule1.Shared.RequestModel;

namespace CDPModule1.Server.IServices
{
    public interface IAccountService
    {
        Task<ResponseModal> CreateUser(User user);

        Task<ResponseModal> CreateTenant(Tenant tenant);

        Task<string> Login(AccountModal user);

    }
}
