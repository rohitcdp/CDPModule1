using CDPModule1.Shared;
using Microsoft.EntityFrameworkCore;

namespace CDPModule1.Server.DataSeed
{
    public class SeedData
    {
        public static async Task SeedAdminData(CDPDbContext cdpContext)
        {
            var users=await cdpContext.Tenants.Where(x=>x.Email=="test@admin.com").ToListAsync();

            if (users.Count<=0)
            {
                var admin = new Tenant
                {
                    Email= "test@admin.com",
                    Password="admin@qaz#",
                    Name="admin",
                    UserType="Admin",

                };

               await cdpContext.Tenants.AddAsync(admin);
                await cdpContext.SaveChangesAsync();
            }
        }
    }
}
