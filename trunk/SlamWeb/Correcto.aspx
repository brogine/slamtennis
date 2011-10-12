<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Correcto.aspx.cs" Inherits="SlamWeb.Correcto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" language="javascript">
        var i = 0;
        var iterations = 100000;
        var interval = 10000;
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
            location.href = '../../Default.aspx';

        };



        window.onload = function() {
            TimerScript();

    }

</script>

    <div>
        <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Italic="False" 
            Font-Size="Small" ForeColor="#0000CC" style="text-align: left" 
            Text="Agurde unos segundos y sera redirigido al inicio...."></asp:Label>
        <br />
    </div>
    <p>
    </p>
    <p>
    </p>
    <p>
        &nbsp;Cambios Guardados correctamente....&nbsp;
        <img alt="" src="Content/Tips.png" style="height: 43px; width: 52px" /></p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <div>
    </div>
    </asp:Content>
