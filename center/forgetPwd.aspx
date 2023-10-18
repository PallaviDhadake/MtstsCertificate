<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forgetPwd.aspx.cs" Inherits="center_forgetPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mtsts Certificate</title>
    <script src="../adminpanel/js/jquery-2.2.4.min.js"></script>
    <%--<script src="../adminpanel/js/jquery-2.2.4.min.js"></script>--%>
    <link href="../adminpanel/plugins/fontawesome-free/css/all.css" rel="stylesheet" />
    <link rel="../adminpanel/stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <link href="../adminpanel/plugins/icheck-bootstrap/icheck-bootstrap.min.css" rel="stylesheet" />
    <link href="../adminpanel/dist/css/adminlte.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700" rel="stylesheet" />

    <!-- Toast Notification files -->
    <link href="../adminpanel/css/toastr.css" rel="stylesheet" />
    <script src="../adminpanel/js/toastr.js"></script>

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
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
        <div>
            <div class="login-box">
                <div class="login-logo">
                    <img src="../adminpanel/images/customIcon/mtsts-logo.png" alt="MtstsCertificate Logo" />
                    <h3 class="titleTxt txtCenter">Mtsts Certificate
                        <br />
                    </h3>
                </div>
                <!-- /.login-logo -->
                <div class="card">
                    <div class="card-body login-card-body">
                        <p class="login-box-msg">Enter your registered Email.</p>

                        <div class="input-group mb-3">
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-envelope"></span>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <asp:Button ID="cmdRecover" runat="server" Text="Send" class="btn btn-primary btn-block" OnClick="cmdRecover_Click" />

                            </div>
                            <!-- /.col -->
                            <%=errMsg %>
                        </div>

                        <p class="mt-3 mb-1">
                            <a href="<%=rootPath %>" class="fPass" title="Admin Login">Log In</a>
                        </p>
                    </div>
                    <!-- /.login-card-body -->
                </div>
            </div>
        </div>
    </form>
    <script src="../adminpanel/plugins/jquery/jquery.min.js"></script>
    <%--<script src="plugins/jquery/jquery.min.js"></script>--%>
    <script src="../adminpanel/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="../adminpanel/dist/js/adminlte.min.js"></script>
    <script src="../adminpanel/js/jquery_notification_v.1.js" type="text/javascript"></script>
</body>
</html>
