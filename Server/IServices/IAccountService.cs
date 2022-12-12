using CDPModule1.Shared;

namespace CDPModule1.Server.IServices
{
    public interface IAccountService
    {
        string Register(Tenant user);

        string Login(Tenant user);

    }
}
