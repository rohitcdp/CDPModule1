using CDPModule1.Shared;

namespace CDPModule1.Server.IServices
{
    public interface IUserService
    {
        Task<User> GetById(Guid Id);
        Task<ResponseModal> UpdateUser(User user);
        Task<ResponseModal> DeleteUser(Guid Id);
    }
}
