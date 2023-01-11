namespace CDPModule1.Shared
{
    public class DynamicInvoiceTemplateVM : BaseEntity
    {
        public string TemplateName { get; set; }
        public string FieldName { get; set; }
        public string ParentIdentifier { get; set; }
        public string XPosition { get; set; }
        public string YPosition { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }


    }
}