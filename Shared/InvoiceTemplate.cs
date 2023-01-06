namespace CDPModule1.Shared
{
    public class InvoiceTemplate : BaseEntity
    {
        public string TemplateName { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime ModifiedBy { get; set; }
    }
}