<%@ Page Title="" Language="C#" MasterPageFile="~/center/MasterCenter.master" AutoEventWireup="true" CodeFile="marksheet-all-details.aspx.cs" Inherits="center_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2 class="pgTitle">Marksheet All Details</h2>
    <span class="space15"></span>
    <div class="card">
        <div class="card-body">
            <div class="row">
                <div class="">
                    <div class="card-header">
                        <h3 class="large colorLightBlue">Marksheet Details</h3>
                    </div>
                    <table class="form_table">
                        <tr>
                            <td><span class="formLable bold_weight">Certificate No :</span></td>
                            <td><span class="formLable"><%= ordMarkData[0] %></span> </td>
                        </tr>
                        <tr>
                            <td><span class="formLable bold_weight">Student Id:</span></td>
                            <td><span class="formLable"><%= ordMarkData[6] %></span> </td>
                        </tr>
                        <tr>
                            <td><span class="formLable bold_weight">Student Name:</span></td>
                            <td><span class="formLable"><%= ordMarkData[1] %></span> </td>
                        </tr>
                        <tr>
                            <td><span class="formLable bold_weight">Course Name :</span></td>
                            <td><span class="formLable"><%= ordMarkData[2] %></span> </td>
                        </tr>
                        <%-- <tr>
                                <td><span class="formLable bold_weight">Subject Name:</span></td>
                                <td><span class="formLable"><%= ordMarkData[9] %></span> </td>
                            </tr>--%>
                        <tr>
                            <td><span class="formLable bold_weight">Center Name:</span></td>
                            <td><span class="formLable"><%= ordMarkData[3] %></span> </td>
                        </tr>
                        <tr>
                            <td><span class="formLable bold_weight">Place:</span></td>
                            <td><span class="formLable"><%= ordMarkData[4] %></span> </td>
                        </tr>
                        <tr>
                            <td><span class="formLable bold_weight">Center no:</span></td>
                            <td><span class="formLable"><%= ordMarkData[5] %></span> </td>
                        </tr>
                        
                        <tr>
                            <td><span class="formLable bold_weight">Duration:</span></td>
                            <td><span class="formLable"><%= ordMarkData[8] %></span> </td>
                        </tr>
                        <tr>
                    </table>
                </div>
            </div>

            <div class="">
                <div class="">
                    <div class="card-header">
                        <h3 class="large colorLightBlue">Mark Overview</h3>
                    </div>
                    <span class="space20"></span>
                    <asp:GridView ID="gvMarksheet" runat="server" CssClass="table table-striped table-bordered table-hover" GridLines="None"
                        AutoGenerateColumns="false">
                        <HeaderStyle CssClass="thead-dark" />
                        <RowStyle CssClass="" />
                        <AlternatingRowStyle CssClass="alt" />
                        <Columns>
                            <asp:BoundField DataField="MarkStudentID">
                                <HeaderStyle CssClass="HideCol" />
                                <ItemStyle CssClass="HideCol" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MarkSubjectName" HeaderText="Subject Name">
                                <ItemStyle Width="30%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MarkMax" HeaderText="Max Marks">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MarkObtain" HeaderText="Obtain Marks">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MarkAverage" HeaderText="Average Marks">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MarkTotal" HeaderText="Total Marks">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MarkGrade" HeaderText="Grade">
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MarkResult" HeaderText="Result">
                                <ItemStyle Width="8%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MarkFinalResult" HeaderText="Final Result">
                                <ItemStyle Width="8%" />
                            </asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>
                            <span class="warning">Its Empty Here... :(</span>
                        </EmptyDataTemplate>
                        <PagerStyle CssClass="" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <a class="btn btn-sm btn-info" target="_blank" href='mtstsMarksheet.aspx?MarkStudentID=<%= Request.QueryString["id"] %>'>Marksheet Preview</a>
    <%--<asp:Button ID="btnPreview" runat="server" CssClass="btn btn-sm btn-info" Text="Preview Marksheet" OnClick="btnPreview_Click" />--%>
    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-sm btn-dark" Text="Back" OnClick="btnBack_Click" />
</asp:Content>

