<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sesion.aspx.cs" Inherits="SlamWeb.Sesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" language="javascript">
    function Redirigir() {
        location.href = '../../SlamWeb/Login.aspx';
    }

    window.onload = function() {
        setTimeout("Redirigir()", 5000);
    }

</script>

    <div>
        <br />
    </div>
    <div style="height:300px">
    <br />
    <br />
    <center>
        <img alt="" src="Content/SesionCerrada.png" style="height: 43px; width: 52px" />
        <p>Sesión cerrada correctamente.</p>
    </center>
    </div>
  
    </asp:Content>
