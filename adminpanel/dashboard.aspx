<%@ Page Title="" Language="C#" MasterPageFile="~/adminpanel/MasterAdmin.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="adminpanel_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 class="pgTitle">Dashboard</h2>
    <span class="space20"></span>
    <%-- Card Box --%>
    <div class="container-fluid">
        <%-- Small Boxces --%>
        <div class="row">
            
             <%-- Small Box --%>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-yellow">
                    <div class="inner">
                        <h3><%=arrCounts[3]%></h3>
                        <p>Total Centers</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>
                    </div>
                    <a href="center-master.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                </div>
            </div>

            <%-- Small Box --%>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-primary">
                    <div class="inner">
                        <h3><%=arrCounts[0]%></h3>
                        <p>Active Centers</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>
                    </div>
                    <a href="center-master.aspx?type=active" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                </div>
            </div>

            <%-- Small Box --%>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-red">
                    <div class="inner">
                        <h3><%=arrCounts[4]%></h3>
                        <p>Blocked Centers</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>
                    </div>
                    <a href="center-master.aspx?type=blocked" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                </div>
            </div>

            <%-- Small Box --%>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-teal">
                    <div class="inner">
                        <h3><%=arrCounts[5]%></h3>
                        <p>Deleted Centers</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>
                    </div>
                    <a href="center-master.aspx?type=delete" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                </div>
            </div>

             <%-- Small Box --%>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-purple">
                    <div class="inner">
                        <h3><%=arrCounts[2]%></h3>
                        <p> Total Uploaded Marksheets</p>
                    </div>
                    <div class="icon">
                        <i class="ion is-warning"></i>

                    </div>
                    <a href="marksheet-list.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i> </a>
                </div>
            </div>

              <%-- Small Box --%>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-fuchsia">
                    <div class="inner">
                        <h3><%=arrCounts[1] %></h3>
                        <p>Total Uploaded Certificates</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>
                    </div>
                    <a href="certificate-list.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                </div>
            </div>
             <%-- Small Box --%>

             <%-- Small Box --%>
            <div class="col-lg-3 col-6">
                <div class="small-box bg-gradient-green">
                    <div class="inner">
                        <h3><%=arrCounts[6] %></h3>
                        <p>Add Student's Photo/Sign</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>
                    </div>
                    <a href="certificate-stud-list.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                </div>
            </div>
             <%-- Small Box --%>

           <%-- <div class="col-lg-3 col-6">
                <div class="small-box bg-red">
                    <div class="inner">
                        <h3><%=arrCounts[2] %></h3>
                        <p>Upload Images</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-bag"></i>
                    </div>
                    <a href="upload-image.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
                </div>
            </div>--%>
        </div>
    </div>                      
</asp:Content>

