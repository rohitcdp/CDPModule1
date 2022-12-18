using CDPModule1.Shared;

namespace CDPModule1.Server.IRepository
{
    public interface IAccountRepository
    {
       Task<User> CreateUser(User user);
       Task<User> UpdateUser(User user);

       Task<Tenant> CreateTenant(Tenant tenant);

        Task<User?> GetUserByMail(string email);

        Task<List<User>> GetAllUsers();
        Task<List<User>> GetTenantUsers(Guid tenantId);

    }
}
