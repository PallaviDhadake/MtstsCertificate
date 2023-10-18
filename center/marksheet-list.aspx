<%@ Page Title="Marksheet List | MtstsCertificate" Language="C#" MasterPageFile="~/center/MasterCenter.master" AutoEventWireup="true" CodeFile="marksheet-list.aspx.cs" Inherits="center_marksheet_list" %>

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
                $('#<%= gvMarksheet.ClientID %>').prepend($("<thead></thead>").append($('#<%= gvMarksheet.ClientID %>').find("tr:first"))).DataTable({

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
    <h2 class="pgTitle">Marksheet List</h2>
    <span class="space20"></span>
    <div id="viewinfo" runat="server">
		<span class="space20"></span>
		<div class="formPanel table-responsive-md">
			<asp:GridView ID="gvMarksheet" runat="server" CssClass="table table-striped table-bordered table-hover" GridLines="None" 
				AutoGenerateColumns="false" OnRowDataBound="gvMarksheet_RowDataBound">
				 <HeaderStyle CssClass="thead-dark" />
				<RowStyle CssClass="" />
				<AlternatingRowStyle CssClass="alt" />
				<Columns>
					 <asp:BoundField DataField="MarkStudentID">
						<HeaderStyle CssClass="HideCol" />
						<ItemStyle  CssClass="HideCol"/>
					</asp:BoundField>
					<asp:BoundField DataField="MarkStudentID" HeaderText="Student Id">
						<ItemStyle Width="5%" />
					</asp:BoundField>
					<asp:BoundField DataField="MarkStudentName" HeaderText="Student Name">
						<ItemStyle Width="20%" />
					</asp:BoundField>
					<asp:BoundField DataField="MarkCourseName" HeaderText="Course Name">
						<ItemStyle Width="35%" />
					</asp:BoundField>
					<asp:BoundField DataField="MarkPlace" HeaderText="Place">
						<ItemStyle Width="10%" />
					</asp:BoundField>
					<asp:BoundField DataField="MarkDuration" HeaderText="Duration">
						<ItemStyle Width="5%" />
					</asp:BoundField>
					<asp:TemplateField HeaderText="Count">
						<ItemStyle Width="5%" />
						<ItemTemplate>
							<asp:Literal ID="litCount" runat="server"></asp:Literal>
						</ItemTemplate>
					</asp:TemplateField>  
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

