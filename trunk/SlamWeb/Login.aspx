<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SlamWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height:400px">
    <div id="Login">
   
        <br />
        <br />
        <br />
        <table width="100%">
            <tr>
                <td class="style1">
                    Usuario:
                </td>
                <td>
                    <asp:TextBox ID="TxtUsuario" runat="server" Width="165px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Clave:
                </td>
                <td>
                    <asp:TextBox ID="TxtClave" TextMode="Password"  runat="server" Width="165px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="BtnIniciar" runat="server" Text="Iniciar Sesion" 
                        onclick="BtnIniciar_Click" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="LblError" runat="server" Text="Label" ForeColor="Red" 
                        Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
   
    </div>
    </div>
</asp:Content>
