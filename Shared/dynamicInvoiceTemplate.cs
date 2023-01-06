using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDPModule1.Shared
{
    public class dynamicInvoiceTemplateVM : BaseEntity
    {
        public string TemplateName { get; set; }
        public string FieldName { get; set; }
        public string ParentIdentifier { get; set; }
        public string XPosition { get; set; }
        public string YPosition { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }
    }

    public class InvoiceTemplate : BaseEntity
    {
        public string TemplateName { get; set; }
        public string FieldName { get; set; }
        public string ParentIdentifier { get; set; }
        public string XPosition { get; set; }
        public string YPosition { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }


        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
    public class AgencyBilling : BaseEntity
    {
        public string CHANNEL { get; set; }
        public string PROGRAM { get; set; }
        public string DAY { get; set; }
        public TimeOnly START_TIME { get; set; }
        public TimeOnly END_TIME { get; set; }
        public string Daypart { get; set; }
        public string Plan_Details { get; set; }
        public string TITLE { get; set; }
        public int FCT { get; set; }
        public string SPOT_STATUS { get; set; }
        public DateTime ACTIVITY_DATE { get; set; }
        public string Paid_Bonus { get; set; }
        public string Impact { get; set; }
        public int GrossRate { get; set; }
        public int NetRate { get; set; }
        public double GrossCost { get; set; }
        public double NetCost { get; set; }
        public int EST_NO { get; set; }
        public string CAMPAIGN_NAME { get; set; }
        public string MON_REP_NO { get; set; }
        public string REMARKS { get; set; }
        public string MON_TELECAST_TIME { get; set; }
        public string FULL_BILL_NUMBER { get; set; }
        public string SUP_BNO { get; set; }
        public string SUP_DATE { get; set; }
        public string PO_NUMBER { get; set; }
        public string CLIENT_GSTN { get; set; }
        public string CLIENT_POS { get; set; }
        public int PAYABLE_AMT { get; set; }
        public string AOR_COMM { get; set; }
        public int NETT_COST { get; set; }
        public string AOR_BILL_DATE { get; set; }
        public string Camp_Start_Date { get; set; }
        public string Camp_End_Date { get; set; }
    }

    public class AgencyInvoiceData : BaseEntity
    {
        public string InvoiceNo { get; set; }
        public string Channel { get; set; }
        public string Program { get; set; }
        public string Caption { get; set; }
        public string Date { get; set; }
        public string Day { get; set; }
        public TimeOnly Time { get; set; }
        public int Hour { get; set; }
        public int NetRate { get; set; }
        public int Dur { get; set; }
        public int NetCost { get; set; }
        public int GrossRate   { get; set; }
        public string Daypart { get; set; }
        public string PlanDetails  { get; set; }
        public string Comments { get; set; }
    }


}
