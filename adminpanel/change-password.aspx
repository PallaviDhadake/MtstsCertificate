<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="change-password.aspx.cs" Inherits="adminpanel_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <h1 class="pgTitle">Change Password</h1>
    <span class="space15"></span>
      <%--<table class="form_table">--%>
    <div class="card card-primary">
        <div class="card-header">
            <h3 class="card-title">Change Your  Password</h3>
        </div>
        <%-- form strat --%>
        <div class="card-body">
            <div class="col-sm-5">
                <div class="form-group">
                     <label for="oldPass">Old Password :*</label>
                    <asp:TextBox ID="txtOld" CssClass="form-control" Width="100%" MaxLength="30" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                  <div class="form-group">
                    <label for="newPass">New Password :*</label>
                    <asp:TextBox ID="txtNew" CssClass="form-control" Width="100%" MaxLength="30" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                 <div class="form-group">
                    <label for="confirmPass">Confirm Password :*</label>
                    <asp:TextBox ID="txtConfirm" CssClass="form-control" Width="100%" MaxLength="30" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
        </div>
        <%-- Form End --%>
    </div> 
    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-sm btn-primary" Text="Submit" OnClick="btnSubmit_Click" />
</asp:Content>

