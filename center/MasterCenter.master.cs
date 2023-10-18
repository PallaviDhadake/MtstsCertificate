using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class center_MasterCenter : System.Web.UI.MasterPage
{
    iClass c = new iClass();
    public string rootPath, pgTitle;
    protected void Page_Load(object sender, EventArgs e)
    {
        //rootPath = c.ReturnHttp();
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "sessionPingTrigger();", true);

        object CenterName = c.GetReqData("CentersData", "CenterName", "CenterID=" + Session["centerMaster"]);

        if (CenterName != DBNull.Value && CenterName != null && CenterName.ToString() != "")
        {

            pgTitle = "<span class=\"greenName\">" + CenterName.ToString() + "</span>";
        }
        else
        {
            pgTitle = "<span>NA</span>";
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        rootPath = c.ReturnHttp();
        ScriptManager1.Services.Add(new ServiceReference(rootPath + "WebServices/MtstsCertificateWebService.asmx"));

        if (Session["centerMaster"] == null)
        {
            Response.Redirect(rootPath);
        }
    }

}
