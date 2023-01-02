using CDPModule1.Server.IRepository;
using CDPModule1.Shared;
using Microsoft.EntityFrameworkCore;

namespace CDPModule1.Server.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CDPDbContext dbContext;

        public UserRepository(CDPDbContext cdpContext)
        {
            dbContext = cdpContext;
        }
        
        public async Task<User> GetById(Guid Id)
        {
            return await dbContext.Users.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteUser(Guid Id)
        {
            try
            {
                User user = await dbContext.Users.Where(x => x.Id == Id).FirstOrDefaultAsync();
                dbContext.Users.Remove(user);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
