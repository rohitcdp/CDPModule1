using CDPModule1.Server.Authentication;
using CDPModule1.Server.IRepository;
using CDPModule1.Server.Utils;
using CDPModule1.Shared;
using Microsoft.EntityFrameworkCore;
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

        public async Task<User> CreateUser(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            await Task.FromResult(dbContext.Users.Update(user));
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<Tenant> CreateTenant(Tenant tenant)
        {
            await dbContext.Tenants.AddAsync(tenant);
            await dbContext.SaveChangesAsync();
            return tenant;
        }
        public async Task<User?> GetUserByMail(string email)
        {
            return await dbContext.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetAllUsers()=> await dbContext.Users.ToListAsync();
        public async Task<List<User>> GetTenantUsers(Guid tenantId) => await dbContext.Users.Where(x=>x.TenantId==tenantId).ToListAsync();
        
    }
}
