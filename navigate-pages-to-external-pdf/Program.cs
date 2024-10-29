// See https://aka.ms/new-console-template for more information

using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

// Register the Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Your License Key");

//Create a new PDF document
using (PdfDocument document = new PdfDocument())
{
    //Create a new page
    PdfPage page = document.Pages.Add();

    //Create a new remote destination
    PdfRemoteDestination remoteDestination = new PdfRemoteDestination();
    //Set the remote PDF page number (specify it as page index)
    remoteDestination.RemotePageNumber = 3;
    //Set the destination mode
    remoteDestination.Mode = PdfDestinationMode.FitToPage;
    //Create a new PdfRemoteGoToAction and mention the remote PDF file name and remote destination
    PdfRemoteGoToAction goToAction = new PdfRemoteGoToAction("input.pdf", remoteDestination);
    //Set the to open in new window
    goToAction.IsNewWindow = true;

    //Create a new PdfButtonField
    PdfButtonField submitButton = new PdfButtonField(page, "gotoActionButton");
    submitButton.Bounds = new RectangleF(25, 25, 250, 20);
    submitButton.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Bold);
    submitButton.Text = "Click here to open the external PDF file";
    submitButton.BackColor = new PdfColor(181, 191, 203);
    //Add the action to the button.
    submitButton.Actions.GotFocus = goToAction;
    //Add the submit button to a new document
    document.Form.Fields.Add(submitButton);

    using (FileStream outputStream = new FileStream("navigate-pages-to-external-pdf.pdf", FileMode.Create, FileAccess.Write))
    {
        document.Save(outputStream);
    }
}


