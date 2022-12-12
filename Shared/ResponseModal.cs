using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPModule1.Shared
{
    public class ResponseModal
    {
        public int StatusCode { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
