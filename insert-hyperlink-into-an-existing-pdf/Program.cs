// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

//Register your Syncfusion license key
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your License Key");

// Read the PDF file as stream
using (FileStream inputPdfFileStream = new FileStream("data/input.pdf", FileMode.Open, FileAccess.Read))
{
    // Load the PDF document
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(inputPdfFileStream))
    {
        // Access the desired page (e.g., the second page)
        PdfPageBase page = loadedDocument.Pages[1];

        // Find the word and add link based on the word bounds
        List<RectangleF> matchedItems;
        loadedDocument.FindText("PDF Succinctly", 1, out matchedItems);

        //Create a PdfUriAnnotation object to place the URI link in the first image bounds
        PdfUriAnnotation pdfUriAnnotation = new PdfUriAnnotation(matchedItems[0], "https://www.syncfusion.com/succinctly-free-ebooks/pdf")
        {
            // Set the border (Empty border)
            Border = new PdfAnnotationBorder(1),
            Color = new PdfColor(Color.Blue)
        };

        // Add the annotation to the page
        page.Annotations.Add(pdfUriAnnotation);

        // Save the PDF document
        using (FileStream outputStream = new FileStream("insert-link-into-existing-pdf.pdf", FileMode.Create, FileAccess.Write))
        {
            loadedDocument.Save(outputStream);
        }
    }
}



