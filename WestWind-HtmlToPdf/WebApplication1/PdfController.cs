using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Westwind.WebView.HtmlToPdf;

namespace WebApplication1
{

    [ApiController]
    [Route("pdf")]
    public class PdfController : ControllerBase
    {
        Stopwatch stopwatch = new Stopwatch();
        [HttpGet]
       public async Task<object> Get()
       {
            var file = Path.GetFullPath("./Templates/2.html");

            var pdf = new HtmlToPdfHost();
            var pdfResult = await pdf.PrintToPdfStreamAsync(file, new WebViewPrintSettings { PageRanges = "1-5" });

            if (pdfResult == null || !pdfResult.IsSuccess) 
            {
                return new
                {
                    IsError = true,
                    Message = pdfResult.Message
                };                
            }
            Response.StatusCode = 200;

            return new
            {
                IsError = false,
                PdfBytes = (pdfResult.ResultStream as MemoryStream).ToArray()
            };
       }

        [HttpGet("rawpdf")]
        public async Task<IActionResult> RawPdf()
        {
            stopwatch.Start();
            var file = Path.GetFullPath("./Templates/2.html");

            var pdf = new HtmlToPdfHost();
            var pdfResult = await pdf.PrintToPdfStreamAsync(file, new WebViewPrintSettings {  PageRanges = "1-20"});

            if (pdfResult == null || !pdfResult.IsSuccess)
            {
                Response.StatusCode = 500;                
                return new JsonResult(new
                {
                    isError = true,
                    message = pdfResult.Message
                });
            }
            stopwatch.Stop();
            Console.Out.WriteLine("Time taken " + stopwatch.Elapsed.TotalSeconds + " seconds in rawpdf action");
            return new FileStreamResult(pdfResult.ResultStream, "application/pdf");           
        }

        [HttpGet("rawpdfex")]
        public async Task<IActionResult> RawPdfEx()
        {
            stopwatch.Start();
            var file = Path.GetFullPath("./Templates/2.html");

            var pdf = new HtmlToPdfHost();
            var pdfResult = await pdf.PrintToPdfStreamAsync(file, new WebViewPrintSettings { PageRanges = "1-20" });

            if (pdfResult == null || !pdfResult.IsSuccess)
            {
                Response.StatusCode = 500;
                return new JsonResult(new
                {
                    isError = true,
                    message = pdfResult.Message
                });
            }
            stopwatch.Stop();
            Console.Out.WriteLine("Time taken "+stopwatch.Elapsed.TotalSeconds + " seconds in rawpdfex action");
            return new FileStreamResult(pdfResult.ResultStream, "application/pdf");
        }

        [HttpGet("ping")]
        public object Ping()
        {
            return new
            {
                Message = "Hello World.",
                Time = DateTime.Now,
                User = Environment.UserName,
                LoggedOnUser = User?.Identity?.Name
            };
        }
    }
}
