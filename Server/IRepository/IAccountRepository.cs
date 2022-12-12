using CDPModule1.Shared;

namespace CDPModule1.Server.IRepository
{
    public interface IAccountRepository
    {
        string Register(Tenant user);

        Tenant? GetUserByMail(string email);

    }
}
