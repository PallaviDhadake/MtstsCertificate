using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class center_Default : System.Web.UI.Page
{
    iClass c = new iClass();
    public string[] arrCounts = new string[10];
    public string rdrUrl;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetCount();
        }
    }
    protected void GetCount()
    {
        try
        {
            arrCounts[0] = c.returnAggregate("Select Count(CenterID) From CentersData where CenterStatus=1").ToString();
            arrCounts[1] = c.returnAggregate("Select Count(CertID) From CertificateData where FK_CenterID=" + Session["centerMaster"] + "").ToString();
            arrCounts[2] = c.returnAggregate("Select Count(Distinct MarkStudentID) From MarksheetData where FK_CenterID='" + Session["centerMaster"] + "' ").ToString();
            arrCounts[3] = c.returnAggregate("Select Count(CertID) From CertificateData Where FK_CenterID='" + Session["centerMaster"] + "' ").ToString();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetCount", ex.Message.ToString());
            return;
        }
    }
}