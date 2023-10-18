<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="certificate-stud-list.aspx.cs" Inherits="adminpanel_certificate_stud_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        $(document).ready(function () {
            $('[id$=gvCertificate]').DataTable({
                columnDefs: [
                    { orderable: false, targets: [0, 1, 2, 3, 4, 5, 6, 7] }
                ],
                order: [[0, 'desc']]
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="pgTitle">Certificte list</h2>
	<span class="space20"></span>
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
					<asp:TemplateField HeaderText="Add Photos">
						<ItemStyle Width="5%" />
						<ItemTemplate>
							<asp:Literal ID="litAddPhotos" runat="server"></asp:Literal>
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

