using CDPModule1.Server.Authentication;
using CDPModule1.Server.IRepository;
using CDPModule1.Server.Utils;
using CDPModule1.Shared;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CDPModule1.Server.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly CDPDbContext dbContext;

        public AccountRepository(CDPDbContext cdpContext)
        {
            dbContext = cdpContext;
        }

        public string Register(Tenant user)
        {
            Tenant oldUser = dbContext.Tenants.Where(u=>u.Email == user.Email).FirstOrDefault();
            if(oldUser == null)
            {
                dbContext.Tenants.Add(user);
                dbContext.SaveChanges();
                return StatusConstant.SUCCESS;
            }
            else
            {
                return StatusConstant.USER_EXISTS;
            }
            
        }

        public Tenant? GetUserByMail(string email)
        {
            return dbContext.Tenants.Where(u => u.Email == email).FirstOrDefault();
        }
    }
}
