using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratePdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async Task InitializeWebView()
        {
            await webView21.EnsureCoreWebView2Async(null);
        }

        private async void PrintHTMLToPDF(string htmlFilePath, string pdfFilePath)
        {
            try
            {

               
                Stopwatch stopwatch = Stopwatch.StartNew();

                await InitializeWebView();
                var generatingPdfMessageBox = MessageBox.Show("Generating PDF. Please wait...", "PDF Generation", MessageBoxButtons.OK, MessageBoxIcon.Information);

             
                webView21.CoreWebView2.Navigate("file:///" + htmlFilePath);

              
                webView21.CoreWebView2.DOMContentLoaded += async (sender, args) =>
                {
                      await webView21.CoreWebView2.PrintToPdfAsync(pdfFilePath);
                         stopwatch.Stop();
                    TimeSpan elapsedTime = stopwatch.Elapsed;

                    MessageBox.Show($"PDF saved successfully! Elapsed time: {elapsedTime.TotalSeconds} seconds", "PDF Generation", MessageBoxButtons.OK, MessageBoxIcon.Information);


                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var currentDirectory = Environment.CurrentDirectory;
            var baseDirectory = Directory.GetParent(Directory.GetParent(currentDirectory)?.FullName)?.FullName;
            var htmlFilePath = Path.Combine(baseDirectory, "Template", "template2.html");
            var pdfFilePath = Path.Combine(baseDirectory, "Downloads", "output2.pdf");
            PrintHTMLToPDF(htmlFilePath, pdfFilePath);
        }
    }
}
