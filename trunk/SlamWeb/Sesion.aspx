<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sesion.aspx.cs" Inherits="SlamWeb.Sesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" language="javascript">
        var i = 0;
        var iterations = 100000;
        var interval = 2000;
        function TimerScript()
        {
	        if(i<iterations)
	        {
		        setTimeout("Redirigir();",interval);
	            i++;
	        };
	        else
	        {
	            i=0;
	        };
	    };
	    function Redirigir()        {   
            location.href = '../../Login.aspx';

        };



        window.onload = function() {
            TimerScript();

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
