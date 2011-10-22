<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SlamWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: center;
            width:50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 

<div style="height:600px; text-align:center">
<div style="text-align: left">
    <b>Usuario:</b>
    <asp:Label ID="LblUsuario" runat="server" Text="---"></asp:Label>
&nbsp;<b>Nombre:</b>
    <asp:Label ID="LblNombre" runat="server" Text="---"></asp:Label>
&nbsp;<b>Sexo:</b>
    <asp:Label ID="LblSexo" runat="server" Text="---"></asp:Label>
&nbsp;<b>Email:</b>
    <asp:Label ID="LblEmail" runat="server" Text="---"></asp:Label>
<br />
</div>
<center>
<table width="80%" style="height:100%">
    <tr>
        <td class="style1">
            <asp:ImageButton ID="Estadisticos" runat="server" Height="128px" 
                Width="128px" ImageUrl="~/Content/Estadisticos.png" 
                onclick="Estadisticos_Click" />
            <br />
            Datos estadisticos</td>
        <td class="style1">
            <asp:ImageButton ID="Historicos" runat="server" Height="128px" 
                Width="128px" ImageUrl="~/Content/HistorialCategoria.png" 
                onclick="Historicos_Click" />
            <br />
            Datos historicos</td>
    </tr>
    <tr>
        <td class="style1">
            <asp:ImageButton ID="Consultas" runat="server" Height="128px" 
                Width="128px" ImageUrl="~/Content/Consultas.png" 
                onclick="Consultas_Click" />
            <br />
            Consultas generales</td>
        <td class="style1">
            <asp:ImageButton ID="Torneos" runat="server" Height="128px" 
                Width="128px" ImageUrl="~/Content/Torneos.png" onclick="Torneos_Click" />
            <br />
            Torneos</td>
    </tr>
     <tr>
        <td class="style1">
            <asp:ImageButton ID="Llaves" runat="server" Height="128px" 
                Width="128px" ImageUrl="~/Content/Laves.png" onclick="Llaves_Click" />
            <br />
            Llaves de Torneos</td>
        <td class="style1">
            <asp:ImageButton ID="Mensajes" runat="server" Height="128px" 
                Width="128px" ImageUrl="~/Content/Mensajes.png" onclick="Mensajes_Click" />
            <br />
            Mensajes al administrador</td>
    </tr>
    </table>
 </center>
</div>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div style="text-align:right">
    <asp:Image ID="Image1" runat="server" Height="50px" Width="50px" />
    </div>
</asp:Content>


