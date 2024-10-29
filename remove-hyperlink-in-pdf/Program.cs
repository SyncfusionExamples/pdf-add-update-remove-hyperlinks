// See https://aka.ms/new-console-template for more information


using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;


// Register the Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your License Key");


using (FileStream fileStream = new FileStream("data/document-with-hyperlinks.pdf", FileMode.Open, FileAccess.ReadWrite))
{
    //Load the existing PDF document
    using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(fileStream))
    {
        // Access the desired page (e.g., the third page)
        PdfLoadedPage page = loadedDocument.Pages[2] as PdfLoadedPage;

        // Loop through the annotations in the page
        for (int i = page.Annotations.Count - 1; i >= 0; i--)
        {
            PdfAnnotation annotation = page.Annotations[i];
            // Check if the annotation is a hyperlink
            if (annotation is PdfLoadedUriAnnotation || annotation is PdfLoadedTextWebLinkAnnotation)
            {
                // Remove the hyperlink
                page.Annotations.Remove(annotation);
            }
        }
        using (FileStream outputStream = new FileStream("remove-hyperlinks.pdf", FileMode.Create, FileAccess.ReadWrite))
        {
            // Save the modified document
            loadedDocument.Save(outputStream);
        }
    }
}