using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPModule1.Shared
{
 
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }    
    }
}
