<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Torneos.aspx.cs" Inherits="SlamWeb.Torneos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link type="text/css" href="Content/basic.css"rel="Stylesheet" media="screen" />
    <script type="text/javascript" src="Scripts/jquery.js"></script>
    <script type="text/javascript" src="Scripts/jquery.simplemodal.js"></script>
    <script type="text/javascript" src="Scripts/basic.js" ></script>
    <style type="text/css">
        th
        {
        	background-color:#5D7B9D;
        	color:White;
        	border-bottom-width:1px;
        	border-bottom-color:Black;
        }
        td
        {
        	border-color:Black;
        	border-style:solid;
        	border-width:1px;        	
        }
    </style>
    <script language="javascript" type="text/javascript">
        function Inscripciones() {
            MostrarInscripcion();
                    
        }
    </script>
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
        ImageUrl="~/Content/Torneos.png" />
        <br />
    Torneos</div>
    <br />
    <br />
    <div style="height:400px; width:100%">
    <div id="basic-modal">
         <table width="100%">  
        <tr style="text-align:center">
            <td>
            <center>
                <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Vertical">
                   <table>
                        <tr>
                            <th>
                                Inscripto ?
                            </th>
                            <th>
                                Organiza
                            </th>
                            <th>
                                Nombre
                            </th>
                            <th>
                                Sexo
                            </th>
                            <th>
                                Cupo
                            </th>
                            <th>
                                Inicio Torneo
                            </th>
                            <th>
                                Fin de Torneo
                            </th>
                            <th>
                                Inicio Insc.
                            </th>
                            <th>
                                Fin Insc.
                            </th>
                            <th>
                                Tipo
                            </th>
                            <th>
                                Estado
                            </th>
                        </tr>
                       <% if (Session["Torneos"] != null)
                          {
                              int j = 1;
                              %>
                           
                       <% foreach (object item in (System.Collections.Generic.List<Object>)Session["Torneos"])
                          { %>
                        <%      object[] DatosTorneo = item.ToString().Split(','); %>
                        <tr>
                            <td>
                                <a id='Link<% Response.Write(j);%>' href="javascript:__doPostBack('<% Response.Write(j);%>','')" >No</a>
                            </td>
                            <td>
                                 <% Response.Write(DatosTorneo[1].ToString()); %>
                            </td>
                            <td>
                                 <%  Response.Write(DatosTorneo[2].ToString()); %>
                            </td>
                            <td>
                                 <%  Response.Write(DatosTorneo[4].ToString()); %>
                            </td>
                            <td>
                                 <%  Response.Write(DatosTorneo[5].ToString()); %>
                            </td>
                            <td>
                                 <%  Response.Write(DatosTorneo[6].ToString()); %>
                            </td>
                            <td>
                                 <%  Response.Write(DatosTorneo[7].ToString()); %>
                            </td>
                            <td>
                                 <%  Response.Write(DatosTorneo[8].ToString()); %>
                            </td>
                               <td>
                                 <%  Response.Write(DatosTorneo[9].ToString()); %>
                            </td>
                            <td>
                                 <%  Response.Write(DatosTorneo[10].ToString()); %>
                            </td>
                            <td>
                                 <%  Response.Write(((Dominio.EstadoTorneo)Convert.ToInt32(DatosTorneo[12])).ToString()); %>
                            </td>
                        </tr>
                        <% j += 1; %>
                        <%} %>
                        <%} %>
                   </table>      
                </asp:Panel>
            </center>
            </td>
        </tr>
    </table>
    </div>
    </div>
    <div id="content-DATOS">
        <p>Formulario de Inscripcion</p>
        <table width="100%">
            <tr>
                <td style="width:50%">
                    Torneo al que se va inscribir:
                </td>
                <td>
                    <asp:TextBox ID="TxtTorneo" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    DNI Jugador 1:
                </td>
                <td>
                    <asp:TextBox ID="TxtDNI1" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    DNI Jugador 2:
                </td>
                <td>
                    <asp:TextBox ID="TxtDNI2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Nro. de Inscripción:
                </td>
                <td>
                    <asp:Label ID="LblInscripcion" runat="server" Text="---"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Fecha de Inscripción:
                </td>
                <td>
                    <asp:Label ID="LblFecha" runat="server" Text="---"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Estado:
                </td>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Activo ?" />
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