using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPModule1.Shared
{
    public class Header : BaseEntity
    {
        public string? PAN { get; set; }
        public string? InvoiceNumber { get; set; }

        public string? GSTIN { get; set; }

    }
}
