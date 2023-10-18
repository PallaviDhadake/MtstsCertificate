using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

public partial class adminpanel_Default2 : System.Web.UI.Page
{
    iClass c = new iClass();
    public string pgTitle, certificate, errMsg2;
    public int rowNo = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSubmit.Attributes.Add("onclick", " this.disabled = true; this.value='Processing...'; " + ClientScript.GetPostBackEventReference(btnSubmit, null) + ";");

        lblId.Visible = false;

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (!fuImage.HasFile)
            {
                //errMsg1 = c.ErrNotification(2, "Select File to Fetch Data");
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select File to Fetch Data');", true);
                return;
            }
            else
            {
                string fExt = Path.GetExtension(fuImage.FileName).ToLower();
                if (fExt != ".csv")
                {
                    //errMsg1 = c.ErrNotification(2, "Invalid file extension. Only .csv files are allowed.");
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Invalid file extension. Only .csv files are allowed');", true);
                    return;
                }
                else
                {
                    string rootPath = c.ReturnHttp();

                    string filename = "mtsts-certificates";
                    string filePath = "~/upload/certificate/";
                    //string path = Server.MapPath((filePath) + filename + fExt);

                    fuImage.SaveAs(Server.MapPath(filePath) + filename + fExt);

                    string csvPath = Server.MapPath("~/upload/certificate/"+ filename + fExt);
                    string csvData = File.ReadAllText(csvPath);

                    string rowNumbers = "";
                    int successRows = 0;
                    string emptyRows = "";
                    int emptyCount = 0;
                    string sRows = "";
                    int scannedRows = 0;

                    foreach(string row in csvData.Split('\n'))
                    {
                        scannedRows++;
                        if (!String.IsNullOrEmpty(row))
                        {
                            rowNo++;
                            string[] arrCells = row.Split(',');
                            if (arrCells.Length == 14 || arrCells.Length==15)
                            {
                                if (arrCells[1].ToString() != "")
                                {
                                    if (arrCells[0].ToString() == "CetificateNo")
                                    {

                                    }
                                    else
                                    {
                                        int MaxId = c.NextId("CertificateData", "CertID");

                                        //int certificateno = Convert.ToInt32(arrCells[0].ToString() != "" ? arrCells[0].ToString().Trim().Replace("'", "") : "NA");
                                        string certificateno = arrCells[0].ToString() != "" ? arrCells[0].ToString().Trim().Replace("'", "") : "NA";
                                        string courseName = arrCells[1].ToString() != "" ? arrCells[1].ToString().Trim().Replace("'", "") : "NA";
                                        string duration = arrCells[2].ToString() != "" ? arrCells[2].ToString().Trim().Replace("'", "") : "NA";

                                        double avgMarks = arrCells[3].ToString() != "" ? Convert.ToDouble(Regex.Replace(arrCells[3].ToString(), "[^-?0-9\\.]+", "")) : 0;
                                        string grade = arrCells[4].ToString() != "" ? arrCells[4].ToString().Trim().Replace("'", "") : "NA";

                                        //ToDate Code
                                        string toDate = arrCells[10].ToString() != "" ? arrCells[10].ToString().Trim().Replace("'", "") : "NA";
                                        string[] arrToTime = toDate.Split(' ');
                                        string[] arrToDate = arrToTime[0].Split('/');
                                        DateTime ToDate = Convert.ToDateTime(arrToDate[0] + "/" + arrToDate[1] + "/" + arrToDate[2]);

                                        //Exam Date code
                                        string examDate = arrCells[5].ToString() != "" ? arrCells[5].ToString().Trim().Replace("'", "") : "NA";

                                        string[] arrexamTime = examDate.Split(' ');
                                        string[] arrDate = arrexamTime[0].Split('/');
                                        DateTime ExamDate = Convert.ToDateTime(arrDate[0] + "/" + arrDate[1] + "/" + arrDate[2]);

                                        //Issue Date code
                                        string issueDate = arrCells[6].ToString() != "" ? arrCells[6].ToString().Trim().Replace("'", "") : "NA";
                                        string[] arrIssueTime = issueDate.Split(' ');
                                        string[] arrIsuueDate = arrIssueTime[0].Split('/');
                                        DateTime issuedDate = Convert.ToDateTime(arrIsuueDate[0] + "/" + arrIsuueDate[1] + "/" + arrIsuueDate[2]);


                                        string studName = arrCells[7].ToString() != "" ? arrCells[7].ToString().Trim().Replace("'", "") : "NA";
                                        string centerName = arrCells[8].ToString() != "" ? arrCells[8].ToString().Trim().Replace("'", "") : "NA";

                                        //From Date Code
                                        string fromDate = arrCells[9].ToString() != "" ? arrCells[9].ToString().Trim().Replace("'", "") : "NA";
                                        string[] arrFromTime = fromDate.Split(' ');
                                        string[] arrFromDate = arrFromTime[0].Split('/');
                                        DateTime FromDate = Convert.ToDateTime(arrFromDate[0] + "/" + arrFromDate[1] + "/" + arrFromDate[2]);

                                        //Student Reg Date Code
                                        string studRegDate = arrCells[11].ToString() != "" ? arrCells[11].ToString().Trim().Replace("'", "") : "NA";
                                        string[] arrStudTime = studRegDate.Split(' ');
                                        string[] arrStudRegDate = arrStudTime[0].Split('/');
                                        DateTime StudentregDate = Convert.ToDateTime(arrStudRegDate[0] + "/" + arrStudRegDate[1] + "/" + arrStudRegDate[2]);

                                        string place = arrCells[12].ToString() != "" ? arrCells[12].ToString().Trim().Replace("'", "") : "NA";
                                        string centerNo = arrCells[13].ToString() != "" ? arrCells[13].ToString().Trim().Replace("'", "") : "NA";
                                        //string fk_centerId = arrCells[13].ToString() != "" ? arrCells[13].ToString().Trim().Replace("'", "") : "NA";

                                        double finalMarks = Math.Round(avgMarks, 2);


                                        int CenterNumber = 0;

                                        if (c.IsRecordExist("Select CenterID From CentersData Where CenterRegNumber='" + centerNo + "'"))
                                        {
                                            CenterNumber = Convert.ToInt32(c.GetReqData("CentersData", "CenterID", "CenterRegNumber='" + centerNo + "'"));
                                        }
                                        else
                                        {
                                            CenterNumber = 0;
                                        }


                                        //int CenterNumber = 0;

                                        //if (c.IsRecordExist("Select CenterID From CentersData Where CenterRegNumber='" + centerNo + "' AND CenterID='"+MaxId+"'"))
                                        //{
                                        //    CenterNumber = Convert.ToInt32(c.GetReqData("CentersData", "CenterID", "CenterRegNumber='" + centerNo + "'"));
                                        //}
                                        //else
                                        //{
                                        //    CenterNumber = 0;
                                        //}

                                        //foreach (string crow in csvData.Split('\n'))
                                        //{
                                            if (chkcertiReplaceOldtoNew.Checked == true)
                                            {
                                                int cetificateID = 0;

                                                if (c.IsRecordExist("Select CertID From CertificateData Where CertCenterNo='" + centerNo + "' AND CertNumber='" + certificateno + "'"))
                                                {

                                                    //cetificateID = Convert.ToInt32(c.GetReqData("CertificateData", "CertID", "CertCenterNo='" + centerNo + "' AND CertNumber='" + certificateno + "'"));

                                                // c.ExecuteQuery("Delete From CertificateData Where CertID='" + cetificateID + "'");

                                                c.ExecuteQuery("Delete From CertificateData Where CertCenterNo='" + centerNo + "' AND CertNumber='" + certificateno + "'");

                                                //errMsg2 = "Data Replace Old to New Sucessfully";
                                            }
                                            }
                                            else
                                            {
                                                
                                            }
                                        //}

                                        //}
                                        //else
                                        //{

                                        //}

                                        //Duplications entry
                                        //if (c.IsRecordExist("Select CertID From CertificateData Where CertCenterNo='" + centerNo + "' AND CertNumber='" + certificateno + "'  "))
                                        //{

                                        //}
                                        //else
                                        //{

                                        c.ExecuteQuery("Insert into CertificateData(CertID, CertNumber, CertUploadDate, CertCourseName, CertDuration, CertAvgMarks, CertGrade, CertExamMonth, CertIssueDate, CertStudentName, CertCenterName, CertFromDate, CertToDate, CertStudentRegDate, CertPlace, CertCenterNo, FK_CenterID, CertStatus)Values(" + MaxId + ", '" + certificateno + "', '" + DateTime.Now + "', '" + courseName + "', '" + duration + "', " + finalMarks + ", '" + grade + "', '" + examDate + "', '" + issueDate + "', '" + studName + "', '" + centerName + "', '" + fromDate + "', '" + toDate + "', '" + studRegDate + "', '" + place + "', '" + centerNo + "', "+ CenterNumber + ", 0)");

                                            successRows++;

                                            if (sRows == "")
                                                sRows = rowNo.ToString();
                                            else
                                                sRows = sRows + ", " + rowNo.ToString();

                                        //}
                                    }
                                }
                            }
                            else
                            {
                                if (rowNumbers == "")
                                {
                                    rowNumbers = rowNo.ToString();
                                }
                                else
                                {
                                    rowNumbers = rowNumbers + ", " + rowNo.ToString();
                                }
                            }
                        }
                        else
                        {
                            emptyCount++;
                            if (emptyRows == "")
                            {
                                emptyRows = scannedRows.ToString();
                            }
                            else
                            {
                                emptyRows = emptyRows + ", " + scannedRows.ToString();
                            }
                        }
                    }

                    //errMsg1 = c.ErrNotification(1, "Data Fetched Successfully");
                    //ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('sucess', 'Data Fetched Successfully');", true);

                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('success', 'Data Fetched Successfully');", true);

                    errMsg2 = "Total Rows : " + scannedRows.ToString() +
                        "<br/>Successfully Inserted Rows :" + successRows +
                        "<br/>Defected Rows : " + rowNumbers.ToString() +
                        "<br/> Empty Rows : " + emptyCount.ToString();
                }
            }
        }
        catch(Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSubmit_Click", ex.Message.ToString());
            return;
        }
    }
}