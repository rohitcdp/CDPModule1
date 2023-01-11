using System.ComponentModel.DataAnnotations.Schema;

namespace CDPModule1.Shared
{
    public class User : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }    
        public string? UserType { get; set; }
        public DateTime? DOB { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? Gender { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsEmailVerified { get; set; } = false; 
        public Guid TenantId { get; set; }
        [ForeignKey("TenantId")]
        public Tenant? Tenant { get; set; }
    }
}
