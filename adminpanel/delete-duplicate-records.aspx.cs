using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class adminpanel_delete_duplicate_records : System.Web.UI.Page
{
    iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        DeleteRecord();
    }

    public void DeleteRecord()
    {
        try
        {
            using (DataTable dtMarks = c.GetDataTable("Select * From MarksheetData WHERE MarkStudentID=39522 Order By MarkID "))
            {
                foreach (DataRow prow in dtMarks.Rows)
                {
                  //if(prow["MarkStudentID"]== "39522") { }

                 c.ExecuteQuery("Delete From MarksheetData Where MarkStudentID='" + prow["MarkStudentID"] + "' AND MarkSubjectName='" + prow["MarkSubjectName"] + "' AND MarkObtain="+ prow["MarkObtain"] + "  AND   MarkID!=" + prow ["MarkID"]);
                   
                }

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "DeleteRecord", ex.Message.ToString());
            return;
        }
    }

}