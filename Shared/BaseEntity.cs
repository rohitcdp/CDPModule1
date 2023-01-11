using System.ComponentModel.DataAnnotations;

namespace CDPModule1.Shared
{

    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
