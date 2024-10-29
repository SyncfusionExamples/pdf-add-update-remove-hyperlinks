// See https://aka.ms/new-console-template for more information


using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;


// Register the Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your license key");

// Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    // Create a new page
    PdfPage page = document.Pages.Add();

    // Draw string
    page.Graphics.DrawString("Click here to open an external file", new PdfStandardFont(PdfFontFamily.Helvetica, 12), PdfBrushes.Black, new PointF(10, 40));

    // Define the bounds for the link annotation
    RectangleF bounds = new RectangleF(10, 40, 180, 14);

    // Specify the file path for the external document
    string filePath = "data/Adventure Works Cycles.docx";

    // Create a link annotation to the external file
    PdfFileLinkAnnotation fileLinkAnnotation = new PdfFileLinkAnnotation(bounds, filePath);

    // Add the annotation to the page
    page.Annotations.Add(fileLinkAnnotation);

    // Save the PDF document
    using (FileStream outputStream = new FileStream("external-document-navigation.pdf", FileMode.Create, FileAccess.Write))
    {
        document.Save(outputStream);
    }
}

