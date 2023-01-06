using System.ComponentModel.DataAnnotations.Schema;

namespace CDPModule1.Shared
{
    public class AgencyBilling : BaseEntity
    {
        public Guid? TemplateId { get; set; }
        [ForeignKey("Id")]
        public InvoiceTemplate? InvoiceTemplate { get; set; }
        public string? Channel { get; set; }
        public string? Program { get; set; }
        public string? Day { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? Daypart { get; set; }
        public string? Plan_Details { get; set; }
        public string? Title { get; set; }
        public int? Fct { get; set; }
        public string? SpotStatus { get; set; }
        public DateTime? AcitivityDate { get; set; }
        public string? PaidBonus { get; set; }
        public string? Impact { get; set; }
        public int? GrossRate { get; set; }
        public int? NetRate { get; set; }
        public double? GrossCost { get; set; }
        public double? NetCost { get; set; }
        public int? EST_NO { get; set; }
        public string? CampaginName { get; set; }
        public string? MonRepNo { get; set; }
        public string? Remark { get; set; }
        public string? MonTelecastTime { get; set; }
        public string? FullBillNumber { get; set; }
        public string? SupBno { get; set; }
        public string? SupDate { get; set; }
        public string? PoNumber { get; set; }
        public string? ClientGstn { get; set; }
        public string? ClientPos { get; set; }
        public int? PayableAmt { get; set; }
        public string AorComm { get; set; }
        public int? NettCost { get; set; }
        public string? AorBillDate { get; set; }
        public string? CampStartDate { get; set; }
        public string? CampEndDate { get; set; }
    }
}