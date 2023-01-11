namespace CDPModule1.Shared
{
    public class InvoiceTemplateInfo : BaseEntity
    {
        public string FieldName { get; set; }
        public string Text { get; set; }
        public string ParentIdentifier { get; set; }
        public string XPosition { get; set; }
        public string YPosition { get; set; }
        public int Type { get; set; }

        public Guid TemplateId { get; set; }
        //[ForeignKey("Id")]
        //public InvoiceTemplate? InvoiceTemplate { get; set; }

    }
}