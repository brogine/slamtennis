<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Llaves.aspx.cs" Inherits="SlamWeb.Llaves" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: left; width:500px">
    <b>Usuario:</b>
    <asp:Label ID="LblUsuario" runat="server" Text="---"></asp:Label>
&nbsp;<b>&nbsp;&nbsp; Nombre:</b>
    <asp:Label ID="LblNombre" runat="server" Text="---"></asp:Label>
    <div style="display:none">
&nbsp;<b>Sexo:</b>
    <asp:Label ID="LblSexo" runat="server" Text="---"></asp:Label>
&nbsp;<b>Email:</b>
    <asp:Label ID="LblEmail" runat="server" Text="---"></asp:Label></div>
    </div>
    <br />
    <div style="width:150px; float:right; text-align: center;">
    <asp:Image ID="Image1" runat="server" Height="50px" 
        ImageUrl="~/Content/Laves.png" />
        <br />
    Llaves</div>
    
    <div style="height:1230px; width:100%">
    <center>
        <div>
            Seleccione Torneo:<asp:DropDownList ID="CboTorneos" runat="server" 
                AutoPostBack="True" onselectedindexchanged="CboTorneos_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </center>
    <br />
    <br />
    <center>
        <CR:CrystalReportViewer ID="ReportViewerLlave" runat="server" 
            AutoDataBind="True" Height="1130px" ReportSourceID="CrystalReportSource1" 
            Width="875px" Visible="False" EnableDatabaseLogonPrompt="False" 
            EnableParameterPrompt="False" HasCrystalLogo="False" 
            ReuseParameterValuesOnRefresh="True" HasDrillUpButton="False" 
            HasGotoPageButton="False" HasSearchButton="False" HasViewList="False"             
            ToolbarImagesFolderUrl="/SlamWeb/Content/" 
            DisplayGroupTree="False" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="C:\Users\Maxi\Documents\Visual Studio 2008\Projects\Slam\Reportes\RptLlave.rpt">
            </Report>
        </CR:CrystalReportSource>
    </center>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div style="text-align:right">
    <asp:Image ID="Image2" runat="server" Height="50px" Width="50px" />
    </div>
</asp:Content>