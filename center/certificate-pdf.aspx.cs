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

public partial class center_certificate_pdf : System.Web.UI.Page
{
    iClass c = new iClass();
    public string studentName, centerName, courseName, marks, grade, fromdate, todate, Month, signimg, errMsg, studentImg, studentsign,CenterSign, rootPath, StudCertificateNo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PdfPage();
        }
        rootPath = c.ReturnHttp();
    }

    public void PdfPage()
    {
        if (Request.QueryString["CertID"] != null)
        {
            using (DataTable dtCertificate = c.GetDataTable("Select CertID, CertCourseName, CertDuration, CertAvgMarks, CertGrade, CertExamMonth, CertStudentName, CertCenterName, CertFromDate, CertToDate, CertStudSign, CertStudPhoto, CertNumber From CertificateData Where CertID=" + Request.QueryString["CertID"]))
            {
                if (dtCertificate.Rows.Count > 0)
                {
                    DataRow row = dtCertificate.Rows[0];

                    studentName = row["CertStudentName"].ToString();
                    centerName = row["CertCenterName"].ToString();
                    courseName = row["CertCourseName"].ToString();
                    marks = row["CertAvgMarks"].ToString();
                    grade = row["CertGrade"].ToString();
                    fromdate = Convert.ToDateTime(row["CertFromDate"]).ToString("dd-MMM-yyyy");
                    Month = Convert.ToDateTime(row["CertExamMonth"]).ToString("MMM-yyyy");
                    todate = Convert.ToDateTime(row["CertToDate"]).ToString("dd-MMM-yyyy");
                    StudCertificateNo = row["CertNumber"].ToString();

                    if (row["CertStudSign"] != DBNull.Value && row["CertStudSign"] != null && row["CertStudSign"].ToString() != "" && row["CertStudSign"].ToString() != "no-photo.png")
                    {
                        studentsign = "upload/student/sign/" + row["CertStudSign"].ToString();
                    }

                    if (row["CertStudPhoto"] != DBNull.Value && row["CertStudPhoto"] != null && row["CertStudPhoto"].ToString() != "" && row["CertStudPhoto"].ToString() != "no-photo.png")
                    {
                        studentImg = "upload/student/photo/" + row["CertStudPhoto"].ToString();
                    }

                }
            }

            object centerid = c.GetReqData("CertificateData", "FK_CenterID", "CertID=" + Request.QueryString["CertID"]);

            using (DataTable dtsignimg = c.GetDataTable("Select CenterID, CenterSign From CentersData Where CenterID=" + centerid))
            {
                if (dtsignimg.Rows.Count > 0)
                {
                    DataRow row = dtsignimg.Rows[0];
                    // signimg = row["CenterSign"].ToString();
                    if (row["CenterSign"] != DBNull.Value && row["CenterSign"] != null && row["CenterSign"].ToString() != "" && row["CenterSign"].ToString() != "no-photo.png")
                    {
                        //signPhoto = "<img src=\"" + Master.rootPath + "upload/center/thumb/" + row["CenterSign"].ToString() + "\" width=\"200\" />";

                        //signimg = "<img src=\"" + rootPath + "upload/center/thumb/" + row["CenterSign"].ToString() + "\" width=\"100\" />";

                        signimg = "upload/center/" + row["CenterSign"].ToString();
                    }

                }
            }

        }

        //===================== BAckground Image setting starts here =====================

        string name = Server.MapPath(@"Certificate-MTSTS.jpg");
        // each source file separate
        PdfSharp.Pdf.PdfDocument doc = new PdfSharp.Pdf.PdfDocument();

        XImage img = XImage.FromFile(name);
        img.Interpolate = false;

        //int width = img.PixelWidth;
        //int height = img.PixelHeight;

        //int width = 800;
        //int height = 1134;

        int width = 1000;
        int height = 1417;

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
        // XFont font = new XFont("Verdana", 20, XFontStyle.Regular);
        XFont font = new XFont("Verdana", 25, XFontStyle.Regular);
        //XFont fontMedium = new XFont("Verdana", 16, XFontStyle.Regular);
        XFont fontMedium = new XFont("Verdana", 18, XFontStyle.Regular);
        XFont fontBig = new XFont("Verdana", 27, XFontStyle.Bold);
        //XFont fontBoldSmall = new XFont("Verdana", 16, XFontStyle.Bold);
        XFont fontBoldSmall = new XFont("Verdana", 20, XFontStyle.Bold);
        XTextFormatter tf = new XTextFormatter(gfx);


        //===================== Center Sign Image setting starts here =====================

        //string SignName = Server.MapPath(@"sign-demo.jpg");
        if (signimg != null && signimg != "")
        {
            string SignName = Server.MapPath(@"~/" + signimg);
            XImage imageSign = XImage.FromFile(SignName);
            gfx.DrawImage(imageSign, 320, 1110, 110, 35);
            //gfx.DrawImage(imageSign, 320, 1110, 185, 65);

        }
        //===================== Sign Image setting ends here =====================


        //===================== studentSign Image setting starts here =====================

        if (studentsign != null && studentsign != "")
        {
            string StudentSign = Server.MapPath(@"~/" + studentsign);
            XImage imgStudentSign = XImage.FromFile(StudentSign);
            gfx.DrawImage(imgStudentSign, 147, 1195, 140, 55);
            //gfx.DrawImage(imageSign, 320, 1110, 185, 65);
        }

        //===================== Sign Image setting ends here =====================


        //===================== studentSign Image setting starts here =====================
        if (studentImg != null && studentImg != "")
        {
            string Studentphtot = Server.MapPath(@"~/" + studentImg);
            XImage imgStudent = XImage.FromFile(Studentphtot);
            gfx.DrawImage(imgStudent, 147, 1061, 140, 132);
            //gfx.DrawImage(imageSign, 320, 1110, 185, 65);
        }

        //===================== Sign Image setting ends here =====================



        // ============ Draw the text =============

        //Student Certificate number
        //gfx.DrawString(StudCertificateNo, fontMedium, XBrushes.Black,
        //new XRect(280, -450, page.Width, 970),
        //XStringFormats.Center);

        var layoutRectangle0 = new XRect(240, 20, page.Width, page.Height);
        tf.Alignment = XParagraphAlignment.Center;
        //tf.DrawString("MTSTS CERTIFIED - CERTIFICATE COURSE IN AUTOCAD (1 MONTH)\r\nExtra text lenght added to check", font, XBrushes.Black, layoutRectangle);
        tf.DrawString("Certificate Number : " + StudCertificateNo, fontMedium, XBrushes.Black, layoutRectangle0);

        // Student Name
        //gfx.DrawString("S.SIVASANKARAN", fontBig, XBrushes.Black,
        gfx.DrawString(studentName, fontBig, XBrushes.Black,
       new XRect(0, 0, page.Width, 970),
       XStringFormats.Center);

        // Course Name
        var layoutRectangle = new XRect(0, 560, page.Width, page.Height);
        tf.Alignment = XParagraphAlignment.Center;
        //tf.DrawString("MTSTS CERTIFIED - CERTIFICATE COURSE IN AUTOCAD (1 MONTH)\r\nExtra text lenght added to check", font, XBrushes.Black, layoutRectangle);
        tf.DrawString(courseName, font, XBrushes.Black, layoutRectangle);

        // Precent Text
       // var layoutRectangle1 = new XRect(185, 505, page.Width, page.Height);
        var layoutRectangle1 = new XRect(240, 630, page.Width, page.Height);
        tf.Alignment = XParagraphAlignment.Left;
        //tf.DrawString("95.00", font, XBrushes.Black, layoutRectangle1);
        tf.DrawString(marks, font, XBrushes.Black, layoutRectangle1);

        // Grade Text
        //var layoutRectangle2 = new XRect(700, 505, page.Width, page.Height);
        var layoutRectangle2 = new XRect(870, 630, page.Width, page.Height);
        tf.Alignment = XParagraphAlignment.Left;
        tf.DrawString(grade, font, XBrushes.Black, layoutRectangle2);

        // Duration Text
        var layoutRectangle3 = new XRect(350, 845, page.Width, page.Height);
        tf.Alignment = XParagraphAlignment.Left;
        //tf.DrawString("May-2021 (24-Apr-2021 TO 26-May-2021)", font, XBrushes.Black, layoutRectangle3);
        tf.DrawString(Month + " (" + fromdate + " To " + todate + ")", fontMedium, XBrushes.Black, layoutRectangle3);

        // Center Name Text
        var layoutRectangle4 = new XRect(0, 890, page.Width, page.Height);
        tf.Alignment = XParagraphAlignment.Center;
        //tf.DrawString("AT - ACADD CENTRE", fontBig, XBrushes.Black, layoutRectangle4);
        tf.DrawString(centerName, fontBoldSmall, XBrushes.Black, layoutRectangle4);


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
               // }
           // }
        //}
    }


}