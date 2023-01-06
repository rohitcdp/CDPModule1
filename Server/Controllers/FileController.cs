using CDPModule1.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using System.Text;
using GrapeCity.Documents.Pdf.TextMap;
using GrapeCity.Documents.Pdf;
using System;
using Spire.Pdf;
using PdfDocument = Spire.Pdf.PdfDocument;
using CDPModule1.Server.Utils;
using iText.Html2pdf.Attach.Impl.Layout;
using System.Xml;
using System.Text.RegularExpressions;
//using Spire.Xls;

namespace CDPModule1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FileController : ControllerBase
    {
        private readonly CDPDbContext cdpContext;

        public FileController(CDPDbContext _cdpContext)
        {
            cdpContext = _cdpContext;
        }

        [HttpPost]
        [Route("SaveTemplate")]
        [AllowAnonymous]
        public async Task<List<DynamicInvoiceTemplateVM>> SaveTemplate([FromBody] List<DynamicInvoiceTemplateVM> di)
        {
            return di;
        }

        [HttpPost]
        [Route("uploadPdf")]
        public async Task<string> uploadPdf(FileResultContent fileContent)
        {
            try
            {
                List<UploadResult> uploadResults = new List<UploadResult>();

             
                byte[] file = Convert.FromBase64String(fileContent.base64Content);
                string ext = fileContent.fileExt;
                var uploadResult = new UploadResult();
                string trustedFileNameForFileStorage;
                var untrustedFileName = fileContent.existingFileName;//file.FileName;
                uploadResult.FileName = untrustedFileName;

                trustedFileNameForFileStorage = fileContent.newFileName + "." + ext;//Path.GetRandomFileName().Split('.')[0] + ext;
                var path = Path.Combine("C:\\Users\\Administrator\\source\\repos\\rohitcdp\\CDPModule1\\Server\\pdfs", trustedFileNameForFileStorage);

                await using FileStream fs = new(path, FileMode.Create);
                // await file.CopyToAsync(fs);

                //reading pdf
                var doc = new GcPdfDocument();
                doc.Load(new MemoryStream(file));

                //To extract Page 1
                var tmap_page2 = doc.Pages[0].GetTextMap();
                tmap_page2.GetFragment(out TextMapFragment newFragment, out string Extractedtext);
                //file upload
                uploadResult.StoredFileName = trustedFileNameForFileStorage;
                uploadResult.ContentType = "pdf";
                uploadResults.Add(uploadResult);
                fs.Close();
                System.IO.File.WriteAllBytes(path, file);

                string dat=await ExportPDFToExcel(Path.GetFileNameWithoutExtension(trustedFileNameForFileStorage), path);
                var newpath = Path.GetFullPath("C:/Users/Administrator/source/repos/rohitcdp/CDPModule1/Server/htmlfiles/" + Path.GetFileNameWithoutExtension(trustedFileNameForFileStorage) + ".html");

                string d = dat;// System.IO.File.ReadAllText(newpath);
                int index1 = d.IndexOf("<body");
                int index2 = d.IndexOf("</body>");
                string substr = d.Substring(index1, d.Length - index1);
                substr = substr.Replace("</html>", string.Empty);
                int countDef = Regex.Matches(substr, "<defs>").Count();

                //for (int i = 0; i < countDef; i++)
                //{
                //    if (substr.Contains("<defs>"))
                //    {
                //        int index = substr.IndexOf("<defs>");
                //        substr = substr.Remove(index, substr.IndexOf("</defs>"));
                //    }
                //}

                substr = substr.Replace("<text", "<text class='pickText' onclick=getText(this)");
                substr = substr.Replace("url(#clip", "CustomId");
                substr = substr.Replace("clip-path", "id");
                substr = substr.Replace(")\">", "\">");
                substr = substr.Replace("<image", "<image style=\"display:none\"");
                return substr;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private async Task<string> ExportPDFToExcel(string fileName, string path)
        {
            try
            {
                PdfDocument pdf = new PdfDocument(path);
                int pageCount = pdf.Pages.Count;
                pdf.LoadFromFile(path);
                MemoryStream ms= new MemoryStream();
                pdf.SaveToStream(ms,FileFormat.HTML);
                var data = System.Text.Encoding.Default.GetString(ms.ToArray());
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("ReadHtml")]
        [AllowAnonymous]
        public ResponseModal GetHtmlContent(string path)
        {
            path = Path.GetFullPath(path);
            var d = System.IO.File.ReadAllText(path);
            return new ResponseModal { Data = d, Message = StatusConstant.SUCCESS, StatusCode = 200 };
        }
    }
}
    
    //[HttpPost]
        //[System.Web.Http.Route("upload")]
        //public ResponseModal UploadFile([FromBody] IFormFile formFile)
        //{
        //    try
        //    {
        //        StringBuilder text = new StringBuilder();
        //        string path = Path.Combine("C:\\Users\\Administrator\\Documents\\CDP", formFile.FileName);
        //        PdfReader pdfReader = new PdfReader(path);
        //        PdfDocument pdfDocument = new PdfDocument(pdfReader);
        //        for (int index = 1; index <= pdfDocument.GetNumberOfPages(); index++)
        //        {
        //            ITextExtractionStrategy strategy = new LocationTextExtractionStrategy();
        //            var page = pdfDocument.GetPage(index);
        //            string currentText = PdfTextExtractor.GetTextFromPage(page, strategy);
        //            currentText = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.UTF8.GetBytes(currentText)));
        //            text.Append(currentText);
        //        }
        //        pdfReader.Close();

        //        return new ResponseModal();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //}
        //}