using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
public partial class verifycertificate : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle, certificateNum;
    public string[] ordCertData = new string[30];

    protected void Page_Load(object sender, EventArgs e)
    {
        pgTitle = "Verify Students Certificate";

        table.Visible = false;

    }


    //private void FillGrid()
    //{
    //    try
    //    {
    //        using (DataTable dtCenter = c.GetDataTable("Select * from CertificateData where CertNumber='"+txtcertificateNo.Text+"'"))
    //        {
    //            gvcertificate.DataSource = dtCenter;
    //            gvcertificate.DataBind();

    //            if (dtCenter.Rows.Count > 0)
    //            {
    //                gvcertificate.UseAccessibleHeader = true;
    //                gvcertificate.HeaderRow.TableSection = TableRowSection.TableHeader;
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
    //        c.ErrorLogHandler(this.ToString(), "FillGrid", ex.Message.ToString());
    //        return;
    //    }
    //}


    private bool GetOldCertificates(string certificateNum)
    {
        try
        {
            string cs = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Centraleucation"].ConnectionString;
            using (SqlConnection cmd = new SqlConnection(cs))
                cmd.Open();
            DataTable dttbl = new DataTable();

            // using (SqlCommand cmd = new SqlCommand("Select * from Studentsdata where certificateNum='" + txtcertificateNo.Text + "',"))
            //using ( cmd = new SqlCommand("Select * from Studentsdata where certificateNum='" + txtcertificateNo.Text + "',"))
            SqlDataAdapter sda = new SqlDataAdapter("Select  a.certificateNum, a.stdFullName, a.stdCourseName, b.centName from Studentsdata a Inner Join Centersdata b ON a.centIdStd=b.centId Where certificateNum='" + certificateNum + "'", cs);
            {
                sda.Fill(dttbl);
                // using (SqlDataAdapter sda = new SqlDataAdapter())
                //{
                if (dttbl.Rows.Count > 0)
                {
                    DataRow row = dttbl.Rows[0];

                    ordCertData[0] = row["certificateNum"] != DBNull.Value && row["certificateNum"] != null && row["certificateNum"].ToString() != "" ? row["certificateNum"].ToString() : "NA";

                    ordCertData[1] = row["stdFullName"] != DBNull.Value && row["stdFullName"] != null && row["stdFullName"].ToString() != "" ? row["stdFullName"].ToString() : "NA";

                    ordCertData[2] = row["stdCourseName"] != DBNull.Value && row["stdCourseName"] != null && row["stdCourseName"].ToString() != "" ? row["stdCourseName"].ToString() : "NA";

                    ordCertData[3] = row["centName"] != DBNull.Value && row["centName"] != null && row["centName"].ToString() != "" ? row["centName"].ToString() : "NA";
                    table.Visible = true;
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetOldCertificates", ex.Message.ToString());
            return false;

        }
    
    }


    public void GetData()
    {
        try
        {
            using (DataTable dtcertificate = c.GetDataTable("Select * from CertificateData where CertNumber='" + txtcertificateNo.Text + "'"))
            {
                if (dtcertificate.Rows.Count > 0)
                {
                    DataRow row = dtcertificate.Rows[0];
                    ordCertData[0] = row["CertNumber"] != DBNull.Value && row["CertNumber"] != null && row["CertNumber"].ToString() != "" ? row["CertNumber"].ToString() : "NA";

                    ordCertData[1] = row["CertStudentName"] != DBNull.Value && row["CertStudentName"] != null && row["CertStudentName"].ToString() != "" ? row["CertStudentName"].ToString() : "NA";

                    ordCertData[2] = row["CertCourseName"] != DBNull.Value && row["CertCourseName"] != null && row["CertCourseName"].ToString() != "" ? row["CertCourseName"].ToString() : "NA";

                    ordCertData[3] = row["CertCenterName"] != DBNull.Value && row["CertCenterName"] != null && row["CertCenterName"].ToString() != "" ? row["CertCenterName"].ToString() : "NA";
                    table.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Invalid Certificate No Entered!');", true);
                    return;
                }
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "GetData", ex.Message.ToString());
            return;
        }
    }


    protected void btnverify_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtcertificateNo.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'All * Fields are mandatory');", true);
                return;
            }

            if (GetOldCertificates(txtcertificateNo.Text) == false)
            {
                // Then check into new certificate database
                GetData();
            }
   

            //if (c.IsRecordExist("Select CertID From CertificateData Where CertNumber='" + txtcertificateNo.Text + "' "))
            //{
            //    GetData();
            //    table.Visible = true;
            //}

            //else if (c.IsRecordExist("Select stdId From Studentsdata Where certificateNum='" + txtcertificateNo.Text + "'"))
            //{
            //    GetOldCertificates(Convert.(certificateNum));
            //    table.Visible = true;
            //}

            //else 
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Certificate Not Found!');", true);
            //    return;
            //}
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnverify_Click", ex.Message.ToString());
            return;
        }
    }
}