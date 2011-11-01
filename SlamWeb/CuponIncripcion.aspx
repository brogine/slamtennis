<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuponIncripcion.aspx.cs" Inherits="SlamWeb.CuponIncripcion" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body >
    <form id="form1" runat="server">
    <div style="width:770px; height:400px">
    
        <CR:CrystalReportViewer ID="ReportViewerInscrip" runat="server" 
            AutoDataBind="True" DisplayGroupTree="False" 
            EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" Height="1130px" 
            ReportSourceID="CrystalReportSource1" Width="875px" HasCrystalLogo="False" 
            HasDrillUpButton="False" HasExportButton="False" HasGotoPageButton="False" 
            HasPageNavigationButtons="False" HasSearchButton="False" 
            HasToggleGroupTreeButton="False" HasViewList="False" 
            HasZoomFactorList="False" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="C:\Users\Maxi\Documents\Visual Studio 2008\Projects\Slam\Reportes\RptCuponInscripcion.rpt">
            </Report>
        </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>
