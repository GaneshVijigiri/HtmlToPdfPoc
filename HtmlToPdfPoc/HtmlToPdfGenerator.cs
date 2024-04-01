using Microsoft.Playwright;
using System.Diagnostics;

namespace HtmlToPdfPoc
{
    public class HtmlToPdfGenerator
    {
        private readonly IPlaywright _playwright;
        private readonly Stopwatch _stopwatch;
        public HtmlToPdfGenerator()
        {
            _playwright = Playwright.CreateAsync().GetAwaiter().GetResult();
            _stopwatch = new Stopwatch();
        }
        public async Task GeneratePdfFromHtmlTemplate(string templatePath, string outputPath)
        {
            _stopwatch.Start();
            var templateContent = File.ReadAllText(templatePath);
            using var playwright = await Playwright.CreateAsync();
            var options = new BrowserTypeLaunchOptions { ExecutablePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe" };
            await using var browser = await playwright.Chromium.LaunchAsync(options);
            await using var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.SetContentAsync(templateContent);
            
            var pdfOptions = new PagePdfOptions
            {
                Path = outputPath,
                Format = "A4",
                PrintBackground = true,
                Margin = new Margin { Top = "1cm", Right = "1cm", Bottom = "1cm", Left = "1cm" }
            };
            await page.PdfAsync(pdfOptions);

            _stopwatch.Stop();

            Console.WriteLine($"PDF generated at: {outputPath}");
            Console.WriteLine($"Time taken: {_stopwatch.Elapsed.TotalSeconds} seconds");
        }
    }
}