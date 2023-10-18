using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public partial class center_forgetPwd : System.Web.UI.Page
{
    iClass c = new iClass();
    public string rootPath, errMsg;
    protected void Page_Load(object sender, EventArgs e)
    {
        cmdRecover.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(cmdRecover, null) + ";");

        rootPath = c.ReturnHttp();
    }

    protected void cmdRecover_Click(object sender, EventArgs e)
    {
        txtEmail.Text = txtEmail.Text.Trim().Replace("'", "");

        if (txtEmail.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Enter Email Address.');", true);
            return;
        }
        if (c.IsRecordExist("Select * From CentersData Where CenterEmail='" + txtEmail.Text.Trim() + "'") == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Invalid Email Address.');", true);

            return;
        }

        //string userName = txtEmail.Text.Trim();
        //string userPwd = c.GetReqData("CentersData", "CenterPassword", "CenterEmail='" + userName + "'").ToString();
        //string msgData = "<p>Dear Hospital Team, <br/> Your login credentials for MedCare Hospital Portal are given below<br/><br/> <b>User Email : </b>" + userName + "<br/><b>Password :</b>" + userPwd + "<br/><br/>For any queries, please contact 94250 26970</p>";

        ////c.SendMail("info@nandadeepeyehospital.org", "Nandadeep Eye Hospital", txtEmail.Text.Trim(), msgData, "Account Credentials", "", true, "", "");

        //MailMessage mail = new MailMessage();
        //mail.To.Add(userName);

        //mail.CC.Add(new MailAddress("corporate@medcaresolutions.co.in"));
        //mail.Subject = "Forgot Password Recovery";
        //mail.Body = msgData;
        //mail.IsBodyHtml = true;

        //mail.Priority = System.Net.Mail.MailPriority.High;
        //SmtpClient client = new SmtpClient();
        //client.EnableSsl = true;
        //// client.UseDefaultCredentials = false;
        //client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
        //client.Send(mail);

        ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Account details send to your email.');", true);

        txtEmail.Text = "";
        //Response.Redirect("Default.aspx", false);
    }

}