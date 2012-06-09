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
        .fila
        {
        	border-color:Black;
        	border-style:solid;
        	border-width:1px;        	
        }
    </style>
    <script language="javascript" type="text/javascript">
        function Inscripciones(idtorneo,torneo,tipo) {
            document.getElementById("ctl00_MainContent_TxtTorneo").value = torneo;            
            document.getElementById("ctl00_MainContent_LinkButton1").href = "javascript:__doPostBack('Torneo=" + idtorneo + "','')";
            if (tipo == "Doble") {
                document.getElementById("Jugador2").style.display = '';
            }
            else {
                document.getElementById("Jugador2").style.display = 'none';
            }
            MostrarInscripcion();
        }

        function BorrarInscripcion(idtorneo, torneo) {

            document.getElementById("ctl00_MainContent_LinkSi").href = "javascript:__doPostBack('Borrar=true," + idtorneo + "','')";
            document.getElementById("ctl00_MainContent_LinkNo").href = "javascript:__doPostBack('Borrar=false,0','')";
            MostrarBorrarInscripcion();
        }

        function ImprimirReporte() {
            var resp = confirm('Inscripcion agregada correctamente, ¿ Desea generar el comprobante ?');
            if (resp == true) {
                window.location = "javascript:__doPostBack('Imprimir=true','')";
            }
            else {
                window.location = "javascript:__doPostBack('Imprimir=false','')";
            }
        }

        function openpopup() {
            window.open('../../CuponIncripcion.aspx', '', 'location=no, menubar=no, scrollbars=no, status=no, toolbar=no, resizable=no, height=420, width=800');
        }
        function Mensaje() {
            MostrarMensaje();
        }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: left; width:500px">
    <b>Usuario:</b>
    <asp:Label ID="LblUsuario" runat="server" Text="---"></asp:Label>
&nbsp;<b>Nombre:</b>
    <asp:Label ID="LblNombre" runat="server" Text="---"></asp:Label>
    <div style="display:none">
&nbsp;<b>Sexo:</b>
    <asp:Label ID="LblSexo" runat="server" Text="---"></asp:Label>
