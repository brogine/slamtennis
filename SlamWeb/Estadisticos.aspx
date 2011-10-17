<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estadisticos.aspx.cs" Inherits="SlamWeb.Estadisticos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            color:White;
            font-weight: bold;
            text-align:right;
        }
        .style2
        {
            text-align:center;
        }
        .style4
        {
            text-align:left;
        }
        .style3
        {
            width: 50%;
        }
    </style>
    <link type="text/css" href="Content/basic.css"rel="Stylesheet" media="screen" />
    <script type="text/javascript" src="Scripts/jquery.js"></script>
    <script type="text/javascript" src="Scripts/jquery.simplemodal.js"></script>
    <script type="text/javascript" src="Scripts/basic.js" ></script>
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
   
        <div>
                Estadisticos de Jugadores
        </div>
    </div>
    <center>
    <table width="90%">
        <tr>
            <td style="text-align: right" class="style3">
                Seleccione Club:
            </td>
            <td class="style4">
                <asp:DropDownList ID="CboClub" runat="server"
                    onselectedindexchanged="CboClub_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="style3">
                Seleccione Categoria:
            </td>
            <td class="style4">
                <asp:DropDownList ID="CboCategorias" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="CboCategorias_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    </center>
    <br />
    
      <table width="100%">  
        <tr style="text-align:center">
            <td>
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Vertical">
                   
                            <asp:GridView ID="DgvEstadisticas" runat="server" CellPadding="4" 
                                ForeColor="#333333" GridLines="None">
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                       
                </asp:Panel>
            </td>
        </tr>
    </table>
      
            
      <br />
    <div id="content" style="text-align: right">
    <div id="basic-modal" >
     <asp:Panel ID="PnlDatos" runat="server" Visible="false">
         <li><a class="DATOS" href="#">Tus datos estadisticos</a></li>
     </asp:Panel>
    </div>
    <div id="content-DATOS">
        <div class="style2">
            Tus Datos Estaditicos
            <br />
            <br />
            <p></p>
        </div>
        <table width="100%" class="style1">
            <tr style="width:25%">
                <td style="width:25%" class="style1">
                    Partidos Jugados:
                </td>
                <td style="width:25%" class="style2">
                    
                    <asp:Label ID="LblPJ" runat="server" Text="00"></asp:Label>
                </td>
                <td style="width:25%">
                    Partidos Ganados:
                </td>
                <td style="width:25%" class="style2">
                    
                    <asp:Label ID="LblPG" runat="server" Text="00"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Partidos Perdidos:
                </td>
                <td class="style2">
                    
                    <asp:Label ID="LblPP" runat="server" Text="00"></asp:Label>
                    
                </td>
                <td>
                    Torneos Jugados:
                </td>
                <td class="style2">
                    
                    <asp:Label ID="LblTJ" runat="server" Text="00"></asp:Label>
                    
                </td>
            </tr>
             <tr>
                <td class="style1">
                    Torneos Completos:
                </td>
                <td class="style2">
                    
                    <asp:Label ID="LblTC" runat="server" Text="00"></asp:Label>
                    
                </td>
                <td>
                    Puntos:
                </td>
                <td class="style2">
                    
                    <asp:Label ID="LblPUNTOS" runat="server" ForeColor="#CCCCCC" Text="00"></asp:Label>
                    
                </td>
            </tr>
        </table>
        </div>
</div>
         
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div style="text-align:right">
    <asp:Image ID="Image2" runat="server" Height="50px" Width="50px" />
    </div>
</asp:Content>

