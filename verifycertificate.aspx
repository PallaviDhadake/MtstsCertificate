<%@ Page Language="C#" AutoEventWireup="true" CodeFile="verifycertificate.aspx.cs" Inherits="verifycertificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mtsts Certificate Client Login</title>
    <script src="adminpanel/js/jquery-2.2.4.min.js"></script>
    <script src="adminpanel/js/jquery.plugin.js"></script>
    <script src="adminpanel/js/jquery_notification_v.1.js"></script>
    <link rel="stylesheet" href="adminpanel/plugins/fontawesome-free/css/all.min.css" />
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <link rel="stylesheet" href="adminpanel/plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
    <link rel="stylesheet" href="adminpanel/dist/css/adminlte.min.css" />

    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet" />

    <!-- Toast Notification files -->
    <link href="adminpanel/css/toastr.css" rel="stylesheet" />
    <script src="adminpanel/js/toastr.js"></script>

    <script type="text/javascript">
        function TostTrigger(EventName, MsgText) {
            // code to be executed
            Command: toastr[EventName](MsgText)
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-top-full-width",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "slideDown",
                "hideMethod": "fadeOut"
            }
        }
    </script>
    <style>
        .col_1140 { width: 1140px; margin: 0 auto; }
        .pgTitle {color: #333;  font-size: 1.5em; line-height: 1.5;}
        .space40 {height: 2.5em; display: block;}
        .space15 { height: 0.9em; display: block;}
        .space20 {height: 1.2em; display: block; }
        .txtCenter {text-align: center;}
         table { font-family: arial, sans-serif; border-collapse: collapse; width:100%;}
         td, th {border: 1px solid #dddddd; text-align: left;  padding: 8px;}
         tr:nth-child(even) { background-color: #dddddd;}
    </style>
</head>
<body>
    <div class="col_1140">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <div class="space15"></div>
            <div class="txtCenter">
                <img src="adminpanel/images/customIcon/certi-mtsts-logo.jpg" alt="MtstsCertificate Logo" />
            </div>
            <span class="space15"></span>
            
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title"><%=pgTitle %></h3>
                </div>
                <div class="card-body">
                    <span class="space15"></span>
                    <%-- From Row Start --%>
                    <div class="form-row">
                        <div class="form-group col-md-6">

                            <label>Certificate Number:*</label>
                            <asp:TextBox ID="txtcertificateNo" runat="server" CssClass="form-control" Width="100%" MaxLength="20"></asp:TextBox>
                            <span class="space15"></span>
                            <asp:Button ID="btnverify" runat="server" CssClass="btn btn-primary" Text="Verify" OnClick="btnverify_Click" />
                        </div>

                    </div>
                </div>
                <div id="table" runat="server">       
                    <table>
                        <tr>
                            <th>Certificate No</th>
                            <th>Student Name</th>
                            <th>Course Name</th>
                            <th>Center Name</th>
                        </tr>
                        <tr>
                            <td><%= ordCertData[0] %></td>
                            <td><%= ordCertData[1] %></td>
                            <td><%= ordCertData[2] %></td>
                            <td><%= ordCertData[3] %></td>
                        </tr>
                        <%--<tr>
                        <td>ordCertData[1]</td>
                        <td>Francisco Chang</td>
                        <td>Mexico</td>
                        <td>Pallavi Dhadake</td>
                    </tr>
                    <tr>
                        <td>ordCertData[2]</td>
                        <td>Roland Mendel</td>
                        <td>Austria</td>
                        <td>Pallavi Dhadake</td>
                    </tr>
                    <tr>
                        <td>ordCertData[3]</td>
                        <td>Helen Bennett</td>
                        <td>UK</td>
                        <td>Pallavi Dhadake</td>
                    </tr>
                    <tr>
                        <td>Laughing  </td>
                        <td>Yoshi Tannamuri</td>
                        <td>Canada</td>
                        <td>Pallavi Dhadake</td>
                    </tr>
                    <tr>
                        <td>Magazzini  </td>
                        <td>Giovanni Rovelli</td>
                        <td>Italy</td>
                        <td>Pallavi Dhadake</td>
                    </tr>--%>
                    </table>
                </div>
                </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </form>
    </div>
</body>
</html>
