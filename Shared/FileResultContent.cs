using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPModule1.Shared
{
    public class FileResultContent
    {
        public string base64Content { get; set; }
        public string fileExt { get; set; }
        public string existingFileName { get; set; }
        public string newFileName { get; set; }
    }
}
