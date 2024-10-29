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
        foreach (PdfLoadedAnnotation annotation in page.Annotations)
        {
            // Check if the annotation is a hyperlink
            if (annotation is PdfLoadedUriAnnotation)
            {
                PdfLoadedUriAnnotation uriAnnotation = annotation as PdfLoadedUriAnnotation;

                // Modify the existing URL
                uriAnnotation.Uri = "https://www.syncfusion.com/succinctly-free-ebooks/pdf";
            }
            else if (annotation is PdfLoadedTextWebLinkAnnotation)
            {
                PdfLoadedTextWebLinkAnnotation linkAnnotation = annotation as PdfLoadedTextWebLinkAnnotation;

                // Modify existing URL
                linkAnnotation.Url = "https://www.syncfusion.com/succinctly-free-ebooks/pdf";
            }
        }
        using (FileStream outputStream = new FileStream("modify-existing-hyperlinks.pdf", FileMode.Create, FileAccess.ReadWrite))
        {
            // Save the modified document
            loadedDocument.Save(outputStream);
        }

    }
}

