using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    iClass c = new iClass();
    public string errMsg;
    public string rootPath, forgetpass;
    protected void Page_Load(object sender, EventArgs e)
    {
        cmdSign.Attributes.Add("onclick", "this.disabled=true;this.value='Processing...';" + ClientScript.GetPostBackEventReference(cmdSign, null) + ";");
        txtUserMobile.Focus();

        rootPath = c.ReturnHttp();
        if (Request.QueryString["act"] != null)
        {
            if (Request.QueryString["act"] == "logout")
            {
                Session["adminMaster"] = null;
                Response.Redirect(rootPath+ "adminpanel");
            }

            if (Request.QueryString["act"] == "Centerlogout")
            {
                Session["centerMaster"] = null;
                Response.Redirect(rootPath);
            }
        }
        if (!IsPostBack)
        {
            if (Session["centerMaster"] != null)
            {
                Response.Redirect(rootPath + "center/dashboard.aspx");
            }
        }
    }

    protected void cmdSign_Click(object sender, EventArgs e)
    {
        try
        {
            txtUserMobile.Text = txtUserMobile.Text.Trim().Replace("'", "");
            txtPwd.Text = txtPwd.Text.Trim().Replace("'", "");

            if (txtUserMobile.Text == "" || txtPwd.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Enter UserMobile & Password.');", true);
                return;
            }
            if (!c.IsRecordExist("Select CenterID From CentersData Where CenterContactNo='" + txtUserMobile.Text + "'"))
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Invalid Mobile No Entered, Try Again.');", true);
                return;
            }


            if (c.GetReqData("CentersData", "CenterPassword", "CenterContactNo='" + txtUserMobile.Text + "'").ToString() != txtPwd.Text)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Wrong Password Entered. Try Again.');", true);
                return;
            }

            object CenterStatus = c.GetReqData("CentersData", "CenterStatus", "CenterContactNo='" + txtUserMobile.Text + "'");
            if (CenterStatus != DBNull.Value && CenterStatus != null && CenterStatus.ToString() != "") 
            {
                if (CenterStatus.ToString() == "2")
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Your Center Has Been Blocked');", true);
                    return;
                }
                else if (CenterStatus.ToString() == "3")
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Your Center Has Been Deleted');", true);
                    return;
                }
                else
                {
                    Session["centerMaster"] = c.GetReqData("CentersData", "CenterID", "CenterContactNo='" + txtUserMobile.Text + "'");
                    Response.Redirect(rootPath + "center/dashboard.aspx", false);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Center Status Not Found!');", true);
                return;
                //Session["centerMaster"] = c.GetReqData("CentersData", "CenterID", "CenterContactNo='" + txtUserMobile.Text + "'");
                //Response.Redirect(rootPath + "center/dashboard.aspx", false);
            }
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "cmdSign_Click", ex.Message.ToString());
            return;
        }
    }
}