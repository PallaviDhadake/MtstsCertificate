using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System.Data;

public partial class center_certificate : System.Web.UI.Page
{
    iClass c = new iClass();
    public string studentName, centerName, courseName, marks, grade, fromdate, todate ,Month, errMsg;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["CertID"] != null)
            {
                using (DataTable dtCertificate=c.GetDataTable("Select CertID, CertCourseName, CertDuration, CertAvgMarks, CertGrade, CertExamMonth, CertStudentName, CertCenterName, CertFromDate, CertToDate  From CertificateData Where CertID=" + Request.QueryString["CertID"]))
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
                    }
                }
            }
        }
    }

    protected void btnPdf_Click(object sender, EventArgs e)
    {
        try
        {
            //Set Environment variable for OpenSSL assemblies folder 
            string SSLPath = Server.MapPath("~/OpenSSL");
            Environment.SetEnvironmentVariable("Path", SSLPath);

            //Initialize HTML to PDF converter 
            HtmlToPdfConverter htmlConvertor = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);
            WebKitConverterSettings settings = new WebKitConverterSettings();
            //Set WebKit path
            settings.WebKitPath = Server.MapPath("~/QtBinaries");
            //Assign WebKit settings to HTML converter
            htmlConvertor.ConverterSettings = settings;
            //Get the current URL
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            //Convert URL to PDF
            PdfDocument document = htmlConvertor.Convert(url);
            //Save the document
            document.Save("MtstsCertificate.pdf", HttpContext.Current.Response, HttpReadType.Save);
        }
        catch(Exception ex)
        {
            errMsg = c.ErrNotification(3, ex.Message.ToString());
            return;
        }
    }
}