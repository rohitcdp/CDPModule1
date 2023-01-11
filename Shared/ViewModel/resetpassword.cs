using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPModule1.Shared.ViewModel
{
    public class resetpasswordmodel
    {
         public string? ResendPassword { get; set; }
        public string? ResetPassword { get; set; }
        public Guid id { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
