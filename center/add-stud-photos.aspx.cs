using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class center_add_stud_photos : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle, studImge;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //pgTitle = Request.QueryString["action"] == "new" ? "Add  Image" : "Edit Image";
            btnSave.Attributes.Add("onclick", "this.disabled=true; this.value='Processing...';" + ClientScript.GetPostBackEventReference(btnSave, null) + ";");
            // btnDelete.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnDelete, null) + ";");
            btnCancel.Attributes.Add("onclick", "this.disabled=true; this.value='Processing...';" + ClientScript.GetPostBackEventReference(btnCancel, null) + ";");

            if (!IsPostBack)
            {

            }
            lblId.Visible = false;

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "Page_Load", ex.Message.ToString());
            return;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //Empty Fields Validations
            if (fuStudImage.HasFile == false || fusign.HasFile == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * Fields are mandatory');", true);
                return;
            }
            int maxId = lblId.Text == "[New]" ? c.NextId("CentersData", "CenterID") : Convert.ToInt16(lblId.Text);

            string studPhoto = "";
            if (fuStudImage.HasFile)
            {
                string fExt = Path.GetExtension(fuStudImage.FileName).ToString().ToLower();

                if (fExt == ".jpg" || fExt == ".jpeg" || fExt == ".png" || fExt == ".pdf")
                {
                    studPhoto = "student-photo-" + maxId + DateTime.Now.ToString("ddMMyyyyHHmmss") + fExt;
                    ImageUploadProcess(studPhoto);
                    //fuStudImage.SaveAs(Server.MapPath("~/upload/hospital/") + hospPhoto);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only .jpg, .jpeg .png .pdf files are allowed');", true);
                    return;

                }
            }
            else
            {
                if (lblId.Text == "[New]")
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('waring', 'Add Image');", true);
                    return;

                }
            }

            string studsign = "";
            if (fusign.HasFile)
            {
                string fExt = Path.GetExtension(fusign.FileName).ToString().ToLower();

                if (fExt == ".jpg" || fExt == ".jpeg" || fExt == ".png" || fExt == ".pdf")
                {
                    studsign = "student-sign-" + maxId + DateTime.Now.ToString("ddMMyyyyHHmmss") + fExt;
                    ImageUploadProcess1(studsign);
                    //fusign.SaveAs(Server.MapPath("~/upload/hospital/") + hospPhoto);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only .jpg, .jpeg .png .pdf files are allowed');", true);
                    return;

                }
            }
            else
            {
                if (lblId.Text == "[New]")
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('waring', 'Add signature');", true);
                    return;

                }
            }

            if (lblId.Text == "[New]")
            {
                //Insert Update Data
                // c.ExecuteQuery("Update CentersData Set CenterStudPhto='" + studPhoto + "', CenterStudSign='" + studsign + "' Where CenterID="+Request.QueryString["id"]);

                c.ExecuteQuery("Update CertificateData Set CertStudPhoto='" + studPhoto + "', CertStudSign='" + studsign + "' Where CertID=" + Request.QueryString["id"]);

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Student Image and Student Signature Added');", true);
            }
            else
            {

            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }


    private void ImageUploadProcess(string studPhoto)
    {
        try
        {

            string origImgPath = "~/upload/student/photo/orignal/";
            //string thumbImgPath = "~/upload/student/photo/";
            string normalImgPath = "~/upload/student/photo/";

            fuStudImage.SaveAs(Server.MapPath(origImgPath) + studPhoto);
            c.ImageOptimizer(studPhoto, origImgPath, normalImgPath, 150, true);
            // c.ImageOptimizer(Signimage, normalImgPath, thumbImgPath, 188, true);


            //Delete rew image from server
            File.Delete(Server.MapPath(origImgPath) + studPhoto);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "ImageUploadProcess", ex.Message.ToString());
            return;
        }
    }

    private void ImageUploadProcess1(string studsign)
    {
        try
        {

            string origImgPath = "~/upload/student/sign/orignal/";
            //string thumbImgPath = "~/upload/center/thumb/";
            string normalImgPath = "~/upload/student/sign/";

            fusign.SaveAs(Server.MapPath(origImgPath) + studsign);
            c.ImageOptimizer(studsign, origImgPath, normalImgPath, 150, true);
            // c.ImageOptimizer(Signimage, normalImgPath, thumbImgPath, 188, true);


            //Delete rew image from server
            File.Delete(Server.MapPath(origImgPath) + studsign);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "ImageUploadProcess1", ex.Message.ToString());
            return;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("certificate-stud-list.aspx");
    }

}