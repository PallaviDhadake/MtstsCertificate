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

public partial class pdf_certificate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Server.MapPath(@"Certificate-MTSTS1.jpg");
        // each source file separate
        PdfSharp.Pdf.PdfDocument doc = new PdfSharp.Pdf.PdfDocument();

        XImage img = XImage.FromFile(name);
        img.Interpolate = false;

        //int width = img.PixelWidth;
        //int height = img.PixelHeight;

        int width = 800;
        int height = 1134;

        PdfSharp.Pdf.PdfPage page = new PdfSharp.Pdf.PdfPage
        {
            Width = width,
            Height = height
        };
        doc.Pages.Add(page);
        XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);

        xgr.DrawImage(img, 0, 0, width, height);
        img.Dispose();
        xgr.Dispose();
        //===================== BAckground Image setting ends here =====================

        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont font = new XFont("Verdana", 20, XFontStyle.Regular);
        XFont fontBig = new XFont("Verdana", 21, XFontStyle.Bold);
        XTextFormatter tf = new XTextFormatter(gfx);

        // ============ Draw the text =============

        // Student Name
        gfx.DrawString("S.SIVASANKARAN", fontBig, XBrushes.Black,
         new XRect(0, 0, page.Width, 770),
         XStringFormats.Center);

        // Course Name
        var layoutRectangle = new XRect(0, 445, page.Width, page.Height);
        tf.Alignment = XParagraphAlignment.Center;
        tf.DrawString("MTSTS CERTIFIED - CERTIFICATE COURSE IN AUTOCAD (1 MONTH)\r\nExtra text lenght added to check", font, XBrushes.Black, layoutRectangle);

        // Precent Text
        var layoutRectangle1 = new XRect(180, 505, page.Width, page.Height);
        tf.Alignment = XParagraphAlignment.Left;
        tf.DrawString("95.00", font, XBrushes.Black, layoutRectangle1);

        // Grade Text
        var layoutRectangle2 = new XRect(700, 505, page.Width, page.Height);
        tf.Alignment = XParagraphAlignment.Left;
        tf.DrawString("A++", font, XBrushes.Black, layoutRectangle2);

        // Duration Text
        var layoutRectangle3 = new XRect(280, 672, page.Width, page.Height);
        tf.Alignment = XParagraphAlignment.Left;
        tf.DrawString("May-2021 (24-Apr-2021 TO 26-May-2021)", font, XBrushes.Black, layoutRectangle3);

        // Center Name Text
        var layoutRectangle4 = new XRect(0, 710, page.Width, page.Height);
        tf.Alignment = XParagraphAlignment.Center;
        tf.DrawString("AT - ACADD CENTRE", fontBig, XBrushes.Black, layoutRectangle4);


        //  save to destination file
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