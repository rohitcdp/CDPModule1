﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPModule1.Shared.RequestModel
{
    public class ForgotPassword
    {
        public string Email { get; set; }

        public string? Password { get; set; }
    }
}
