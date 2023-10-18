using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class center_Default : System.Web.UI.Page
{
    iClass c = new iClass();
    public string[] ordCertiData = new string[30];
    protected void Page_Load(object sender, EventArgs e)
    {
        GetCertiData(Convert.ToInt32(Request.QueryString["id"]));
    }
    public void GetCertiData(int Idx)
    {
        try
        {
            using (DataTable dtcerti = c.GetDataTable("select * from CertificateData where CertID=" + Idx))
            {
                if (dtcerti.Rows.Count > 0)
                {
                    DataRow row = dtcerti.Rows[0];

                    ordCertiData[0] = row["CertUploadDate"] != DBNull.Value && row["CertUploadDate"] != null && row["CertUploadDate"].ToString() != "" ? row["CertUploadDate"].ToString() : "NA";

                    ordCertiData[1] = row["CertNumber"] != DBNull.Value && row["CertNumber"] != null && row["CertNumber"].ToString() != "" ? row["CertNumber"].ToString() : "NA";

                    ordCertiData[2] = row["CertCourseName"] != DBNull.Value && row["CertCourseName"] != null && row["CertCourseName"].ToString() != "" ? row["CertCourseName"].ToString() : "NA";
                    ordCertiData[3] = row["CertDuration"] != DBNull.Value && row["CertDuration"] != null && row["CertDuration"].ToString() != "" ? row["CertDuration"].ToString() : "NA";

                    ordCertiData[4] = row["CertAvgMarks"] != DBNull.Value && row["CertAvgMarks"] != null && row["CertAvgMarks"].ToString() != "" ? row["CertAvgMarks"].ToString() : "NA";

                    ordCertiData[5] = row["CertGrade"] != DBNull.Value && row["CertGrade"] != null && row["CertGrade"].ToString() != "" ? row["CertGrade"].ToString() : "NA";

                    ordCertiData[6] = row["CertExamMonth"] != DBNull.Value && row["CertExamMonth"] != null && row["CertExamMonth"].ToString() != "" ? row["CertExamMonth"].ToString() : "NA";

                    ordCertiData[7] = row["CertIssueDate"] != DBNull.Value && row["CertIssueDate"] != null && row["CertIssueDate"].ToString() != "" ? row["CertIssueDate"].ToString() : "NA";

                    ordCertiData[8] = row["CertStudentName"] != DBNull.Value && row["CertStudentName"] != null && row["CertStudentName"].ToString() != "" ? row["CertStudentName"].ToString() : "NA";
                    ordCertiData[9] = row["CertCenterName"] != DBNull.Value && row["CertCenterName"] != null && row["CertCenterName"].ToString() != "" ? row["CertCenterName"].ToString() : "NA";
                    ordCertiData[10] = row["CertFromDate"] != DBNull.Value && row["CertFromDate"] != null && row["CertFromDate"].ToString() != "" ? row["CertFromDate"].ToString() : "NA";

                    ordCertiData[11] = row["CertToDate"] != DBNull.Value && row["CertToDate"] != null && row["CertToDate"].ToString() != "" ? row["CertToDate"].ToString() : "NA";

                    ordCertiData[12] = row["CertStudentRegDate"] != DBNull.Value && row["CertStudentRegDate"] != null && row["CertStudentRegDate"].ToString() != "" ? row["CertStudentRegDate"].ToString() : "NA";

                    ordCertiData[13] = row["CertPlace"] != DBNull.Value && row["CertPlace"] != null && row["CertPlace"].ToString() != "" ? row["CertPlace"].ToString() : "NA";

                    ordCertiData[14] = row["CertCenterNo"] != DBNull.Value && row["CertCenterNo"] != null && row["CertCenterNo"].ToString() != "" ? row["CertCenterNo"].ToString() : "NA";
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetCertiData", ex.Message.ToString());
            return;
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("certificate-list.aspx");
    }

    //protected void btnPreview_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("certificate-pdf.aspx?CertID=" + Request.QueryString["id"]);
    //}
}