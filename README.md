# Steps for Generating PDF file from HTML Template using Playwright.

1. Create the console Application.

2. Install the Microsoft.Playwright.NUnit package from Nuget packet manager tools
					(or)
   Run the below command in the package manager console 
	dotnet add package Microsoft.Playwright.NUnit.

3. Create one folder called Tempates. Place all the Html templates inside that folder.

4. Inside the Program.cs write the script for generating PDF from HTML template.

5. After done all the above steps run the project.
_________________________________________________________


# Steps for Generating PDF from Html template using Web Api

1. Make sure to exist Microsift edge Webview2 runtime in our local machine. 
   We need to check Apps->Installed Apps Whether the above runtime exist. If not make sure to install.

2. Create the Web Api Project from Visual Studio.

3. Install Westwind.WebView.HtmlToPdf from Package manager tools
				(or)
   Run the below command inside the package manager console.
	dotnet add package westwind.webview.htmltopdf

4. Create one folder called Templates. Place all the Html templates inside the templates folder.

5. Create one contrller with your custom constroller name. Write all the logic for Generating Html to Pdf inside the controller.

6. After done all the above steps run the project.
_________________________________________________________

# Steps for Generating PDF from Html template using WebView2

1. Installed Canary Channel WebView2 runtime package in Local Machine from the following URL.

   	https://www.microsoft.com/en-us/edge/download/insider?form=MA13FJ
   
2. Created Windows Form Application in Visual Studio.
3. Install following package for generating PDF.

	dotnet add package Microsoft.Web.WebView2 --version 1.0.2365.46
   
4. Implement logic for Generating PDF from Html template inside Form.cs file.
5. Add the WebView2 Control to the Form by drag and drop.
6. Expand the webview2 to cover whole form.
7. Run the application.
