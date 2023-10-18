using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adminpanel_Default2 : System.Web.UI.Page
{
    iClass c = new iClass();
    public string[] arrCounts = new string[10];
    public string rdrUrl;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetCount();
    }
    protected void GetCount()
    {
        try
        {
            arrCounts[0] = c.returnAggregate("Select Count(CenterID) From CentersData where CenterStatus=1").ToString();
            arrCounts[3] = c.returnAggregate("Select Count(CenterID) From CentersData where CenterStatus=2").ToString();
            arrCounts[1] = c.returnAggregate("Select Count(CertID) From CertificateData").ToString();
            arrCounts[2] = c.returnAggregate("Select Count(MarkID) From MarksheetData").ToString();
            arrCounts[3] = c.returnAggregate("Select Count(CenterID) From CentersData").ToString();
            arrCounts[4] = c.returnAggregate("Select Count(CenterID) From CentersData where CenterStatus=2").ToString();
            arrCounts[5] = c.returnAggregate("Select Count(CenterID) From CentersData where CenterStatus=3").ToString();
            arrCounts[6] = c.returnAggregate("Select Count(CertID) From CertificateData").ToString();
            //arrCounts[1] = c.returnAggregate("Select Count(Hosp_ReqID) From HospRequirements where Hosp_ReqStatus=0 AND FK_HospID=" + Session["clientMaster"] + " AND DelMark=0").ToString();
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetCount", ex.Message.ToString());
            return;
        }
    }
}