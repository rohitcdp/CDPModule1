using System.ComponentModel.DataAnnotations.Schema;

namespace CDPModule1.Shared
{
    public class Invoice : BaseEntity
    {
        public string BrandName { get; set; }
        public string ClientName { get; set; }
        public string ProductName { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime DueDate { get; set; }
        public string InvoiceName { get; set; }
        public string FileName { get; set; }
        public double Amount { get; set; }
        public double? AgencyDiscount { get; set; }
        public double? CashDiscount { get; set; }
        public double CGST { get; set; } = 0;
        public double SGST { get; set; } = 0;
        public double IGST { get; set; } = 0;
        public double TotalTax { get; set; } = 0;
        public double PayableAmount { get; set; }
        public int TotalPages { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid UplodedBy { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public Guid TemplateId { get; set; }
        [ForeignKey("Id")]
        public InvoiceTemplate InvoiceTemplate { get; set; }
    }
}
