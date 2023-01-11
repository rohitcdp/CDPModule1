using System.ComponentModel.DataAnnotations.Schema;

namespace CDPModule1.Shared
{
    public class AgencyInvoiceData : BaseEntity
    {
        public string? InvoiceNo { get; set; }
        public string? Channel { get; set; }
        public string? Program { get; set; }
        public string? Caption { get; set; }
        public string? Date { get; set; }
        public string? Day { get; set; }
        public TimeSpan? Time { get; set; }
        public int? Hour { get; set; }
        public int? NetRate { get; set; }
        public int? Dur { get; set; }
        public int? NetCost { get; set; }
        public int? GrossRate { get; set; }
        public string? Daypart { get; set; }
        public string? PlanDetails { get; set; }
        public string? Comments { get; set; }
        public Guid? TemplateId { get; set; }
        public double Amount { get; set; }
        //[ForeignKey("Id")]
        //public InvoiceTemplate? InvoiceTemplate { get; set; }

        //public Guid? AgencyBillingId { get; set; }
    }
}