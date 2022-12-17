using CDPModule1.Shared;
using Microsoft.EntityFrameworkCore;

namespace CDPModule1.Server.DataSeed
{
    public class SeedData
    {
        public static async Task SeedAdminData(CDPDbContext cdpContext)
        {
            var existantUser = await cdpContext.Users.Where(x=>x.Email=="test@admin.com").ToListAsync();

            if (existantUser.Count<=0)
            {
                //adding tenant
                var tenant = new Tenant
                {
                    Email = "test@tenant.com",
                    Name = "Default Tenant",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    Contact = 9999999999 + "",
                    IsDeleted = false

                };
                await cdpContext.Tenants.AddAsync(tenant);
                await cdpContext.SaveChangesAsync();

                //adding admin
                var admin = new User
                {
                    Email = "test@admin.com",
                    Password = "admin@qaz#",
                    Name = "admin",
                    UserType = "admin",
                    TenantId= tenant.Id,
                    IsDeleted = false,
                    IsEmailVerified= false
                };

                await cdpContext.Users.AddAsync(admin);
                await cdpContext.SaveChangesAsync();
            }
        }
    }
}
