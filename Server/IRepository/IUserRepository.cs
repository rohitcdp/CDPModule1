using CDPModule1.Shared;

namespace CDPModule1.Server.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid Id);
        Task<User> UpdateUser(User tenant);
        Task<bool> DeleteUser(Guid Id);
    }
}
