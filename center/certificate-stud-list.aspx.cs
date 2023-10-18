using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class center_certificate_stud_list : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle;
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
            using (DataTable dtcertificate = c.GetDataTable("Select CertID, CertNumber, CertCourseName, CertDuration, CertStudentName, CertPlace, CertGrade From CertificateData Where FK_CenterID=" + Session["centerMaster"]))
            {
                gvCertificate.DataSource = dtcertificate;
                gvCertificate.DataBind();

                if (dtcertificate.Rows.Count > 0)
                {
                    gvCertificate.UseAccessibleHeader = true;
                    gvCertificate.HeaderRow.TableSection = TableRowSection.TableHeader;
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



    protected void gvCertificate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Literal litAnch = (Literal)e.Row.FindControl("litAnch");
                //litAnch.Text = "<a href=\"certificate-all-details.aspx?id=" + e.Row.Cells[0].Text + "\" class=\"gView\" title=\"View/AddPhtos\"></a>";

                Literal litPhotos = (Literal)e.Row.FindControl("litAddPhotos");
                litPhotos.Text = "<a href=\"add-stud-photos.aspx?id=" + e.Row.Cells[0].Text + "\" class=\"addPhoto\" title=\"Add Photos\" ></a>";
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "gvCertificate_RowDataBound", ex.Message.ToString());
            return;
        }
    }

}