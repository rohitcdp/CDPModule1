namespace CDPModule1.Shared
{
    public class Tenant : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }    
        public string UserType { get; set; }
    }
}
