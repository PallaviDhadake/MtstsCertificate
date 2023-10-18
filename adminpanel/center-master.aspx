<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="center-master.aspx.cs" Inherits="adminpanel_Default2" %>
<%@ MasterType VirtualPath="~/adminpanel/MasterAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        $(document).ready(function () {
            $('[id$=gvCenters]').DataTable({
                columnDefs: [
                    { orderable: false, targets: [0, 1, 2, 3, 4, 5, 6, 7, 8] }
                ],
                order: [[0, 'desc']]
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="pgTitle">Center Master</h2>
	<span class="space10"></span>
    <div id="editCenter" runat="server">
		<div class="card card-primary">
			<div class="card-header">
				<h3 class="card-title"><%=pgTitle %></h3>
			</div>
			<%-- Card Body --%>
			<div class="card-body">
				<div class="colorLightBlue">
					<%--<span>Id</span>--%>
					<asp:Label ID="lblId" runat="server" Text="[New]"></asp:Label>
				</div>
				<span class="space15"></span>
				<%-- From Row Start --%>
				<div class="form-row">
					<%--<div class="form-group col-md-6">

						<label>Date:*</label>
						<asp:TextBox ID="txtDate" runat="server" CssClass="form-control" Width="100%" MaxLength="20"></asp:TextBox>
					</div>--%>
					
					<div class="form-group col-md-6">

						<label>Center Reg.No:*</label>
						<asp:TextBox ID="txtCenRegNo" runat="server" CssClass="form-control" Width="100%" MaxLength="20"></asp:TextBox>
					</div>

					<div class="form-group col-md-6">
						<label>Center Name:*</label>
						<asp:TextBox ID="txtCenterNm" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="200" ></asp:TextBox>
					</div>
					<div class="form-group col-md-6">
						<label>Name:*</label>
						<asp:TextBox ID="txtName" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="50" ></asp:TextBox>
					</div>
					<div class="form-group col-md-6">
						<label>Contact No:*</label>
						<asp:TextBox ID="txtContact" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="10" ></asp:TextBox>
					</div>
					<div class="form-group col-md-6">
						<label>Email:*</label>
						<asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Width="100%" 
							MaxLength="50" ></asp:TextBox>
					</div>
					<div class="form-group col-md-6">
						<label>Center Address:*</label>
						<asp:TextBox ID="txtCenAdd" runat="server" CssClass="form-control textarea" Width="100%"  MaxLength="300"></asp:TextBox>
					</div>
					<div class="form-group col-md-6">
						<label>Center Password:*</label>
						<asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" Width="100%"   MaxLength="15"></asp:TextBox>
					</div>
					<div class="form-group col-md-6">
						<label>Place:*</label>
						<asp:TextBox ID="txtPlace" runat="server" CssClass="form-control" Width="100%"   MaxLength="50"></asp:TextBox>
					</div>
					
					<div class="form-group col-md-6">
						<label>Signature:</label>
						<asp:FileUpload ID="fuImage" runat="server" CssClass="form-control-file" />
						<span class="space10"></span>
						<%= signPhoto %><span class="space5"></span>
						<asp:Button ID="btnRemove" runat="server" CssClass="btn btn-secondary" Text="Remove Photo"  OnClientClick="return confirm('Are you sure to remove photo?');" OnClick="btnRemove_Click" />
					</div>
					<div class="form-check col-md-6">
						<span class="space30"></span>
						<div>
							<asp:CheckBox ID="chkbxrapid" runat="server" TextAlign="Right" />
							<label class="form-check-label"><strong>Rapid Entery</strong> </label>
						</div>
					</div>
				</div>
			</div>
		</div>
		<!-- Button controls starts -->
		<span class="space10"></span>
		<span class="space10"></span>
		<asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
		<asp:Button ID="btnDelete" runat="server" CssClass="btn btn-outline-info" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');" OnClick="btnDelete_Click" />
		<asp:Button ID="btnBlock" runat="server" CssClass="btn btn-info" Text="Block" OnClick="btnBlock_Click"/>
		<asp:Button ID="btnCancel" runat="server" CssClass="btn btn-outline-dark" Text="Cancel" OnClick="btnCancel_Click" />
		<div class="float_clear"></div>
		
		<!-- Button controls ends -->
		<%--</ContentTemplate>
		</asp:UpdatePanel>--%>
	</div>
	<div id="viewcenter" runat="server">
		<a href="center-master.aspx?action=new" runat="server" id="addNew" class="btn btn-primary btn-md">Add New</a>
		<%--<a href="contactdata.aspx?action=new" runat="server" class="btn btn-primary btn-md">Add New</a>--%>
		<span class="space20"></span>
		<div class="formPanel table-responsive-md">
			<asp:GridView ID="gvCenters" runat="server" CssClass="table table-striped table-bordered table-hover" GridLines="None" 
				AutoGenerateColumns="false" OnRowDataBound="gvCenters_RowDataBound">
				 <HeaderStyle CssClass="thead-dark" />
				<RowStyle CssClass="" />
				<AlternatingRowStyle CssClass="alt" />
				<Columns>
					 <asp:BoundField DataField="CenterID">
						<HeaderStyle CssClass="HideCol" />
						<ItemStyle  CssClass="HideCol"/>
					</asp:BoundField>
					
					 <asp:BoundField DataField="CenterRegDate" HeaderText="Date">
						<ItemStyle Width="5%" />
					</asp:BoundField>

					 <asp:BoundField DataField="CenterName" HeaderText="Center Name">
						<ItemStyle Width="15%" />
					</asp:BoundField>

					 <asp:BoundField DataField="CenterPerson" HeaderText="Name">
						<ItemStyle Width="10%" />
					</asp:BoundField>

					<asp:BoundField DataField="CenterContactNo" HeaderText="Contact No">
						<ItemStyle Width="5%" />
					</asp:BoundField>

					<asp:BoundField DataField="CenterEmail" HeaderText="Email">
						<ItemStyle Width="10%" />
					</asp:BoundField>

					<asp:BoundField DataField="CenterPlace" HeaderText="Place">
						<ItemStyle Width="5%" />
					</asp:BoundField>

					<asp:TemplateField HeaderText="Status">
						<ItemStyle Width="5%"/>
						<ItemTemplate>
							<asp:Literal ID="litStatus" runat="server"></asp:Literal>
						</ItemTemplate>
					</asp:TemplateField>   

					<asp:TemplateField>
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

