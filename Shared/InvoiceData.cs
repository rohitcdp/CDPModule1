using System.ComponentModel.DataAnnotations.Schema;

namespace CDPModule1.Shared
{

    public class InvoiceData : BaseEntity
    {
        public int SerialNumber { get; set; }
        public string Caption { get; set; }
        public string SpotType { get; set; }
        public string Category { get; set; }
        public DateTime TelecastDate { get; set; }
        public string Ist { get; set; }
        public string DurationInSec { get; set; }
        public string RatePerTenSec { get; set; }
        public double Amount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid InvoiceId { get; set; }

        [ForeignKey("InvoiceId")]
        public Invoice? Invoice { get; set; }
        /*
                public Guid UserId { get; set; }
                [ForeignKey("UserId")]
                public User? User { get; set; }
                public Guid TenantId { get; set; }
                [ForeignKey("TenantId")]
                public Tenant? Tenant { get; set; }*/
    }
}
