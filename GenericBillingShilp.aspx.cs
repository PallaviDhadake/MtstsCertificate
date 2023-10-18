using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing.Layout;
using System.Globalization;

public partial class GenericBillingShilp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Define your custom page size
        double customPageWidth = 8.5 * 72;  // 8.5 inches in points (72 points = 1 inch)
        double customPageHeight = 11 * 72;  // 11 inches in points (72 points = 1 inch)

        // Create a new PDF document
        PdfDocument document = new PdfDocument();

        // Add a new page with the custom size
        PdfPage page = document.AddPage();
        page.Width = customPageWidth;
        page.Height = customPageHeight;

        
        // Use the XGraphics object to draw on the page
        XGraphics gfx = XGraphics.FromPdfPage(page);

        // Draw your content on the page
        // ...
        string name = Server.MapPath(@"Billing-sheet.png");
        // each source file separate
        PdfSharp.Pdf.PdfDocument doc = new PdfSharp.Pdf.PdfDocument();

        XImage img = XImage.FromFile(name);
        img.Interpolate = false;

        //int width = img.PixelWidth;
        //int height = img.PixelHeight;

        int width = 600;
        int height = 700;

        PdfSharp.Pdf.PdfPage pageimg = new PdfSharp.Pdf.PdfPage
        {
            Width = width,
            Height = height
        };

        doc.Pages.Add(pageimg);
        XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);

        xgr.DrawImage(img, 0, 0, width, height);
        img.Dispose();
        xgr.Dispose();


        // Save the PDF document to a stream or file
        // ...
        FileInfo fi = new FileInfo(name);
        MemoryStream stream = new MemoryStream();
        doc.Save(stream, false);
        doc.Dispose();
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-length", stream.Length.ToString());
        Response.BinaryWrite(stream.ToArray());
        Response.Flush();
        stream.Close();
        Response.End();


    }
}