&nbsp;<b>Email:</b>
    <asp:Label ID="LblEmail" runat="server" Text="---"></asp:Label></div>
    <br />
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
                              int j = 0;
                              %>
                           
                       <% foreach (object item in (System.Collections.Generic.List<Object>)Session["Torneos"])
                          { %>
                        <%      object[] DatosTorneo = item.ToString().Split(',');
                                if (DatosTorneo[11] == "Cerrado" || DatosTorneo[11] == "Abierto")
                                {
                                    if (DateTime.Now >= Convert.ToDateTime(DatosTorneo[8]) && DateTime.Now <= Convert.ToDateTime(DatosTorneo[9]))
                                    {%>
                        <tr>
                            <td class="fila">
                                <% Servicio.IInscripcionServicio incripcion = new Servicio.InscripcionServicio(); %>
                                <% if (incripcion.Existe(Convert.ToInt32(DatosTorneo[0]), Convert.ToInt32(Session["DNI"])))
                                   {  %>
                                    <% Response.Write("Si");%>
                                    <br />
                                    <a onclick="javascript:BorrarInscripcion('<% Response.Write(DatosTorneo[0].ToString()); %>','<% Response.Write(DatosTorneo[2].ToString()); %>')" href="#" >Borrar ?</a>
                                    <%                                      
                            }  %>
                                <% else
                            { %>   
                                <a onclick="javascript:Inscripciones('<% Response.Write(DatosTorneo[0].ToString()); %>','<% Response.Write(DatosTorneo[2].ToString()); %>','<% Response.Write(DatosTorneo[10].ToString()); %>')" href="#" >No</a>
                                <%} %>
                            </td>
                            <td class="fila">
                                 <% Response.Write(DatosTorneo[1].ToString()); %>
                            </td>
                            <td class="fila">
                                 <%  Response.Write(DatosTorneo[2].ToString()); %>
                            </td>
                            <td class="fila">
                                 <%  Response.Write(DatosTorneo[4].ToString()); %>
                            </td>
                            <td class="fila">
                                 <%  Response.Write(DatosTorneo[5].ToString()); %>
                            </td>
                            <td class="fila">
                                 <%  Response.Write(DatosTorneo[6].ToString()); %>
                            </td >
                            <td class="fila">
                                 <%  Response.Write(DatosTorneo[7].ToString()); %>
                            </td>
                            <td class="fila">
                                 <%  Response.Write(DatosTorneo[8].ToString()); %>
                            </td>
                               <td class="fila">
                                 <%  Response.Write(DatosTorneo[9].ToString()); %>
                            </td>
                            <td class="fila">
                                 <%  Response.Write(DatosTorneo[10].ToString()); %>
                            </td>
                            <td class="fila">
                                 <%  Response.Write(((Dominio.EstadoTorneo)Convert.ToInt32(DatosTorneo[12])).ToString()); %>
                            </td>
                        </tr>
                        <%}
                                } j += 1; %>
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
            <tr style="display:none">
                <td style="width:50%; text-align: right;">
                    ID Torneo:
                </td>
                <td>
                    <asp:TextBox ID="TxtIDTorneo"  runat="server" Enabled="False"></asp:TextBox>
            </td>
            </tr>
            <tr>
                <td style="width:50%; text-align: right;">
                    Torneo al que se va inscribir:
                </td>
                <td>
                    <asp:TextBox ID="TxtTorneo" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:50%; text-align: right;">
                    DNI Jugador 1:
                </td>
                <td>
                    <asp:TextBox ID="TxtDNI1" runat="server" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr id="Jugador2">
                <td style="width:50%; text-align: right;">
                    DNI Jugador 2:
                </td>
                <td>
                    <asp:TextBox ID="TxtDNI2" Enabled="true" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:50%; text-align: right;">
                    Nro. de Inscripción:
                </td>
                <td>
                    <asp:Label ID="LblInscripcion" runat="server" Text="---"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:50%; text-align: right;">
                    Fecha de Inscripción:
                </td>
                <td>
                    <asp:Label ID="LblFecha" runat="server" Text="---"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>                    
                </td>
                <td>                    
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" >Inscribirse</asp:LinkButton>   
                </td>
            </tr>
        </table>
    </div>    
    
     <div id="BorrarIncrip">
        <p>Bajas de Inscripciones</p>
        <br />
        <div style="text-align:center">
            <img  src="Content/Crystal_Clear_app_error.png" width="50px" height="50px" />
            &nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="White" 
                Text="¿ Esta seguro de dar de baja la insripcion al torneo ?"></asp:Label>
            
         </div>
         <div style="height:50px" ></div>
         <div style="width:48%; float:left; text-align:right">
            <asp:LinkButton ID="LinkSi" runat="server" Font-Size="Large" 
                 Font-Names="Calibri">Si</asp:LinkButton>
         </div>
         <div style="width:48%; float:right; text-align:left">
            <asp:LinkButton ID="LinkNo" runat="server" Font-Size="Large" 
                 Font-Names="Calibri">No</asp:LinkButton>
         </div>
         
    </div>   
    
     <div id="Mensaje" style="height:200px;width:500px">
        <p>Bajas de Inscripciones</p>
        <div style="height:50px" ></div>
        <div style="text-align:center">
            <img  src="Content/Tips.png"/>
            &nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Font-Size="Medium" ForeColor="White" 
                Text="Se ha borrado la inscripcion con exito..."></asp:Label>
            
         </div>
      </div>   
    
    <div>
        
    </div>       
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder1">
    <div style="text-align:right">
    <asp:Image ID="Image2" runat="server" Height="50px" Width="50px" />
    </div>
    
</asp:Content>