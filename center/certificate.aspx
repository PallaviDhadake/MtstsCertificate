<%@ Page Language="C#" AutoEventWireup="true" CodeFile="certificate.aspx.cs" Inherits="center_certificate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Download Mtsts Certificate</title>
    <script src="../adminpanel/js/jquery-2.2.4.min.js"></script>
   <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet" />
    <%--<link href="../adminpanel/css/iAdmin.css" rel="stylesheet" />--%>
    <style>
        .col_700{width:980px; margin:0 auto;}
        .posRelative{position:relative;}
        .txtCenter{text-align:center;}
        .semiBold{font-family: 'Open Sans', sans-serif; font-weight:600;}
        .bold{font-family: 'Open Sans', sans-serif; font-weight:700;}
        .upperCase{text-transform:uppercase;}
        .space10{height:0.8em;display:block}
        .padding{padding:0 30px;}

        /*.bgCerificate{background:url("Certificate-MTSTS.jpg") no-repeat center center; width:100%; background-size:cover; height:1000px; position:relative;}*/ 
        .bgCerificate{background:url("Certificate-MTSTS.jpg") no-repeat center center; width:100%; background-size:cover; height:1350px; position:relative;}

        .studName{position:absolute; display:block; font-size:1.4em; left:0; top:33%; width:100%;}

        .certiName{position:absolute; font-size:1.1em; display:block; left:0; top:39%; font-weight:900; width:100%;}

        .certiMarks{position:absolute; font-size:1em;  left:25%; top:44.8%;}

        /*.certDuration{position:absolute; font-size:0.8em; display:block; left:0; top:57.3%;  width:100%; background:#808080;}*/
        .certDurationMonth{position:absolute; left:40%; top:60%; width:100%; display:block;}
        .certDurationMonth span{position:absolute; font-size:0.8em; font-weight:600; left:8%; top:25%; width:100%; display:block}
        .certDurationMonth .certMonth{position:absolute; left:-4%; top:-3px; font-size:1em; font-weight:700; display:block; width:100%;}

        .certCenter{position:absolute; font-size:1.1em; display:block; left:0; top:63%; width:100%; text-align:center;}

        .certibtnclr{background:#444284;  color:#fff; text-decoration:none; padding:8px 15px; border-radius:3px; }
        .clrwhite{color:#ffff;}
        .btnDownload{background:#444284;display:block;  -moz-transition:0.5s; -o-transition:0.5s; -webkit-transition:0.5s; transition:0.5s; cursor:pointer;}
        .certibtnclr:hover{background:#6a698e;}
        .certGrade{position:absolute; font-size:1em; left:90%; top:44.8%; }

    </style>



</head>
<body>
    <span class="space10"></span>
    <div class="txtCenter">
        <form runat="server">
            <asp:Button ID="btnPdf" runat="server" Text="Download Certificate" CssClass="certibtnclr" OnClick="btnPdf_Click" />
        </form>
    </div>
    <span class="space10"></span>
    <div class="col_700">
        <div class="padding">
            <div class="posRelative">
            <div class="bgCerificate">
                <span class="studName bold txtCenter"><%--S.SIVASANKARAN--%><%=studentName %></span>
                <h2 class="upperCase bold txtCenter certiName"><%--MTSTS CERTIFIED - CERTIFICATE COURSE IN AUTOCAD ( 1 MONTH )--%><%=courseName %></h2>
                <span class="certiMarks bold"><%--95.00--%><%=marks %></span>
                <span class="certGrade bold"><%--A++--%><%=grade %></span>
                <span class="space10"></span>
                <!--<span class="certDurationMonth bold"><%--May-2021--%><%=Month %></span>-->

                <!--<h4 class="certDuration bold">(Duration <%=fromdate %> To <%=todate %>)</h4>-->
                <div class="certDurationMonth">
                    <span class="bold certMonth"><%=Month %></span>
                    <span class="">(Duration <%=fromdate %> To <%=todate %>)</span>
                </div>
                <span class="certCenter txtCenter  bold"><%--AT - ACADD CENTRE--%> <%=centerName %></span>
            </div>
        </div>
        </div>
        
    </div>
  <span class="space10"></span>
	<%= errMsg %> 
</body>
</html>
