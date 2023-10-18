using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class adminpanel_Default2 : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle, signPhoto;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            pgTitle = Request.QueryString["action"] == "new" ? "Add Centers Data" : "Edit Centers Data";
            btnSave.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnSave, null) + ";");
            btnDelete.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnDelete, null) + ";");
            btnCancel.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnCancel, null) + ";");

            if (!IsPostBack)
            {
                if (Request.QueryString["action"] != null)
                {
                    editCenter.Visible = true;
                    viewcenter.Visible = false;

                    if (Request.QueryString["action"] == "new")
                    {
                        btnSave.Text = "Save Info";
                        btnDelete.Visible = false;
                        //txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        btnRemove.Visible = false;
                        btnBlock.Visible = false;
                    }
                    else
                    {
                        btnSave.Text = "Modify Info";
                        btnDelete.Visible = true;
                        //btnBlock.Visible = true;
                        GetCenterData(Convert.ToInt32(Request.QueryString["id"]));
                    }
                }
                else
                {
                    editCenter.Visible = false;
                    viewcenter.Visible = true;
                    FillGrid();
                }
                //if (Request.QueryString["type"] == "active")
                //{
                //    pgTitle = "Active Centers";
                //}
                //else if (Request.QueryString["type"] == "blocked")
                //{
                //    pgTitle = "Blocked Centers";
                //}
                //else if (Request.QueryString["type"] == "deleted")
                //{
                //    pgTitle = "Deleted Centers";
                //}
                //else
                //{
                //    pgTitle = "Centers Data";
                //}
            }
            chkbxrapid.Checked = true;
            lblId.Visible = false;
        

        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "Page_Load", ex.Message.ToString());
            return;
        }
    }

    private void FillGrid()
    {
        try
        {
            string strQuery = "";
            if (Request.QueryString["type"] != null)
            {
                switch (Request.QueryString["type"])
                {
                    case "active":
                        strQuery = "Select CenterID, Convert(varchar(20), CenterRegDate, 103) as CenterRegDate, CenterName, CenterPerson, CenterContactNo, CenterEmail, CenterPlace From CentersData Where CenterStatus=1 Order By CenterRegDate DESC";
                        //addNew.Visible = false;
                        //pgTitle = "Active Centers";
                        break;

                    case "blocked":
                        strQuery = "Select CenterID, Convert(varchar(20), CenterRegDate, 103) as CenterRegDate, CenterName, CenterPerson, CenterContactNo, CenterEmail, CenterPlace From CentersData Where CenterStatus=2 Order By CenterRegDate DESC";
                        //addNew.Visible = false;
                        break;
                    case "delete":
                        strQuery = "Select CenterID, Convert(varchar(20), CenterRegDate, 103) as CenterRegDate, CenterName, CenterPerson, CenterContactNo, CenterEmail, CenterPlace From CentersData Where CenterStatus=3 Order By CenterRegDate DESC";
                        //addNew.Visible = false;
                        break;
                }
            }
            else
            {
                strQuery = "Select CenterID, Convert(varchar(20), CenterRegDate, 103) as CenterRegDate, CenterName, CenterPerson, CenterContactNo, CenterEmail, CenterPlace From CentersData  Order By CenterRegDate DESC";
            }
            //using (DataTable dtCenter = c.GetDataTable("Select CenterID, Convert(varchar(20), CenterRegDate, 103) as CenterRegDate, CenterName, CenterPerson, CenterContactNo, CenterEmail, CenterPlace From CentersData  Order By CenterRegDate DESC"))
            using (DataTable dtCenter = c.GetDataTable(strQuery))
            {
                gvCenters.DataSource = dtCenter;
                gvCenters.DataBind();

                if (dtCenter.Rows.Count > 0)
                {
                    gvCenters.UseAccessibleHeader = true;
                    gvCenters.HeaderRow.TableSection = TableRowSection.TableHeader;
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


    protected void gvCenters_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal litAnch = (Literal)e.Row.FindControl("litAnch");
                litAnch.Text = "<a href=\"center-master.aspx?action=edit&id=" + e.Row.Cells[0].Text + "\"class=\"gAnch\" title=\"View/Edit\"></a>";

                object status = c.GetReqData("CentersData", "CenterStatus", "CenterID=" + e.Row.Cells[0].Text);

                Literal litStatus = (Literal)e.Row.FindControl("litstatus");
                if (status != DBNull.Value && status != null && status.ToString() != "")
                {
                    switch (status.ToString())
                    {
                        case "1":
                            litStatus.Text = "<div class=\"reqStatus bggreen\">Active</div>";
                            break;
                        case "2":
                            litStatus.Text = "<div class=\"reqStatus bgorange\">Blocked</div>";
                            break;
                        case "3":
                            litStatus.Text = "<div class=\"reqStatus bgred\">Deleted</div>";
                            break;
                    }
                }

                //object cenStatus = c.GetReqData("CentersData", "CenterStatus", "CenterID=" + e.Row.Cells[0].Text);
                //if (cenStatus != DBNull.Value && cenStatus != null && cenStatus.ToString() != "")
                //{
                //    switch (cenStatus.ToString())
                //    {
                //        case "1":
                //            pgTitle = "Add Centers Data";
                //            break;
                //        case "2":
                //            pgTitle = "Unblock/Edit Centers Data";
                //            break;
                //        case "3":
                //            pgTitle = "Centers Data";
                //            break;
                //    }
                //}

            }
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "gvNews_RowDataBound", ex.Message.ToString());
            return;
        }
    }

    public void GetAllControls(ControlCollection ctrs)
    {
        foreach (Control c in ctrs)
        {
            if (c is System.Web.UI.WebControls.TextBox)
            {
                TextBox tt = c as TextBox;
                tt.Text = tt.Text.Trim().Replace("'", "");
            }
            if (c.HasControls())
            {
                GetAllControls(c.Controls);
            }
        }
    }

    public void GetCenterData(int CenterIdx)
    {
        try
        {
            using (DataTable dtCenters = c.GetDataTable("select * from CentersData where CenterID=" + CenterIdx))
            {
                if (dtCenters.Rows.Count > 0)
                {
                    DataRow row = dtCenters.Rows[0];
                    lblId.Text = CenterIdx.ToString();
                    //txtDate.Text = Convert.ToDateTime(row["CenterRegDate"]).ToString("dd/MM/yyyy");
                    txtPlace.Text = row["CenterPlace"].ToString();
                    txtName.Text = row["CenterPerson"].ToString();
                    txtEmail.Text = row["CenterEmail"].ToString();
                    txtContact.Text = row["CenterContactNo"].ToString();
                    txtCenterNm.Text = row["CenterName"].ToString();
                    txtCenRegNo.Text = row["CenterRegNumber"].ToString();
                    txtCenAdd.Text = row["CenterAddr"].ToString();
                    txtPassword.Text = row["CenterPassword"].ToString();


                    //Size of signature img-188*65
                    if (row["CenterSign"] != DBNull.Value && row["CenterSign"] != null && row["CenterSign"].ToString() != "" && row["CenterSign"].ToString() != "no-photo.png")
                    {
                        signPhoto = "<img src=\"" + Master.rootPath + "upload/center/" + row["CenterSign"].ToString() + "\" width=\"200\" />";
                        //btnRemove.Visible = true;

                        if (row["centersign"].ToString() == "")
                        {
                            btnRemove.Visible = false;
                        }
                        else
                        {
                            btnRemove.Visible = true;
                        }

                    }
                    else
                    {
                        btnRemove.Visible = false;
                    }

                    object status = c.GetReqData("CentersData", "CenterStatus", "CenterID=" + Request.QueryString["id"]);

                    if (status != DBNull.Value && status != null && status.ToString() != "")
                    {
                        switch (status.ToString())
                        {
                            case "1":
                                btnBlock.Visible = true;
                                btnSave.Text = "Modify Info";
                                break;
                            case "2":
                                btnBlock.Text = "UnBlock User";
                                //btnDelete.Visible = true;
                                btnSave.Visible = false;
                                break;
                            case "3":
                                btnBlock.Visible = false;
                                btnDelete.Visible = false;
                                btnSave.Visible = false;
                                break;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetCenterData", ex.Message.ToString());
            return;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            GetAllControls(this.Controls);
            //Empty Validations
            if (txtCenAdd.Text == "" || txtCenRegNo.Text == "" || txtCenterNm.Text==""||txtContact.Text==""|| txtEmail.Text==""||txtName.Text==""||txtPassword.Text==""||txtPlace.Text==""||fuImage.HasFile==false)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * Fields are mandatory');", true);
                return;
            }

            int maxId = lblId.Text == "[New]" ? c.NextId("CentersData", "CenterID") : Convert.ToInt32(lblId.Text);

            //DateTime appDate = DateTime.Now;
            //string[] arrDate = txtDate.Text.Split('/');
            //if (c.IsDate(arrDate[1] + "/" + arrDate[0] + "/" + arrDate[2]) == false)
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Enter Valid Date');", true);
            //    return;
            //}
            //else
            //{
            //    appDate = Convert.ToDateTime(arrDate[1] + "/" + arrDate[0] + "/" + arrDate[2]);
            //}

            //DateTime cDate = DateTime.Now;
            //string currentDate = cDate.ToString("yyyy-MM-dd HH:mm:ss.fff");

            string signPhoto = "";
            if (fuImage.HasFile)
            {
                string fExt = Path.GetExtension(fuImage.FileName).ToString().ToLower();
                //string size=Path.
                //string size = Path.GetFullPath(fuImage.FileName).ToString().ToLower();
                

                if (fExt == ".jpg" || fExt == ".jpeg" || fExt == ".png" || fExt == ".pdf")
                {
                    signPhoto = "sign-photo-" + maxId + DateTime.Now.ToString("ddMMyyyyHHmmss") + fExt;
                    ImageUploadProcess(signPhoto);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Only .jpg, .jpeg .png .pdf  or  files are allowed');", true);
                    return;

                }

                //string size = Path.GetFullPath(fuImage.FileName).ToString().ToLower();
                 // long fSize = new System.IO.FileInfo(size).Length;
                //if (size.Length == 1024)
                //{
                //    signPhoto = "sign-photo-" + maxId + DateTime.Now.ToString("ddMMyyyyHHmmss") + size;
                //    ImageUploadProcess(signPhoto);
                //}
                //else
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'file size must be 188*65');", true);
                //    return;
                //}


            }

            if (lblId.Text == "[New]")
            {

                if (c.IsRecordExist("Select CenterID From CentersData Where CenterRegNumber='" + txtCenRegNo.Text + "'"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', ' Center number allready exist');", true);
                    return;
                }

                c.ExecuteQuery("Insert into CentersData(CenterID, CenterRegDate, CenterName, CenterRegNumber, CenterPerson, CenterSign, CenterContactNo, CenterEmail, CenterPassword, CenterPlace, CenterAddr, CenterStatus)Values(" + maxId+", '"+DateTime.Now+"', '"+txtCenterNm.Text+"', '"+txtCenRegNo.Text+"', '"+txtName.Text+"', '"+signPhoto+"', '"+txtContact.Text+"', '"+txtEmail.Text+"', '"+txtPassword.Text+"', '"+txtPlace.Text+"', '"+txtCenAdd.Text+"', 1);");

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Center Data  Added');", true);
            }
            else
            {

                chkbxrapid.Checked = false;

                c.ExecuteQuery("Update CentersData Set CenterName='" + txtCenterNm.Text + "', CenterRegNumber='" + txtCenRegNo.Text + "', CenterPerson='" + txtName.Text + "', CenterContactNo='" + txtContact.Text + "', CenterEmail='" + txtEmail.Text + "', CenterPassword='" + txtPassword.Text + "', CenterPlace='" + txtPlace.Text + "', CenterAddr='" + txtCenAdd.Text + "' Where CenterID="+maxId);

                if (fuImage.HasFile)
                {
                    c.ExecuteQuery("Update CentersData Set CenterSign='" + signPhoto + "' where CenterID=" + maxId + "");
                }

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Center Data  Updated');", true);
            }

            if (c.IsRecordExist("Select CertID From CertificateData Where CertCenterNo='" + txtCenRegNo.Text + "' AND FK_CenterID=0 "))
            {
                //object certId = c.GetReqData("CertificateData", "CertID", "CertCenterNo='" + txtCenRegNo.Text + "' AND FK_CenterID=0");

                c.ExecuteQuery("Update CertificateData set FK_CenterID='" + maxId + "' Where CertCenterNo='" + txtCenRegNo.Text + "'");
            }

            if (c.IsRecordExist("Select MarkID From MarksheetData Where MarkCenterNo='" + txtCenRegNo.Text + "' AND FK_CenterID=0 "))
            {
                //object certId = c.GetReqData("CertificateData", "CertID", "CertCenterNo='" + txtCenRegNo.Text + "' AND FK_CenterID=0");

                c.ExecuteQuery("Update MarksheetData set FK_CenterID='" + maxId + "' Where MarkCenterNo='" + txtCenRegNo.Text + "'");
            }

            if (chkbxrapid.Checked == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('center-master.aspx', 2000);", true);
            }
            if (Request.QueryString["action"] == "new")
            {
                chkbxrapid.Checked = true;
                txtCenRegNo.Focus();
            }
            else
            {
                chkbxrapid.Checked = false;
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('center-master.aspx', 2000);", true);

            }

            txtCenAdd.Text = txtCenRegNo.Text = txtCenterNm.Text = txtContact.Text = txtEmail.Text = txtName.Text = txtPassword.Text = txtPlace.Text = "";
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSave_Click", ex.Message.ToString());
            return;
        }
    }

    private void ImageUploadProcess(string Signimage)
    {
        try
        {

            string origImgPath = "~/upload/center/original/";
            //string thumbImgPath = "~/upload/center/thumb/";
            string normalImgPath = "~/upload/center/";

            fuImage.SaveAs(Server.MapPath(origImgPath) + Signimage);
            c.ImageOptimizer(Signimage, origImgPath, normalImgPath, 188, true);
           // c.ImageOptimizer(Signimage, normalImgPath, thumbImgPath, 188, true);
                

            //Delete rew image from server
            File.Delete(Server.MapPath(origImgPath) + Signimage);

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "ImageUploadProcess", ex.Message.ToString());
            return;
        }
    }




    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("Update CentersData Set CenterStatus=3 Where CenterID=" + Request.QueryString["id"]);

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Center Data Deleted');", true);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('center-master.aspx', 2000);", true);

        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnDelete_Click", ex.Message.ToString());
            return;
        }
    }



    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("center-master.aspx");
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            c.ExecuteQuery("Update CentersData set CenterSign='no-photo.png' Where CenterID=" + Request.QueryString["id"]);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Signature Image Removed');", true);
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('center-master.aspx', 2000);", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnRemove_Click", ex.Message.ToString());
            return;

        }
    }

    protected void btnBlock_Click(object sender, EventArgs e)
    {
        try
        {
            object status = c.GetReqData("CentersData", "CenterStatus", "CenterID=" + Request.QueryString["id"]);

            if (status != DBNull.Value && status != null && status.ToString() != "")

                if (status.ToString() == "1")
                {

                    c.ExecuteQuery("Update CentersData Set CenterStatus=2 Where CenterID=" + Request.QueryString["id"]);

                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Center Blocked Successfully');", true);
                }
                if (status.ToString() == "2")
                {

                    c.ExecuteQuery("Update CentersData Set CenterStatus=1 Where CenterID=" + Request.QueryString["id"]);

                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Center UnBlock Successfully');", true);
                }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "CallMyFunction", "waitAndMove('center-master.aspx', 2000);", true);

        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnBlock_Click", ex.Message.ToString());
            return;
        }
    }
}