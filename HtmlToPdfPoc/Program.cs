

namespace HtmlToPdfPoc
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var pdfGenerator = new HtmlToPdfGenerator();
            var currentDirectory = Environment.CurrentDirectory;
            var solutionDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(currentDirectory)?.FullName)?.FullName)?.FullName;
            var templatePath = Path.Combine(solutionDirectory, "Templates", "2.html");
            var outputPath = Path.Combine(solutionDirectory, "Downloads", "output2.pdf");

            //var templatePath = "E:\\Playwright\\HtmlToPdfPoc - project\\HtmlToPdfPoc\\Templates\\2.html";
            //var outputPath = "E:\\Playwright\\HtmlToPdfPoc - project\\HtmlToPdfPoc\\Downloads\\output2.pdf";

            await pdfGenerator.GeneratePdfFromHtmlTemplate(templatePath, outputPath);
        }
    }
}