<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Correcto.aspx.cs" Inherits="SlamWeb.Correcto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" language="javascript">
    function Redirigir() {
        location.href = '../../SlamWeb/Default.aspx';
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
            <p>Cambios Guardados correctamente....
            <img alt="" src="Content/Tips.png" style="height: 43px; width: 52px" />
            </p>
    </center>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Italic="False" 
            Font-Size="Small" ForeColor="#0000CC" style="text-align: left" 
            Text="Agurde unos segundos y sera redirigido al inicio...."></asp:Label>
    </div>    
    </asp:Content>
