<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="marksheet-list.aspx.cs" Inherits="adminpanel_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pgTitle">Upload Marksheet</div>
    <span class="space10"></span>

    <div class="card card-primary">
        <div class="card-header">
            <h3 class="card-title">Upload Marksheet</h3>
        </div>
        <%-- Card Body --%>
        <div class="card-body">
            <div class="colorLightBlue">
                <%--<span>Id</span>--%>
                <asp:Label ID="lblId" runat="server" Text="[New]"></asp:Label>
            </div>
            <span class="space15"></span>
            <%-- From row strat --%>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label>Upload Marksheet:*</label>
                    <asp:FileUpload ID="fuMarksheet" runat="server" CssClass="form-control-file" />
                    <span class="space10"></span>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:CheckBox ID="chkMarkReplaceOldtoNew" runat="server" CssClass="" />
                    <label>Replace Old Data With New:*</label>
                    <span class="space10"></span>
                </div>
            </div>
            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" />
            <%=errMsg2 %>
        </div>
        </div>
</asp:Content>

