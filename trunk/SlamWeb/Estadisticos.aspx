<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estadisticos.aspx.cs" Inherits="SlamWeb.Estadisticos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div style="text-align: left; width:500px">
    <b>Usuario:</b>
    <asp:Label ID="LblUsuario" runat="server" Text="---"></asp:Label>
&nbsp;<b>Nombre:</b>
    <asp:Label ID="LblNombre" runat="server" Text="---"></asp:Label>
&nbsp;<b>Sexo:</b>
    <asp:Label ID="LblSexo" runat="server" Text="---"></asp:Label>
&nbsp;<b>Email:</b>
    <asp:Label ID="LblEmail" runat="server" Text="---"></asp:Label>
    </div>
    <div style="width:150px; float:right; text-align: center;">
    <asp:Image ID="Image1" runat="server" Height="50px" 
        ImageUrl="~/Content/Estadisticos.png" />
        <br />
    Datos Estadisticos</div>
    
    <div style="height:500px; width:100%">
    <table width="100%">
        <tr>
            <td>
            Tus Datos Estadisticos
            </td>
        </tr>
        <tr style="text-align:center">
            <td>
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical">
                    <asp:GridView ID="DgvEstadisticas" runat="server" 
                AutoGenerateSelectButton="True">
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
            Estadistico Categoria
            <br />
            </td>
        </tr>
        <tr style="text-align:center">
            <td>
                <asp:Panel ID="Panel2" runat="server" Height="200px" ScrollBars="Vertical">
                    <asp:GridView ID="DgvEstadisticasCategoria" runat="server" 
                AutoGenerateSelectButton="True">
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
