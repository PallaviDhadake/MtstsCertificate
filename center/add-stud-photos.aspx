<%@ Page Title="" Language="C#" MasterPageFile="~/center/MasterCenter.master" AutoEventWireup="true" CodeFile="add-stud-photos.aspx.cs" Inherits="center_add_stud_photos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        $(document).ready(function () {
            $('[id$=gvImage]').DataTable({
                columnDefs: [
					{ orderable: false, targets: [0, 1, 2] }
                ],
                order: [[0, 'desc']]
            });
        });
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="editinfo" runat="server">
        <div class="card card-primary">
            <div class="card-header">
                <h3 class="card-title">Add Student Signature And Image</h3>
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
                        <label>Student Image:*</label>
                        <asp:FileUpload ID="fuStudImage" runat="server" CssClass="form-control-file" />
                        <span class="space10"></span>
                        <%= studImge %><span class="space5"></span>
                    </div>
                    <div class="form-group col-md-6">
                        <label>Student Signature:*</label>
                        <asp:FileUpload ID="fusign" runat="server" CssClass="form-control-file" />
                        <span class="space10"></span>
                        <%= studImge %><span class="space5"></span>
                    </div>
                </div>
            </div>
        </div>
        <!-- Button controls starts -->
                <span class="space10"></span>
                <span class="space10"></span>
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Add" OnClick="btnSave_Click" />
                <%--<asp:Button ID="btnDelete" runat="server" CssClass="btn btn-outline-info" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');" onclick="btndelete_click"/>--%>
                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-outline-dark" Text="Cancel" OnClick="btnCancel_Click" />
                <div class="float_clear"></div>
        <!-- Button controls ends -->
    </div>
</asp:Content>

