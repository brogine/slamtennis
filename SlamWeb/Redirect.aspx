<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Redirect.aspx.cs" Inherits="SlamWeb.Redirect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" language="javascript">


    function Redirigir() {
        location.href = '../../Default.aspx';
    }

    window.onload = function() {
        setTimeout("Redirigir()", 5000);
    }

</script>
    <div style="height:300px">
    <br />
    <br />
    <br />
    <center>
            <p>No se encontraron torneos cargados...&nbsp;
            <img alt="" src="Content/Alert_32x32-32.png" />
            </p>
    </center>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Italic="False" 
            Font-Size="Small" ForeColor="#0000CC" style="text-align: left" 
            Text="Agurde unos segundos y sera redirigido al inicio...."></asp:Label>
    </div>    
    </asp:Content>

