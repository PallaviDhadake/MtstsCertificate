﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class center_Default : System.Web.UI.Page
{
    iClass c = new iClass();
    public string errMsg;

    protected void Page_Load(object sender, EventArgs e)
    {
        btnSubmit.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnSubmit, null) + ";");
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        txtConfirm.Text = txtConfirm.Text.Trim().Replace("'", "");
        txtNew.Text = txtNew.Text.Trim().Replace("'", "");
        txtOld.Text = txtOld.Text.Trim().Replace("'", "");

        if (txtOld.Text == "" || txtNew.Text == "" || txtConfirm.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Enter Old and New password');", true);
            return;
        }
        if (txtOld.Text == txtNew.Text)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', ' Old password and New passwords cannot be same');", true);
            return;
        }

        try
        {
            if (txtOld.Text == c.GetReqData("CentersData", "CenterPassword", "CenterID="+Session["centerMaster"].ToString()).ToString())
            {
                if (txtNew.Text.Length < 6)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', ' Password shoould be at least 6 characters long');", true);
                    return;
                }
                else
                {
                    if (txtNew.Text == txtConfirm.Text)
                    {
                        c.ExecuteQuery("Update CentersData set CenterPassword='" + txtNew.Text + "' Where CenterID=" + Session["centerMaster"].ToString());

                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Password successfully changed');", true);

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', ' New password confirmation failed');", true);
                        return;
                    }
                    txtNew.Text = txtOld.Text = txtConfirm.Text = "";
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', ' Old password did not match');", true);
                return;
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSubmit_Click", ex.Message.ToString());
            return;
        }
    }
}