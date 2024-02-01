<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RptLiquidacionEstado.aspx.cs" Inherits="ORDENCOMPRA_REPORTES_RptLiquidacionEstado" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script lang="javaScript" type="text/javascript" src="../../crystalreportviewers13/js/crviewer/crv.js"></script> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
            AutoDataBind="true" />
        <br />
    </div>
    </form>
</body>
</html>
