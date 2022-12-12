namespace CDPModule1.Server.Authentication
{
    public static class UserValidate
    {
        private static readonly CDPDbContext dbContext;

        //This method is used to check the user credentials
        public static bool IsValid(string username, string password)
        {
            var users = dbContext.Tenants.ToList();
            return users.Any(user =>
                user.Name.Equals(username, StringComparison.OrdinalIgnoreCase)
                && user.Password == password);
        }
    }
}
