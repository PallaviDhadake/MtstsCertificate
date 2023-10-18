<%@ Page Title="" Language="C#" MasterPageFile="~/center/MasterCenter.master" AutoEventWireup="true" CodeFile="marksheet-list.old.aspx.cs" Inherits="center_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script>
         $(document).ready(function () {
             $('[id$=gvMarksheet]').DataTable({
                 columnDefs: [
                     { orderable: false, targets: [0, 1, 2, 3, 4, 5, 6, 7, 8] }
                 ],
                 order: [[0, 'desc']]
             });
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
						<ItemStyle Width="30%" />
					</asp:BoundField>
					<asp:BoundField DataField="MarkCourseName" HeaderText="Course Name">
						<ItemStyle Width="25%" />
					</asp:BoundField>
					<asp:BoundField DataField="MarkPlace" HeaderText="Place">
						<ItemStyle Width="15%" />
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
	<%--<div id="Div1" runat="server">
		<span class="space20"></span>
		<div class="formPanel table-responsive-md">
			
			<asp:GridView ID="gvMarksheet" runat="server" CssClass="table table-striped table-bordered table-hover" GridLines="None" 
				AutoGenerateColumns="false" >
				 <HeaderStyle CssClass="thead-dark" />
				<RowStyle CssClass="" />
				<AlternatingRowStyle CssClass="alt" />
				<Columns>
					 <asp:BoundField DataField="MarkID">
						<HeaderStyle CssClass="HideCol" />
						<ItemStyle  CssClass="HideCol"/>
					</asp:BoundField>
					<asp:BoundField DataField="MarkStudentID" HeaderText="Certificate No">
						<ItemStyle Width="5%" />
					</asp:BoundField>
					<asp:BoundField DataField="MarkStudentName" HeaderText="Course Name">
						<ItemStyle Width="32%" />
					</asp:BoundField>
					<asp:BoundField DataField="MarkCourseName" HeaderText="Student Name">
						<ItemStyle Width="15%" />
					</asp:BoundField>
					<asp:BoundField DataField="MarkPlace" HeaderText="Place">
						<ItemStyle Width="10%" />
					</asp:BoundField>
					<asp:BoundField DataField="MarkDuration" HeaderText="Duration">
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
	</div>--%>
</asp:Content>

