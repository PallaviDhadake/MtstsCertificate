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

public partial class center_mtstsMarksheet : System.Web.UI.Page
{
    iClass c = new iClass();
    public string subName, maxMarks, obtMarks, Grade, avgMarks, totMarks, result, finalResult, StudentID, CertNumber, rootPath, markstudregDate, markcourseName, markPlace, markDuration, markCenterName, markCenterNo, markExamMonth, markstudName, markStudCertificateNo, markIssueDate, signimg, serialNo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PdfMarksheet();
        }
        rootPath = c.ReturnHttp();

    }

    public void PdfMarksheet()
    {
        if (Request.QueryString["MarkStudentID"] != null)
        {
            using (DataTable dtMarksheet = c.GetDataTable("Select MarkID, MarkSubjectName, MarkMax, MarkObtain, MarkResult, MarkTotal, MarkAverage, MarkGrade, MarkFinalResult, MarkStudentName, MarkCourseName, MarkCenterName , MarkPlace, MarkStudentID, MarkCertNumber, MarkDuration, MarkExamMonth, MarkTotal, MarkIssueDate, MarkStudRegDate, MarkCenterNo From MarksheetData Where MarkStudentID=" + Request.QueryString["MarkStudentID"]))
            {
                if (dtMarksheet.Rows.Count > 0)
                {
                    DataRow row = dtMarksheet.Rows[0];
                    StudentID = row["MarkStudentID"].ToString();
                    subName = row["MarkSubjectName"].ToString();
                    maxMarks = row["MarkMax"].ToString();
                    obtMarks = row["MarkObtain"].ToString();
                    Grade = row["MarkGrade"].ToString();
                    avgMarks = row["MarkAverage"].ToString();
                    totMarks = row["MarkTotal"].ToString();
                    result = row["MarkResult"].ToString();
                    finalResult = row["MarkFinalResult"].ToString();
                    CertNumber = row["MarkCertNumber"].ToString();
                    markPlace = row["MarkPlace"].ToString();
                    markcourseName = row["MarkCourseName"].ToString();
                    markDuration = row["MarkCourseName"].ToString();
                    markCenterName = row["MarkCenterName"].ToString();
                    markCenterNo = row["MarkCenterNo"].ToString();
                    markExamMonth = Convert.ToDateTime(row["MarkExamMonth"]).ToString("MMM-yyyy");
                    markDuration = row["MarkDuration"].ToString();
                    markstudName = row["MarkStudentName"].ToString();
                    markstudregDate = row["MarkStudentName"].ToString();
                    markStudCertificateNo = row["MarkCertNumber"].ToString();
                    markIssueDate = Convert.ToDateTime(row["MarkIssueDate"]).ToString("dd/MM/yyyy");
                }

            }

            object centerid = c.GetReqData("MarksheetData", "FK_CenterID", "MarkStudentID=" + Request.QueryString["MarkStudentID"]);

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

        string name = Server.MapPath(@"MTSTS-Marklist.jpg");
        // each source file separate
        PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();

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
        document.Pages.Add(page);
        XGraphics xgr = XGraphics.FromPdfPage(document.Pages[0]);

        xgr.DrawImage(img, 0, 0, width, height);
        img.Dispose();
        xgr.Dispose();

        //===================== BAckground Image setting ends here =====================




        //===================== Center Sign Image setting starts here =====================
        XGraphics graph = XGraphics.FromPdfPage(page);
        //string SignName = Server.MapPath(@"sign-demo.jpg");
        if (signimg != null && signimg != "")
        {
            string SignName = Server.MapPath(@"~/" + signimg);
            XImage imageSign = XImage.FromFile(SignName);
            graph.DrawImage(imageSign, 160, 1160, 130, 37);
        }
        //gfx.DrawImage(imageSign, 320, 1110, 185, 65);


        //===================== Sign Image setting ends here =====================



        //PdfDocument document = new PdfDocument();
        document.Info.Title = "Table Example";

        for (int p = 0; p < 1; p++)
        {
            // Page Options
            // PdfPage pdfPage = document.AddPage();
            //pdfPage.Height = 842;//842
            //pdfPage.Width = 590;

            //pdfPage.Height = 1000;//842
            //pdfPage.Width = 1400;

            // Get an XGraphics object for drawing
           // XGraphics graph = XGraphics.FromPdfPage(page);

            // Text format
            XStringFormat format = new XStringFormat();
            //XStringFormat form
            format.LineAlignment = XLineAlignment.Near;
            format.Alignment = XStringAlignment.Near;
            var tf = new XTextFormatter(graph);

            XFont fontParagraph = new XFont("Verdana", 14, XFontStyle.Bold);
            XFont fontsmall = new XFont("Verdana", 12, XFontStyle.Bold);
            XFont fontexsmall = new XFont("Verdana", 10, XFontStyle.Bold);
            XFont fonteRegular = new XFont("Verdana", 14, XFontStyle.Regular);
            XFont fonteRegularBold = new XFont("Verdana", 12.50, XFontStyle.Bold);




            // Row elements
            int el1_width = 110;
            int el2_width = 380;
            int el3_width = 490;
            //int el3_width = 110;
            int el4_width = 600;
            int el5_width = 710;
            int el6_width = 824;//lnterline_4
            int el7_width = 930;
            int el8_width = 1040;
            int els2_width = 347;



            // page structure options
            double lineHeight = 23;
            int marginLeft = 150;
            int marginTop = 610;
            int marginTopHeader = 10;

            int el_height = 400;
            int rect_height = 40;

            int interLine_X_1 = 2;
            int interLine_X_2 = 2 * interLine_X_1;

            int offSetX_1 = el1_width;
            //int offSetX_2 = el1_width + el2_width;
            int offSetX_2 = el2_width;
            int offSetX_3 = el3_width;
            int offSetX_4 = el4_width;
            int offSetX_5 = el5_width;
            int offSetX_6 = el6_width;
            int offSetX_7 = el7_width;
            int offSetX_8 = el8_width;
            int offSetXs_2 = els2_width;

            //BASIC INFORMATION WIDTH
            int elb1_width = 200;//300
            //for place
            int elb2_width = 90;
            int elb3_width = 40;

            XSolidBrush rect_style1 = new XSolidBrush(XColors.Black);
            XSolidBrush rect_style2 = new XSolidBrush(XColors.Black);
            XSolidBrush rect_style3 = new XSolidBrush(XColors.Red);
            XSolidBrush rect_style4 = new XSolidBrush(XColors.Green);
            XSolidBrush rect_style5 = new XSolidBrush(XColors.Pink);


            //Rectangle
            XRect rect = new XRect(140, 640, 717, 400);//1350
            XRect recthead = new XRect(140, 600, 717, 40);//1350
            XRect rectname = new XRect(140, 370, 717, 40);//1350
            XRect rectcoursename = new XRect(140, 420, 717, 40);
            XRect rectcentername = new XRect(140, 470, 717, 40);
            XRect rectplace = new XRect(140, 520, 717, 30);
            XRect rectinforplace = new XRect(140, 550, 717, 30);
            XRect rectgarde = new XRect(140, 1040, 717, 30);
            XRect rectpercent = new XRect(640, 1070, 217, 30);

            //XPen pen = new XPen(XColors.Navy, 4);
            //graph.DrawLine(pen, 0, 20, 250, 20);

            //pen = new XPen(XColors.Goldenrod, 10);
            //pen.LineCap = XLineCap.Flat;

            //object Subjects = c.GetReqData("MarksheetData", "MarkSubjectName", "MarkStudentID='" + StudentID + "' AND MarkCertNumber='" + CertNumber + "' ");
            //if (Subjects != DBNull.Value && Subjects != null && Subjects.ToString() != "") 
            int SubCount = Convert.ToInt32(c.GetReqData("MarksheetData", "COUNT(MarkId)", "MarkStudentID='" + StudentID + "' AND MarkCertNumber='" + CertNumber + "' "));

            //MarkCertificateNo
            var layoutRectangle2 = new XRect(660, 310, page.Width, page.Height);
            tf.Alignment = XParagraphAlignment.Left;
            //tf.DrawString("95.00", font, XBrushes.Black, layoutRectangle1);
            tf.DrawString("No:-", fontParagraph, XBrushes.Black, layoutRectangle2);

            var layoutRectangle1 = new XRect(699, 310, page.Width, page.Height);
            tf.Alignment = XParagraphAlignment.Left;
            //tf.DrawString("95.00", font, XBrushes.Black, layoutRectangle1);
            if (markStudCertificateNo != null && markStudCertificateNo.ToString() != "")
            {
                tf.DrawString(markStudCertificateNo, fontParagraph, XBrushes.Black, layoutRectangle1);
            }

            //MarkIssueDate
            var layoutRectangle3 = new XRect(140, 1080, page.Width, page.Height);
            tf.Alignment = XParagraphAlignment.Left;
            //tf.DrawString("95.00", font, XBrushes.Black, layoutRectangle1);
            tf.DrawString("DATE:", fontParagraph, XBrushes.Black, layoutRectangle3);

            var layoutRectangle4 = new XRect(190, 1080, page.Width, page.Height);
            tf.Alignment = XParagraphAlignment.Left;
            //tf.DrawString("95.00", font, XBrushes.Black, layoutRectangle1);
            if (markIssueDate != null && markIssueDate.ToString() != "")
            {
                tf.DrawString(markIssueDate, fonteRegular, XBrushes.Black, layoutRectangle4);
            }
                    

            for (int i = 0; i <= SubCount; i++)
            {
                double dist_Y = lineHeight * (i + 1);
                double dist_Y2 = dist_Y - 2;

                //graph.DrawRectangle(rect_style2, marginLeft, marginTopHeader, pdfPage.Width - 2 * marginLeft, rect_height);
                // If i=0, then its Header Creation only


                if (i == 0)
                {
                    //candidate name
                    graph.DrawRectangle(XPens.Black, rectname);
                    tf.DrawString("CANDIDATE NAME", fontParagraph, XBrushes.Black,
                                   new XRect(150, 380, elb1_width, el_height), format);
                    graph.DrawLine(XPens.Black, rect.Width / 2.3, 410, rect.Width / 2.3, 370);

                    if (markstudName != null && markstudName.ToString() != "")
                    {
                        tf.DrawString(markstudName, fontParagraph, XBrushes.Black,
                                      new XRect(320, 380, el2_width, el_height), format);
                    }


                    //graph.DrawLine(XPens.Black, rect.Width / 2, 10, rect.Width / 2, 10);

                    //course name
                    graph.DrawRectangle(XPens.Black, rectcoursename);
                    tf.DrawString("COURSE NAME", fontParagraph, XBrushes.Black,
                                   new XRect(150, 430, elb1_width, el_height), format);
                                   //new XRect(150, 430, elb1_width, el_height), format);
                    graph.DrawLine(XPens.Black, rect.Width / 2.3, 460, rect.Width / 2.3, 420);

                    //Split string and insert into rect
                    if (markcourseName != null && markcourseName.ToString() != "")
                    {
                        int courselen = markcourseName.Length;

                        if (markcourseName.Length<=70)
                        {

                            tf.DrawString(markcourseName, fonteRegularBold, XBrushes.Black,
                                      new XRect(320, 427, el4_width, el_height), format);
                        }
                        if (markcourseName.Length >= 70)
                        {
                            
                            string first = markcourseName.Substring(0, 62);
                            string last = markcourseName.Substring(62);

                            tf.DrawString(first, fonteRegularBold, XBrushes.Black,
                                     new XRect(320, 427, el4_width, el_height), format);
                            tf.DrawString(last, fonteRegularBold, XBrushes.Black,
                                        new XRect(320, 442, el4_width, el_height), format);

                        }

                    }


                    //if (markcourseName != null && markcourseName.ToString() != "")
                    //{
                    //    if (markcourseName.Length >= 80)
                    //    {

                    //        var MyString = markcourseName;
                    //        var first = MyString.Substring(0, (int)(MyString.Length / 2));

                    //        var last = MyString.Substring((int)(MyString.Length / 2), (int)(MyString.Length / 2));

                    //        tf.DrawString(first, fonteRegularBold, XBrushes.Black,
                    //                      new XRect(320, 427, el4_width, el_height), format);
                    //        tf.DrawString(last, fonteRegularBold, XBrushes.Black,
                    //                      new XRect(320, 442, el4_width, el_height), format);
                    //    }
                    //}


                    //center name
                    graph.DrawRectangle(XPens.Black, rectcentername);
                    tf.DrawString("NAME OF THE ATC", fontParagraph, XBrushes.Black,
                                   new XRect(150, 480, elb1_width, el_height), format);
                                   //new XRect(150, 480, elb1_width, el_height), format);
                    graph.DrawLine(XPens.Black, rect.Width / 2.3, 510, rect.Width / 2.3, 470);
                    if (markCenterName != null && markCenterName.ToString() != "")
                    {
                        tf.DrawString(markCenterName, fonteRegularBold, XBrushes.Black,
                                      new XRect(320, 475, el4_width, el_height), format);
                    }
                    //place 
                    graph.DrawRectangle(XPens.Black, rectplace);
                    //tf.Alignment = XParagraphAlignment.Center;
                    tf.DrawString("Place", fontParagraph, XBrushes.Black,
                                   new XRect(180, 525, elb2_width, el_height), format);
                    graph.DrawLine(XPens.Black, rect.Width / 2.7, 580, rect.Width / 2.7, 520);
                    //center no
                    tf.DrawString("CENTER NO", fontParagraph, XBrushes.Black,
                                  new XRect(320, 525, el1_width, el_height), format);
                    graph.DrawLine(XPens.Black, rect.Width / 1.55, 580, rect.Width / 1.55, 520);
                    //student id
                    tf.DrawString("STUDENT ID", fontParagraph, XBrushes.Black,
                                  new XRect(475, 525, elb1_width, el_height), format);
                    graph.DrawLine(XPens.Black, rect.Width / 1.20, 580, rect.Width / 1.20, 520);
                    //exam month
                    tf.DrawString("EXAM MONTH", fontParagraph, XBrushes.Black,
                                  new XRect(605, 525, elb1_width, el_height), format);
                    graph.DrawLine(XPens.Black, rect.Width / 1.00, 580, rect.Width / 1.00, 520);

                    //duration  
                    tf.DrawString("DURATION", fontParagraph, XBrushes.Black,
                                  new XRect(755, 525, elb1_width, el_height), format);
                    graph.DrawRectangle(XPens.Black, recthead);

                    //information of place and centerno etc.

                    graph.DrawRectangle(XPens.Black, rectinforplace);
                    if (markPlace != null && markPlace.ToString() != "")
                    {
                        tf.DrawString(markPlace, fontexsmall, XBrushes.Black,
                                       new XRect(150, 555, el1_width, el_height), format);
                    }
                    graph.DrawLine(XPens.Black, rect.Width / 2, 10, rect.Width / 2, 10);
                    //center no
                    if (markCenterNo != null && markCenterNo.ToString() != "")
                    {
                        tf.DrawString(markCenterNo, fontexsmall, XBrushes.Black,
                                      new XRect(285, 555, el1_width, el_height), format);
                    }
                    //student id
                    if (StudentID != null && StudentID.ToString() != "")
                    {
                        tf.DrawString(StudentID, fontexsmall, XBrushes.Black,
                                      new XRect(477, 555, elb1_width, el_height), format);
                    }
                    //exam month
                    if (markExamMonth != null && markExamMonth.ToString() != "")
                    {
                        tf.DrawString(markExamMonth, fontexsmall, XBrushes.Black,
                                      new XRect(619, 555, elb1_width, el_height), format);
                    }
                    graph.DrawRectangle(XPens.Black, recthead);

                    //duration  
                    if (markDuration != null && markDuration.ToString() != "")
                    {
                        tf.DrawString(markDuration, fontexsmall, XBrushes.Black,
                                      new XRect(757, 555, elb1_width, el_height), format);
                    }
                    graph.DrawRectangle(XPens.Black, recthead);

                    //garde rectangle
                    graph.DrawRectangle(XPens.Black, rectgarde);
                    tf.DrawString("GRADE :", fontParagraph, XBrushes.Black,
                                   new XRect(150, 1045, el4_width, el_height), format);
                    if (Grade != null && Grade.ToString() != "")
                    {
                        tf.DrawString(Grade, fontParagraph, XBrushes.Black,
                                      new XRect(230, 1045, el1_width, el_height), format);
                    }
                    //max marks
                    if (maxMarks != null && maxMarks.ToString() != "")
                    {
                        tf.DrawString(maxMarks, fontParagraph, XBrushes.Black,
                                    new XRect(545, 1045, el1_width, el_height), format);
                    }
                    //total marks
                    if (totMarks != null && totMarks.ToString() != "")
                    {
                        tf.DrawString(totMarks, fontParagraph, XBrushes.Black,
                                    new XRect(655, 1045, el1_width, el_height), format);
                    }
                    //final result
                    if (finalResult != null && finalResult.ToString() != "")
                    {
                        tf.DrawString(finalResult, fontParagraph, XBrushes.Black,
                                   new XRect(770, 1045, el1_width, el_height), format);
                    }

                    //percentage rectangle
                    graph.DrawRectangle(XPens.Black, rectpercent);
                    tf.DrawString("PERCENTAGE", fontParagraph, XBrushes.Black,
                                   new XRect(648, 1075, elb1_width, el_height), format);
                    if (avgMarks != null && avgMarks.ToString() != "")
                    {
                        tf.DrawString(avgMarks, fontParagraph, XBrushes.Black,
                                       new XRect(770, 1075, elb1_width, el_height), format);
                    }


                    //graph.DrawLine(XPens.Navy, rect.Width / 2, 20, rect.Width / 2, 210);

                    //graph.DrawLine(XPens.YellowGreen, 0, rect.Height / 2, rect.Width, rect.Height / 2);

                    tf.DrawString("SR NO", fontParagraph, XBrushes.Black,
                                     new XRect(marginLeft, 603, elb3_width, el_height), format);
                    graph.DrawLine(XPens.Black, rect.Width / 4, 600, rect.Width / 4, 1040);

                    tf.DrawString("SUBJECTS", fontParagraph, XBrushes.Black,
                                      new XRect(300, marginTop, el2_width, el_height), format);
                    graph.DrawLine(XPens.Black, rect.Width / 1.37, 600, rect.Width / 1.37, 1070);

                    //graph.DrawLine(XPens.Black, rect.Width / 2, 1, rect.Width / 2, 180);
                    //graph.DrawLine(pen, 25, 130, 240, 130);
                    tf.DrawString("MAXIMUM MARKS", fontParagraph, XBrushes.Black,
                                        new XRect(marginLeft + offSetX_2 + 1 * interLine_X_2, 605, el1_width, el_height), format);
                    graph.DrawLine(XPens.Black, rect.Width / 1.12, 600, rect.Width / 1.12, 1070);//2.7

                    tf.DrawString("MARKS OBTAINED", fontParagraph, XBrushes.Black,
                                  new XRect(275 + offSetX_2 + 1 * interLine_X_2, 605, el1_width, el_height), format);
                    graph.DrawLine(XPens.Black, rect.Width / 0.95, 600, rect.Width / 0.95, 1100);//2.2 //1.0

                    tf.DrawString("RESULT", fontParagraph, XBrushes.Black,
                               new XRect(280 + offSetX_3 + 2 * interLine_X_2, marginTop, el3_width, el_height), format);
                    //i==0 it shows only empty table 
                    graph.DrawRectangle(XPens.Black, rect);
                }

                // Item Rows Creations here
                else
                {
                    using (DataTable dtMarksheet = c.GetDataTable("Select MarkID, MarkSubjectName, MarkMax, MarkObtain, MarkResult, MarkTotal, MarkStudentID From MarksheetData Where MarkStudentID=" + Request.QueryString["MarkStudentID"]))
                    {
                        int marginTopMarks = 645;
                        int marginobtMarks = 645;
                        int marginMaxMarks = 645;
                        int marginFinalResult = 645;
                        int marginSrNo = 645;

                        if (dtMarksheet.Rows.Count > 0)
                        {
                            int srNo = 1;
                            foreach (DataRow row in dtMarksheet.Rows)
                            {
                                subName = row["MarkSubjectName"].ToString();
                                maxMarks = row["MarkMax"].ToString();
                                obtMarks = row["MarkObtain"].ToString();
                                //SrNo = SrNo + 1;
                               
                 
                                tf.DrawString(
                                srNo.ToString(),
                                fonteRegular,
                                XBrushes.Black,
                                new XRect(marginLeft, marginSrNo, elb3_width, el_height),
                                format);

                                if (subName != null && subName.ToString() != "")
                                {

                                    //Draw string for all elements
                                    tf.DrawString(
                                       subName,
                                       fonteRegular,
                                       XBrushes.Black,
                                       //new XRect(190, marginTopMarks + dist_Y, el2_width, el_height),
                                        new XRect(80 + offSetX_1 + 1 * interLine_X_1, marginTopMarks, els2_width, el_height),
                                       // 300, marginTop, el2_width, el_height
                                       format);
                                }

                                //Element obt Marks

                                tf.DrawString(
                                 obtMarks,
                                 fonteRegular,
                                 XBrushes.Black,
                                 new XRect(190 + offSetX_3 + 1 * interLine_X_2, marginobtMarks, el3_width, el_height),
                                 format);


                                tf.DrawString(
                                  maxMarks,
                                  fonteRegular,
                                  XBrushes.Black,
                                  new XRect(170 + offSetX_2 + 1 * interLine_X_2, marginMaxMarks, el1_width, el_height),
                                  format);


                                tf.DrawString(
                                finalResult,
                                fonteRegular,
                                XBrushes.Black,
                                new XRect(180 + offSetX_4 + 1 * interLine_X_2, marginFinalResult, el4_width, el_height),
                                format);

                                marginTopMarks = marginTopMarks + 40;
                                marginobtMarks = marginobtMarks + 40;
                                marginMaxMarks = marginMaxMarks + 40;
                                marginFinalResult = marginFinalResult + 40;
                                marginSrNo = marginSrNo + 40;
                                srNo=srNo + 1;         
                            }
                        }
                    }
                }
            }
        }

        //save to destination file
        FileInfo fi = new FileInfo(name);
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