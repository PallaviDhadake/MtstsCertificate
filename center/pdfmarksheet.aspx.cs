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
using System.Data;



public partial class center_pdfmarksheet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        PdfDocument document = new PdfDocument();
        document.Info.Title = "Table Example";

        for (int p = 0; p < 1; p++)
        {
            // Page Options
            PdfPage pdfPage = document.AddPage();
            //pdfPage.Height = 842;//842
            //pdfPage.Width = 590;

            pdfPage.Height = 1000;//842
            pdfPage.Width = 1400;

            // Get an XGraphics object for drawing
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);

            // Text format
            XStringFormat format = new XStringFormat();
            format.LineAlignment = XLineAlignment.Near;
            format.Alignment = XStringAlignment.Near;
            var tf = new XTextFormatter(graph);

            XFont fontParagraph = new XFont("Verdana", 14, XFontStyle.Regular);

            // Row elements
            int el1_width = 110;
            int el2_width = 250;

            // page structure options
            double lineHeight = 23;
            int marginLeft = 20;
            int marginTop = 20;
            int marginTopHeader = 20;

            int el_height = 400;
            int rect_height = 19;

            int interLine_X_1 = 2;
            int interLine_X_2 = 2 * interLine_X_1;

            int offSetX_1 = el1_width;
            //int offSetX_2 = el1_width + el2_width;
            int offSetX_2 = el2_width;

            XSolidBrush rect_style1 = new XSolidBrush(XColors.LightGray);
            XSolidBrush rect_style2 = new XSolidBrush(XColors.Black);
            XSolidBrush rect_style3 = new XSolidBrush(XColors.Red);
            XSolidBrush rect_style4 = new XSolidBrush(XColors.Green);
            XSolidBrush rect_style5 = new XSolidBrush(XColors.Pink);

            for (int i = 0; i < 10; i++)
            {
                double dist_Y = lineHeight * (i + 1);
                double dist_Y2 = dist_Y - 2;

                // If i=0, then its Header Creation only
                if (i == 0)
                {
                    graph.DrawRectangle(rect_style2, marginLeft, marginTopHeader, pdfPage.Width - 2 * marginLeft, rect_height);
                    

                    //tf.DrawString("SR_NO", fontParagraph, XBrushes.White,
                    //              new XRect(marginLeft, marginTop, el1_width, el_height), format);

                    tf.DrawString("Subject Name", fontParagraph, XBrushes.White,
                                  new XRect(marginLeft, marginTop, el2_width, el_height), format);
                                       

                    tf.DrawString("Max Marks", fontParagraph, XBrushes.White,
                                  new XRect(marginLeft + offSetX_2 + 1 * interLine_X_2, marginTop, el1_width, el_height), format);

                    tf.DrawString("Obt Marks", fontParagraph, XBrushes.White,
                                new XRect(marginLeft + offSetX_2 + offSetX_1 + 2 * interLine_X_2, marginTop, el1_width, el_height), format);

                    tf.DrawString("Avg Marks", fontParagraph, XBrushes.White,
                               new XRect(marginLeft + offSetX_2 + offSetX_1 + offSetX_1 + 3 * interLine_X_2, marginTop, el1_width, el_height), format);

                    tf.DrawString("Total Marks", fontParagraph, XBrushes.White,
                               new XRect(marginLeft + offSetX_2 + offSetX_1 + offSetX_1 + offSetX_1 + 4 * interLine_X_2, marginTop, el1_width, el_height), format);

                    tf.DrawString("Grade", fontParagraph, XBrushes.White,
                               new XRect(marginLeft + offSetX_2 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + 5 * interLine_X_2, marginTop, el1_width, el_height), format);

                    tf.DrawString("Result", fontParagraph, XBrushes.White,
                              new XRect(marginLeft + offSetX_2 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + 6 * interLine_X_2, marginTop, el1_width, el_height), format);


                    tf.DrawString("Final Result", fontParagraph, XBrushes.White,
                              new XRect(marginLeft + offSetX_2 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + 7 * interLine_X_2, marginTop, el1_width, el_height), format);




                }

                // Item Rows Creations here
                else
                {
                    ////ELEMENT 1 - SMALL 80
                    //graph.DrawRectangle(rect_style1, marginLeft, marginTop + dist_Y2, el1_width, rect_height);
                    //tf.DrawString(

                    //    "Visual Studio 2015",
                    //    fontParagraph,
                    //    XBrushes.Black,
                    //    new XRect(marginLeft, marginTop + dist_Y, el1_width, el_height),
                    //    format);

                    //ELEMENT Subject - BIG 380
                    graph.DrawRectangle(rect_style1, marginLeft, marginTop + dist_Y2, el2_width, rect_height);
                    tf.DrawString(
                        "Visual Studio 2015 MTSTS India",
                        fontParagraph,
                        XBrushes.Black,
                        new XRect(marginLeft, marginTop + dist_Y, el2_width, el_height),
                        format);


                    //ELEMENT Max-Marks - SMALL 80

                    graph.DrawRectangle(rect_style1, marginLeft + offSetX_2 + interLine_X_2, dist_Y2 + marginTop, el1_width, rect_height);
                    tf.DrawString(
                        "100",
                        fontParagraph,
                        XBrushes.Black,
                        new XRect(marginLeft + offSetX_2 + interLine_X_2, dist_Y + marginTop, el1_width, el_height),
                        format);

                    //ELEMENT Obt-Marks - SMALL 80

                    graph.DrawRectangle(rect_style1, marginLeft + offSetX_2 + offSetX_1 + 2 * interLine_X_2, dist_Y2 + marginTop, el1_width, rect_height);
                    tf.DrawString(
                        "88",
                        fontParagraph,
                        XBrushes.Black,
                        new XRect(marginLeft + offSetX_2 + offSetX_1 + 2 * interLine_X_2, dist_Y + marginTop, el1_width, el_height),
                        format);

                    //ELEMENT Avg-Marks - SMALL 80

                    graph.DrawRectangle(rect_style1, marginLeft + offSetX_2 + offSetX_1 + offSetX_1 + 3 * interLine_X_2, dist_Y2 + marginTop, el1_width, rect_height);
                    tf.DrawString(
                        "Avg80",
                        fontParagraph,
                        XBrushes.Black,
                        new XRect(marginLeft + offSetX_2 + offSetX_1 + offSetX_1 + 3 * interLine_X_2, dist_Y + marginTop, el1_width, el_height),
                        format);

                    //ELEMENT Total-Marks - SMALL 80

                    graph.DrawRectangle(rect_style1, marginLeft + offSetX_2 + offSetX_1 + offSetX_1 + offSetX_1 + 4 * interLine_X_2, dist_Y2 + marginTop, el1_width, rect_height);
                    tf.DrawString(
                        "T80",
                        fontParagraph,
                        XBrushes.Black,
                        new XRect(marginLeft + offSetX_2 + offSetX_1 + offSetX_1 + offSetX_1 + 4 * interLine_X_2, dist_Y + marginTop, el1_width, el_height),
                        format);

                    //ELEMENT Grade - SMALL 80

                    graph.DrawRectangle(rect_style1, marginLeft + offSetX_2 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + 5 * interLine_X_2, dist_Y2 + marginTop, el1_width, rect_height);
                    tf.DrawString(
                        "A++",
                        fontParagraph,
                        XBrushes.Black,
                        new XRect(marginLeft + offSetX_2 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + 5 * interLine_X_2, dist_Y + marginTop, el1_width, el_height),
                        format);

                    //ELEMENT Result - SMALL 80

                    graph.DrawRectangle(rect_style1, marginLeft + offSetX_2 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + 6 * interLine_X_2, dist_Y2 + marginTop, el1_width, rect_height);
                    tf.DrawString(
                        "R80",
                        fontParagraph,
                        XBrushes.Black,
                        new XRect(marginLeft + offSetX_2 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + 6 * interLine_X_2, dist_Y + marginTop, el1_width, el_height),
                        format);


                    //ELEMENT Final-Result - SMALL 80

                    graph.DrawRectangle(rect_style1, marginLeft + offSetX_2 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + 7 * interLine_X_2, dist_Y2 + marginTop, el1_width, rect_height);
                    tf.DrawString(
                        "F80",
                        fontParagraph,
                        XBrushes.Black,
                        new XRect(marginLeft + offSetX_2 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + offSetX_1 + 7 * interLine_X_2, dist_Y + marginTop, el1_width, el_height),
                        format);


                }
                

            }


        }


        //save to destination file
        //FileInfo fi = new FileInfo(name);
        MemoryStream stream = new MemoryStream();
        
        document.Save(stream, false);
        document.Dispose();
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-length", stream.Length.ToString());
        Response.BinaryWrite(stream.ToArray());
        Response.Flush();
        stream.Close();
        Response.End();

        
        

    }
}