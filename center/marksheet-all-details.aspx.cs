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
    public string[] ordMarkData = new string[30];
    protected void Page_Load(object sender, EventArgs e)
    {
        GetMarkData(Convert.ToInt32(Request.QueryString["id"]));
        GetMarksheetData(Convert.ToInt32(Request.QueryString["id"]));
    }

    public void GetMarkData(int Idx)
    {
        try
        {
            using (DataTable dtMarks = c.GetDataTable("select * from MarksheetData where MarkStudentID=" + Idx))
            {
                if (dtMarks.Rows.Count > 0)
                {
                    DataRow row = dtMarks.Rows[0];

                    ordMarkData[0] = row["MarkCertNumber"] != DBNull.Value && row["MarkCertNumber"] != null && row["MarkCertNumber"].ToString() != "" ? row["MarkCertNumber"].ToString() : "NA";

                    ordMarkData[1] = row["MarkStudentName"] != DBNull.Value && row["MarkStudentName"] != null && row["MarkStudentName"].ToString() != "" ? row["MarkStudentName"].ToString() : "NA";

                    ordMarkData[2] = row["MarkCourseName"] != DBNull.Value && row["MarkCourseName"] != null && row["MarkCourseName"].ToString() != "" ? row["MarkCourseName"].ToString() : "NA";

                    ordMarkData[3] = row["MarkCenterName"] != DBNull.Value && row["MarkCenterName"] != null && row["MarkCenterName"].ToString() != "" ? row["MarkCenterName"].ToString() : "NA";

                    ordMarkData[4] = row["MarkPlace"] != DBNull.Value && row["MarkPlace"] != null && row["MarkPlace"].ToString() != "" ? row["MarkPlace"].ToString() : "NA";

                    ordMarkData[5] = row["MarkCenterNo"] != DBNull.Value && row["MarkCenterNo"] != null && row["MarkCenterNo"].ToString() != "" ? row["MarkCenterNo"].ToString() : "NA";

                    ordMarkData[6] = row["MarkStudentID"] != DBNull.Value && row["MarkStudentID"] != null && row["MarkStudentID"].ToString() != "" ? row["MarkStudentID"].ToString() : "NA";

                    ordMarkData[7] = row["MarkExamMonth"] != DBNull.Value && row["MarkExamMonth"] != null && row["MarkExamMonth"].ToString() != "" ? row["MarkExamMonth"].ToString() : "NA";

                    ordMarkData[8] = row["MarkDuration"] != DBNull.Value && row["MarkDuration"] != null && row["MarkDuration"].ToString() != "" ? row["MarkDuration"].ToString() : "NA";

                    ordMarkData[9] = row["MarkSubjectName"] != DBNull.Value && row["MarkSubjectName"] != null && row["MarkSubjectName"].ToString() != "" ? row["MarkSubjectName"].ToString() : "NA";
                    ordMarkData[10] = row["MarkMax"] != DBNull.Value && row["MarkMax"] != null && row["MarkMax"].ToString() != "" ? row["MarkMax"].ToString() : "NA";

                    ordMarkData[11] = row["MarkObtain"] != DBNull.Value && row["MarkObtain"] != null && row["MarkObtain"].ToString() != "" ? row["MarkObtain"].ToString() : "NA";

                    ordMarkData[12] = row["MarkResult"] != DBNull.Value && row["MarkResult"] != null && row["MarkResult"].ToString() != "" ? row["MarkResult"].ToString() : "NA";

                    ordMarkData[13] = row["MarkTotal"] != DBNull.Value && row["MarkTotal"] != null && row["MarkTotal"].ToString() != "" ? row["MarkTotal"].ToString() : "NA";

                    ordMarkData[14] = row["MarkAverage"] != DBNull.Value && row["MarkAverage"] != null && row["MarkAverage"].ToString() != "" ? row["MarkAverage"].ToString() : "NA";

                    ordMarkData[15] = row["MarkGrade"] != DBNull.Value && row["MarkGrade"] != null && row["MarkGrade"].ToString() != "" ? row["MarkGrade"].ToString() : "NA";

                    ordMarkData[16] = row["MarkFinalResult"] != DBNull.Value && row["MarkFinalResult"] != null && row["MarkFinalResult"].ToString() != "" ? row["MarkFinalResult"].ToString() : "NA";

                    ordMarkData[17] = row["MarkIssueDate"] != DBNull.Value && row["MarkIssueDate"] != null && row["MarkIssueDate"].ToString() != "" ? row["MarkIssueDate"].ToString() : "NA";

                    ordMarkData[18] = row["MarkStudRegDate"] != DBNull.Value && row["MarkStudRegDate"] != null && row["MarkStudRegDate"].ToString() != "" ? row["MarkStudRegDate"].ToString() : "NA";
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetMarkData", ex.Message.ToString());
            return;
        }
    }

    public void GetMarksheetData(int StudIdx)
    {
        try
        {
            using (DataTable dtmarksheet = c.GetDataTable("Select * from MarksheetData Where MarkStudentID="+StudIdx))
            {
                
                gvMarksheet.DataSource = dtmarksheet;
                gvMarksheet.DataBind();

                if (dtmarksheet.Rows.Count > 0)
                {
                    gvMarksheet.UseAccessibleHeader = true;
                    gvMarksheet.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetBedData", ex.Message.ToString());
            return;
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("marksheet-list.aspx");
    }

    //protected void btnPreview_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("mtstsMarksheet.aspx?MarkStudentID=" + Request.QueryString["id"]);
    //}
}