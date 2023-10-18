using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class center_marksheet_list : System.Web.UI.Page
{
    iClass c = new iClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrid();
        }

    }

    private void FillGrid()
    {
        try
        {
            using (DataTable dtreq = c.GetDataTable("Select Distinct MarkStudentID, MarkStudentName, MarkCourseName, MarkPlace, MarkDuration From MarksheetData Where FK_CenterID='" + Session["centerMaster"] + "'"))

            {
                gvMarksheet.DataSource = dtreq;
                gvMarksheet.DataBind();

                if (dtreq.Rows.Count > 0)
                {
                    gvMarksheet.UseAccessibleHeader = true;
                    gvMarksheet.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "FillGrid", ex.Message.ToString());
            return;
        }
    }

    protected void gvMarksheet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal litAnch = (Literal)e.Row.FindControl("litAnch");
                litAnch.Text = "<a href=\"marksheet-all-details.aspx?id=" + e.Row.Cells[0].Text + "\" class=\"gView\" title=\"View/Edit\"></a>";

                object SubCount = c.GetReqData("MarksheetData", "COUNT(MarkId)", "MarkStudentID='" + e.Row.Cells[0].Text + "' AND FK_CenterID=" + Session["centerMaster"]);

                Literal litCount = (Literal)e.Row.FindControl("litCount");

                if (SubCount != DBNull.Value && SubCount != null && SubCount.ToString() != "")
                {
                    litCount.Text = SubCount.ToString();

                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "gvMarksheet_RowDataBound", ex.Message.ToString());
            return;
        }
    }
}