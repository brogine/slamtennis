<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mensajes.aspx.cs" Inherits="SlamWeb.Mensajes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
        .style2
        {
            text-align: left;
        }
    </style>
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
    <asp:Label ID="LblEmail" runat="server" Text="---"></asp:Label>
    </div>
    <br />
    </div>
    <div style="width:150px; float:right; text-align: center;">
    <asp:Image ID="Image1" runat="server" Height="50px" 
        ImageUrl="~/Content/Mensajes.png" />
        <br />
    Mensajes al Administrador</div>
    
    <div style="height:400px; width:100%">
    <table width="100%">
        <tr>
            <td style="width:35%" class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Asunto:
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox2" runat="server" Width="227px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox2" ErrorMessage="Ingrese el asunto !"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Mensaje:
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox3" runat="server" Height="184px" TextMode="MultiLine" 
                    Width="340px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox3" ErrorMessage="Ingrese un mensaje!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="text-align: center">
                <br />
                <asp:Button ID="Button1" runat="server" Text="Enviar" Width="112px" 
                    onclick="Button1_Click" />
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div style="text-align:right">
    <asp:Image ID="Image2" runat="server" Height="50px" Width="50px" />
    </div>
</asp:Content>