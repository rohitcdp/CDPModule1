namespace CDPModule1.Client.dynamicInvoice
{
    public class DynamicProps
    {
        public string CompanyName { get; set; }
        public string GST { get; set; }
        public string PAN { get; set; }
        public string InvoiceNumber { get; set; }
        public string Address { get; set; }

        public List<DynamicPropsData> InvoiceData { get; set; }

    }

    public class DynamicPropsData
    {
        public string Program { get; set; }
        public string Channel { get; set; }
        public string Day { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        public string Amount { get; set; }
    }
}
