using gb= GemBox.Spreadsheet;
using OfficeOpenXml;
using Spire.Xls;
using System.Text;

namespace CDPModule1.Server.Helper
{
    public class Helper
    {


        public static void XlsxToHTML(string filePath)
        {
            // If using the Professional version, put your serial key below.
            gb.SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            var workbook = gb.ExcelFile.Load(filePath);
            var worksheet = workbook.Worksheets[0];

            // Set some ExcelPrintOptions properties for HTML export.
            worksheet.PrintOptions.PrintHeadings = true;
            worksheet.PrintOptions.PrintGridlines = true;

            // Specify cell range which should be exported to HTML.
            worksheet.NamedRanges.SetPrintArea(worksheet.Cells.GetSubrange("A1", "J42"));

            var options = new gb.HtmlSaveOptions()
            {
                HtmlType = gb.HtmlType.Html,
                SelectionType = gb.SelectionType.EntireFile
            };

            workbook.Save("HtmlExport.html", options);
        }
        public static string XlsxToHTML(byte[] file)
        {
            MemoryStream stream = new MemoryStream(file);
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("<table>");

            try
            {
                using (ExcelPackage excelPackage = new ExcelPackage(stream))
                {
                    ExcelWorkbook workbook = excelPackage.Workbook;
                    if (workbook != null)
                    {
                        ExcelWorksheet worksheet = workbook.Worksheets.FirstOrDefault();
                        if (worksheet != null)
                        {
                            var firstCell = worksheet.Cells[1, 1].Value;
                            var secondCell = worksheet.Cells[1, 2].Value;

                            stringBuilder.Append("<tr><td>" + firstCell + "</td></tr>");
                            stringBuilder.Append("<tr><td>" + firstCell + "</td></tr>");
                        }
                    }
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            stringBuilder.Append("</table>");

            return stringBuilder.ToString();
        }
    }
}
