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
        [System.Web.Http.Route("uploadPdf")]

        public async Task<ActionResult<List<UploadResult>>> uploadPdf(List<IFormFile> files)
        {
            List<UploadResult> uploadResults = new List<UploadResult>();

            foreach (var file in files)
            {
                string ext = Path.GetExtension(file.FileName);
                var uploadResult = new UploadResult();
                string trustedFileNameForFileStorage;
                var untrustedFileName = file.FileName;
                uploadResult.FileName = untrustedFileName;

                trustedFileNameForFileStorage = Path.GetRandomFileName().Split('.')[0]+ext;
                var path = Path.Combine("C:\\Users\\Administrator\\source\\repos\\rohitcdp\\CDPModule1\\Server\\pdfs", trustedFileNameForFileStorage);

                await using FileStream fs = new(path, FileMode.Create);
                await file.CopyToAsync(fs);

               
                var doc = new GcPdfDocument();
                doc.Load(fs);
                //To extract Page 1
                var tmap_page2 = doc.Pages[0].GetTextMap();
                tmap_page2.GetFragment(out TextMapFragment newFragment, out string Extractedtext);


                //file upload
                uploadResult.StoredFileName = trustedFileNameForFileStorage;
                uploadResult.ContentType = file.ContentType;
                uploadResults.Add(uploadResult);

                //cdpContext.FileUploads.Add(uploadResult);
            }

            //await cdpContext.SaveChangesAsync();

            return Ok(uploadResults);
        }



        [HttpPost]
        [System.Web.Http.Route("upload")]
        public ResponseModal UploadFile([FromBody] IFormFile formFile)
        {
            try
            {
                StringBuilder text = new StringBuilder();
                string path = Path.Combine("C:\\Users\\Administrator\\Documents\\CDP", formFile.FileName);
                PdfReader pdfReader = new PdfReader(path);
                PdfDocument pdfDocument = new PdfDocument(pdfReader);
                for (int index = 1; index <= pdfDocument.GetNumberOfPages(); index++)
                {
                    ITextExtractionStrategy strategy = new LocationTextExtractionStrategy();
                    var page = pdfDocument.GetPage(index);
                    string currentText = PdfTextExtractor.GetTextFromPage(page, strategy);
                    currentText = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.UTF8.GetBytes(currentText)));
                    text.Append(currentText);
                }
                pdfReader.Close();
               
                return new ResponseModal();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
