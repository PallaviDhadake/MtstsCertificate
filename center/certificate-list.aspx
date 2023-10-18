<%@ Page Title="Certificate List | MtstsCertificate" Language="C#" MasterPageFile="~/center/MasterCenter.master" AutoEventWireup="true" CodeFile="certificate-list.aspx.cs" Inherits="center_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
         $(function () {
             var prm = Sys.WebForms.PageRequestManager.getInstance();
             if (prm != null) {
                 prm.add_endRequest(function (sender, e) {
                     if (sender._postBackSettings.panelsToUpdate != null) {
                         createDataTable();
                     }
                 });
             };

             createDataTable();
             function createDataTable() {
                 $('#<%= gvCertificate.ClientID %>').prepend($("<thead></thead>").append($('#<%= gvCertificate.ClientID %>').find("tr:first"))).DataTable({

                    columnDefs: [
                        { orderable: false, targets: [0, 1, 2, 3, 4, 5, 6, 7] }
                    ],
                    order: [[0, 'desc']]
                });

            }
        });
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="pgTitle">Certificate List</h2>
	<span class="space20"></span>
    <%-- Gridview to save data strat here --%>
	<div id="viewinfo" runat="server">
		<span class="space20"></span>
		<div class="formPanel table-responsive-md">
			
			<asp:GridView ID="gvCertificate" runat="server" CssClass="table table-striped table-bordered table-hover" GridLines="None" 
				AutoGenerateColumns="false" OnRowDataBound="gvCertificate_RowDataBound">
				 <HeaderStyle CssClass="thead-dark" />
				<RowStyle CssClass="" />
				<AlternatingRowStyle CssClass="alt" />
				<Columns>
					 <asp:BoundField DataField="CertID">
						<HeaderStyle CssClass="HideCol" />
						<ItemStyle  CssClass="HideCol"/>
					</asp:BoundField>
					<asp:BoundField DataField="CertNumber" HeaderText="Certificate No">
						<ItemStyle Width="5%" />
					</asp:BoundField>
					<asp:BoundField DataField="CertStudentName" HeaderText="Student Name">
						<ItemStyle Width="25%" />
					</asp:BoundField>
					<asp:BoundField DataField="CertCourseName" HeaderText="Course Name">
						<ItemStyle Width="32%" />
					</asp:BoundField>
					<asp:BoundField DataField="CertPlace" HeaderText="Place">
						<ItemStyle Width="10%" />
					</asp:BoundField>
					<asp:BoundField DataField="CertDuration" HeaderText="Duration">
						<ItemStyle Width="5%" />
					</asp:BoundField>
					<asp:BoundField DataField="CertGrade" HeaderText="Grade">
						<ItemStyle Width="5%" />
					</asp:BoundField>
					<asp:TemplateField HeaderText="Views">
						<ItemStyle Width="5%" />
						<ItemTemplate>
							<asp:Literal ID="litAnch" runat="server"></asp:Literal>
						</ItemTemplate>
					</asp:TemplateField>   
				</Columns>
				<EmptyDataTemplate>
					<span class="warning">Its Empty Here... :(</span>
				</EmptyDataTemplate>
				<PagerStyle CssClass="" />
			</asp:GridView>
		</div>
	</div>
</asp:Content>

