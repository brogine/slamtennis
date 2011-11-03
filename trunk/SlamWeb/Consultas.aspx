<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="SlamWeb.Consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:150px; float:right; text-align: center;">
    <asp:Image ID="Image1" runat="server" Height="50px" 
        ImageUrl="~/Content/Consultas.png" Width="52px" />
        <br />
        Mis Datos</div>
    
    <div style="height:400px; width:100%">
    <div style="height:50px; text-align: center;">
        <div style="width:18%; float:left">
    <asp:Image ID="Image2" runat="server" Height="100px" Width="100px" 
            style="text-align: center" />
        </div>
    </div>
    <table width="95%">
        <tr>
            <td style="width:45%" class="style1">
                DNI:
            </td>
            <td>
                <asp:Label ID="LblDNI" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#000066" Text="---"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Nombre:
            </td>
            <td>
                <asp:Label ID="LblNombre2" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#000066" Text="---"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Apellido:
            </td>
            <td>
                <asp:Label ID="LblApellido" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#000066" Text="---"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Fecha Nacimiento:
            </td>
            <td>
                <asp:Label ID="LblFechaNac" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#000066" Text="---"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Nacionalidad:
            </td>
            <td>
                <asp:Label ID="LblNaciona" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#000066" Text="---"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Sexo:
            </td>
            <td>
                <asp:Label ID="LblSexo" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#000066" Text="---"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Edad:
            </td>
            <td>
                <asp:Label ID="LblEdad" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#000066" Text="---"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Telefono:
            </td>
            <td>
                <asp:Label ID="LblTelefono" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#000066" Text="---"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Celular:
            </td>
            <td>
                <asp:Label ID="LblCelular" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#000066" Text="---"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Email:
            </td>
            <td>
                <asp:Label ID="LblEmail" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#000066" Text="---"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Provincia:
            </td>
            <td>
                <asp:Label ID="LblProvincia" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#000066" Text="---"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Domicilio:
            </td>
            <td>
                <asp:Label ID="LblDomicilio" runat="server" Font-Bold="True" Font-Size="Medium" 
                    ForeColor="#000066" Text="---"></asp:Label>
            </td>
        </tr>
    </table>
    <div style="height:50px; text-align: center;">
        <br />
        <br />
        <a href="Default.aspx">Volver al Inicio</a>
    </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div style="text-align:right">
    </div>
</asp:Content>