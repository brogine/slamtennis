<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estadisticos.aspx.cs" Inherits="SlamWeb.Estadisticos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            color: #000000;
            font-weight: bold;
            text-align:right;
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
    
    <div style="width:100%">
    <table width="100%">
        <tr style="width:40%">
            <td>
                Estadisticos de Jugadores
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Seleccione Club:
            </td>
            <td>
                <asp:DropDownList ID="CboClub" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                Seleccione Categoria:
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
      <table width="100%">  
        <tr style="text-align:center">
            <td>
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="DgvEstadisticas" runat="server" 
                                AutoGenerateSelectButton="True">
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <br />
    <div style="text-align: right">
            <a href="#MisDatos">Tus datos estadisticos</a>
    </div>
    </div>
    <div id="MisDatos" style="display:none">
        <div>
            <h4>Tus Datos Estaditicos</h2>
        </div>
        <table width="100%" class="style1">
            <tr style="width:25%">
                <td style="width:25%" class="style1">
                    Partidos Jugados
                </td>
                <td style="width:25%" class="style2">
                    
                    <asp:Label ID="LblPJ" runat="server" Text="00"></asp:Label>
                </td>
                <td style="width:25%">
                    Partidos Ganados
                </td>
                <td style="width:25%" class="style2">
                    
                    <asp:Label ID="LblPG" runat="server" Text="00"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Partidos Perdidos
                </td>
                <td class="style2">
                    
                    <asp:Label ID="LblPP" runat="server" Text="00"></asp:Label>
                    
                </td>
                <td>
                    Torneos Jugados
                </td>
                <td class="style2">
                    
                    <asp:Label ID="LblTJ" runat="server" Text="00"></asp:Label>
                    
                </td>
            </tr>
             <tr>
                <td class="style1">
                    Torneos Completos
                </td>
                <td class="style2">
                    
                    <asp:Label ID="LblTC" runat="server" Text="00"></asp:Label>
                    
                </td>
                <td>
                    Puntos
                </td>
                <td class="style2">
                    
                    <asp:Label ID="LblPUNTOS" runat="server" ForeColor="#000066" Text="00"></asp:Label>
                    
                </td>
            </tr>
        </table>
</div>
</asp:Content>
