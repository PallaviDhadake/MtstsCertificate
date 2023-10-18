using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;
public partial class adminpanel_Default2 : System.Web.UI.Page
{
    iClass c = new iClass();
    public string marksheet, errMsg2;
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
            if (!fuMarksheet.HasFile)
            {
                //errMsg1 = c.ErrNotification(2, "Select File to Fetch Data");
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Select File to Fetch Data');", true);
                return;
            }
            else
            {
                string fExt = Path.GetExtension(fuMarksheet.FileName).ToLower();
                if (fExt != ".csv")
                {
                    //errMsg1 = c.ErrNotification(2, "Invalid file extension. Only .csv files are allowed.");
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Invalid file extension. Only .csv files are allowed');", true);
                    return;
                }
                else
                {
                    string rootPath = c.ReturnHttp();

                    string filename = "mtsts-marksheet";
                    string filePath = "~/upload/marksheet/";
                    //string path = Server.MapPath((filePath) + filename + fExt);

                    fuMarksheet.SaveAs(Server.MapPath(filePath) + filename + fExt);

                    string csvPath = Server.MapPath("~/upload/marksheet/" + filename + fExt);
                    string csvData = File.ReadAllText(csvPath);

                    string rowNumbers = "";
                    int successRows = 0;
                    string emptyRows = "";
                    int emptyCount = 0;
                    string sRows = "";
                    int scannedRows = 0;

                    foreach (string row in csvData.Split('\n'))
                    {
                        scannedRows++;
                        if (!String.IsNullOrEmpty(row))
                        {
                            rowNo++;
                            string[] arrCells = row.Split(',');
                            if (arrCells.Length == 20 ||arrCells.Length==19)
                            {
                                if (arrCells[1].ToString() != "")
                                {
                                    if (arrCells[0].ToString() == "CetificateNo")
                                    {

                                    }
                                    else
                                    {
                                        int MaxId = c.NextId("MarksheetData", "MarkID");

                                        //int certificateno = Convert.ToInt32(arrCells[0].ToString() != "" ? arrCells[0].ToString().Trim().Replace("'", "") : "NA");
                                        string certificateno = arrCells[0].ToString() != "" ? arrCells[0].ToString().Trim().Replace("'", "") : "NA";
                                        string studentName = arrCells[1].ToString() != "" ? arrCells[1].ToString().Trim().Replace("'", "") : "NA";
                                        string courseName = arrCells[2].ToString() != "" ? arrCells[2].ToString().Trim().Replace("'", "") : "NA";
                                        string centerName = arrCells[3].ToString() != "" ? arrCells[3].ToString().Trim().Replace("'", "") : "NA";
                                        //double centerName = arrCells[3].ToString() != "" ? Convert.ToDouble(Regex.Replace(arrCells[3].ToString(), "[^-?0-9\\.]+", "")) : 0;
                                        string place = arrCells[4].ToString() != "" ? arrCells[4].ToString().Trim().Replace("'", "") : "NA";
                                        string centerNo = arrCells[5].ToString() != "" ? arrCells[5].ToString().Trim().Replace("'", "") : "NA";
                                        string studId = arrCells[6].ToString() != "" ? arrCells[6].ToString().Trim().Replace("'", "") : "NA";

                                        //Exam Date code
                                        string examDate = arrCells[7].ToString() != "" ? arrCells[7].ToString().Trim().Replace("'", "") : "NA";
                                        string[] arrexamTime = examDate.Split(' ');
                                        string[] arrDate = arrexamTime[0].Split('/');
                                        DateTime ExamDate = Convert.ToDateTime(arrDate[0] + "/" + arrDate[1] + "/" + arrDate[2]);

                                        string duration = arrCells[8].ToString() != "" ? arrCells[8].ToString().Trim().Replace("'", "") : "NA";

                                        string subjectName = arrCells[9].ToString() != "" ? arrCells[9].ToString().Trim().Replace("'", "") : "NA";

                                        string maxMark = arrCells[10].ToString() != "" ? arrCells[10].ToString().Trim().Replace("'", "") : "NA";

                                        double obtainMark = arrCells[11].ToString() != "" ? Convert.ToDouble(Regex.Replace(arrCells[11].ToString(), "[^-?0-9\\.]+", "")) : 0;
                                        // string obtainMark = arrCells[13].ToString() != "" ? arrCells[13].ToString().Trim().Replace("'", "") : "NA";

                                        string result = arrCells[12].ToString() != "" ? arrCells[12].ToString().Trim().Replace("'", "") : "NA";

                                        double totalMarks = arrCells[13].ToString() != "" ? Convert.ToDouble(Regex.Replace(arrCells[13].ToString(), "[^-?0-9\\.]+", "")) : 0;
                                        //string totalMarks = arrCells[13].ToString() != "" ? arrCells[13].ToString().Trim().Replace("'", "") : "NA";

                                        double avgMarks = arrCells[14].ToString() != "" ? Convert.ToDouble(Regex.Replace(arrCells[14].ToString(), "[^-?0-9\\.]+", "")) : 0;
                                        //string avgMarks = arrCells[13].ToString() != "" ? arrCells[13].ToString().Trim().Replace("'", "") : "NA";

                                        string grade = arrCells[15].ToString() != "" ? arrCells[15].ToString().Trim().Replace("'", "") : "NA";
                                        //Issue Date code
                                        string issueDate = arrCells[16].ToString() != "" ? arrCells[16].ToString().Trim().Replace("'", "") : "NA";
                                        string[] arrIssueTime = issueDate.Split(' ');
                                        string[] arrIsuueDate = arrIssueTime[0].Split('/');
                                        DateTime issuedDate = Convert.ToDateTime(arrIsuueDate[0] + "/" + arrIsuueDate[1] + "/" + arrIsuueDate[2]);

                                        //Student Reg Date Code
                                        string studRegDate = arrCells[17].ToString() != "" ? arrCells[17].ToString().Trim().Replace("'", "") : "NA";
                                        string[] arrStudTime = studRegDate.Split(' ');
                                        string[] arrStudRegDate = arrStudTime[0].Split('/');
                                        DateTime StudentregDate = Convert.ToDateTime(arrStudRegDate[0] + "/" + arrStudRegDate[1] + "/" + arrStudRegDate[2]);

                                        string finalResult = arrCells[18].ToString() != "" ? arrCells[18].ToString().Trim().Replace("'", "") : "NA";

                                        double obtainfinalMarks = Math.Round(obtainMark, 2);
                                        double avgfinalMarks = Math.Round(avgMarks, 2);
                                        double totalfinalMarks = Math.Round(totalMarks, 2);

                                        //Duplications entry
                                        //if (c.IsRecordExist("Select MarkID From MarksheetData Where MarkCenterNo='" + centerNo + "' AND MarkCertNumber='" + certificateno + "' "))
                                        //{
                                        //   // ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('warning', 'Selected data is allready exist');", true);
                                        //    //return;
                                        //}

                                        int CenterNumber = 0;

                                        if (c.IsRecordExist("Select CenterID From CentersData Where CenterRegNumber='" + centerNo + "'"))
                                        {
                                            CenterNumber = Convert.ToInt32(c.GetReqData("CentersData", "CenterID", "CenterRegNumber='" + centerNo + "'"));
                                        }
                                        else
                                        {
                                            CenterNumber = 0;
                                        }

                                        //**Check Duplicate and delete old and add new recored
                                        //foreach (string crow in csvData.Split('\n'))
                                        //{
                                        if (chkMarkReplaceOldtoNew.Checked == true)
                                        {
                                            //int markID = 0;

                                            //if (studId == "39583")
                                            //{
                                            //    studId = studId;
                                            //}

                                            if (c.IsRecordExist("Select MarkID From MarksheetData Where MarkStudentID='" + studId + "' AND MarkSubjectName='" + subjectName + "' AND MarkObtain="+ obtainMark + ""))
                                            {

                                                //markID = Convert.ToInt32(c.GetReqData("MarksheetData", "MarkID", "MarkCertNumber='" + certificateno + "' AND MarkStudentID='" + studId + "' AND MarkSubjectName='" + subjectName + "'"));

                                                c.ExecuteQuery("Delete From MarksheetData Where MarkStudentID='" + studId + "' AND MarkSubjectName='" + subjectName + "' AND MarkObtain=" + obtainMark);

                                                //errMsg2 = "Data Replace Old to New Sucessfully";
                                            }
                                        }
                                        else
                                        {

                                        }
                                        //}


                                        c.ExecuteQuery("Insert into MarksheetData(MarkID, MarkCertNumber, MarkStudentName, MarkCourseName, MarkCenterName, MarkPlace, MarkCenterNo, MarkStudentID, MarkExamMonth, MarkDuration, MarkSubjectName, MarkMax, MarkObtain, MarkResult, MarkTotal, MarkAverage, MarkGrade, MarkFinalResult, MarkIssueDate, MarkStudRegDate, FK_CenterID, MarkStatus)Values(" + MaxId + ", '" + certificateno + "', '" + studentName + "', '" + courseName + "', '" + centerName + "', '" + place + "', '" + centerNo + "', '" + studId + "', '" + examDate + "', '" + duration + "', '" + subjectName + "', " + maxMark + ", " + obtainMark + ", '" + result + "', " + totalMarks + ", " + avgMarks + ", '" + grade + "', '" + finalResult + "', '" + issueDate + "', '" + studRegDate + "', " + CenterNumber + ",0)");

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
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "myScript", "TostTrigger('error', 'Error Occoured While Processing');", true);
            c.ErrorLogHandler(this.ToString(), "btnSubmit_Click", ex.Message.ToString());
            return;
        }
    }
}