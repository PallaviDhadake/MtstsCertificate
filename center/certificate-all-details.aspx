<%@ Page Title="" Language="C#" MasterPageFile="~/center/MasterCenter.master" AutoEventWireup="true" CodeFile="certificate-all-details.aspx.cs" Inherits="center_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <h2 class="pgTitle">Certificate All Details</h2>
    <span class="space15"></span>
      <div class="card">
          <div class="card-body">
               <div class="row">
                   <div class="">
                        <div class="card-header">
                            <h3 class="large colorLightBlue">Certificate Details</h3>
                        </div>
                        <table class="form_table">
                              <tr>
                                <td><span class="formLable bold_weight">Upload Date :</span></td>
                                <td><span class="formLable"><%= ordCertiData[0] %></span> </td>
                            </tr>
                            <tr>
                                <td><span class="formLable bold_weight">Certificate No :</span></td>
                                <td><span class="formLable"><%= ordCertiData[1] %></span> </td>
                            </tr>
                              <tr>
                                <td><span class="formLable bold_weight">Student Name:</span></td>
                                <td><span class="formLable"><%= ordCertiData[8] %></span> </td>
                            </tr>
                            <tr>
                                <td><span class="formLable bold_weight">Course Name :</span></td>
                                <td><span class="formLable"><%= ordCertiData[2] %></span> </td>
                            </tr>
                             <tr>
                                <td><span class="formLable bold_weight">Place:</span></td>
                                <td><span class="formLable"><%= ordCertiData[13] %></span> </td>
                            </tr>
                             <tr>
                                <td><span class="formLable bold_weight">Center Name:</span></td>
                                <td><span class="formLable"><%= ordCertiData[9] %></span> </td>
                            </tr>
                            <tr>
                                <td><span class="formLable bold_weight">Duration:</span></td>
                                <td><span class="formLable"><%= ordCertiData[3] %></span> </td>
                            </tr>
                            
                            <tr>
                                <td><span class="formLable bold_weight">Avg Marks:</span></td>
                                <td><span class="formLable"><%= ordCertiData[4] %></span> </td>
                            </tr>
                            <tr>
                                <td><span class="formLable bold_weight">Grade:</span></td>
                                <td><span class="formLable"><%= ordCertiData[5] %></span> </td>
                            </tr>
                            <tr>
                                <td><span class="formLable bold_weight">Exam Month:</span></td>
                                <td><span class="formLable"><%= ordCertiData[6] %></span> </td>
                            </tr>
                             <tr>
                                <td><span class="formLable bold_weight">Issue Date:</span></td>
                                <td><span class="formLable"><%= ordCertiData[7] %></span> </td>
                            </tr>
                           
                            
                              <tr>
                                <td><span class="formLable bold_weight">From Date:</span></td>
                                <td><span class="formLable"><%= ordCertiData[10] %></span> </td>
                            </tr>
                            <tr>
                                <td><span class="formLable bold_weight">To Date:</span></td>
                                <td><span class="formLable"><%= ordCertiData[11] %></span> </td>
                            </tr>
                             <tr>
                                <td><span class="formLable bold_weight">Student Registration Date:</span></td>
                                <td><span class="formLable"><%= ordCertiData[12] %></span> </td>
                            </tr>
                           
                            <tr>
                                <td><span class="formLable bold_weight">Center no:</span></td>
                                <td><span class="formLable"><%= ordCertiData[14] %></span> </td>
                            </tr>
                            <%-- <tr>
                                <td><span class="formLable bold_weight">Center no:</span></td>
                                <td><span class="formLable"><%= ordCertiData[13] %></span> </td>
                            </tr>--%>
                            </table>
                       </div>
                   </div>
              </div>
       </div>
     <a class="btn btn-sm btn-info" target="_blank" href='certificate-pdf.aspx?CertID=<%= Request.QueryString["id"] %>'>Certificate Preview</a>
    <%--<asp:Button ID="btnPreview" runat="server" CssClass="btn btn-sm btn-info" Text="Certificate Preview" OnClick="btnPreview_Click" />--%>
    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-sm btn-dark" Text="Back" OnClick="btnBack_Click" />
</asp:Content>

