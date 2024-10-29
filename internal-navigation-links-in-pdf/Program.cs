// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;

//Register your Syncfusion license key
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your License Key");

//Create a PDF document
using (PdfDocument document = new PdfDocument())
{
    // Add the first page to the document
    PdfPage firstPage = document.Pages.Add();

    // Create font to draw text on the page
    PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

    //Draw text on the page.
    firstPage.Graphics.DrawString("This is the first page.", font, PdfBrushes.Black, new PointF(10, 10));

    // Add the second page to the document
    PdfPage secondPage = document.Pages.Add();
    secondPage.Graphics.DrawString("This is the second page.", font, PdfBrushes.Black, new PointF(10, 10));

    // Define a destination for the second page
    PdfDestination destination = new PdfDestination(secondPage, new PointF(0, 0))
    {
        Mode = PdfDestinationMode.FitH, // Fit the page horizontally       
    };

    // Create a link annotation on the first page
    PdfDocumentLinkAnnotation linkAnnotation = new PdfDocumentLinkAnnotation(new RectangleF(125, 10, 200, 20));
    //Set destination for the link annotation
    linkAnnotation.Destination = destination;
    //Set the border for the link annotation
    linkAnnotation.Border = new PdfAnnotationBorder(0, 0, 0); // No border

    // Add the link annotation to the first page
    firstPage.Annotations.Add(linkAnnotation);

    //Draw the text for the link annotation for better visualization
    firstPage.Graphics.DrawString("Click here to go to the second page.", font, PdfBrushes.Blue, new PointF(125, 10));

    // Save the PDF document
    using (FileStream outputStream = new FileStream("internal-navigation.pdf", FileMode.Create, FileAccess.Write))
    {
        document.Save(outputStream);
    }
}


