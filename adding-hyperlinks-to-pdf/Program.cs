// See https://aka.ms/new-console-template for more information

using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;


//Register your Syncfusion license key
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your License Key");

//Create a new PDF document
using (PdfDocument document = new PdfDocument())
{

    //Add a page to the document
    PdfPage page = document.Pages.Add();

    //Create text web link
    PdfTextWebLink textWebLink = new PdfTextWebLink()
    {
        //Set the text to display
        Text = "Click here to access Syncfusion .NET components and controls",

        //Set the hyperlink
        Url = "https://www.syncfusion.com/",

        //Set brush
        Brush = PdfBrushes.Blue,

        //Create font and set to the text web link
        Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12)
    };

    //Draw the text web link
    textWebLink.DrawTextWebLink(page, new PointF(10, 50));

    // Save the PDF document
    using (FileStream outputStream = new FileStream("hyperlink-pdf.pdf", FileMode.Create, FileAccess.Write))
    {
        document.Save(outputStream);
    }
}

