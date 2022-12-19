using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPModule1.Shared.RequestModel
{
    public class UserModal
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public DateTime? DOB { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? Gender { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsEmailVerified { get; set; } = false;
        public Guid TenantId { get; set; }
    }
}
