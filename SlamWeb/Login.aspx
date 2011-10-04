<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SlamWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height:400px">
    <div id="Login">
   
        <br />
        <br />
        <br />
        <asp:Login ID="Login1" runat="server" Height="223px" 
            LoginButtonText="Iniciar Sesión" onauthenticate="Login1_Authenticate" 
            PasswordLabelText="Clave" PasswordRequiredErrorMessage="Ingrese la Clave..." 
            RememberMeText="Recordar la proxima vez" TitleText="Ingreso a usuarios registrados" 
            UserNameLabelText="Usuario:" 
            UserNameRequiredErrorMessage="Ingrese el nombre de Usuario..." 
            Width="389px">
        </asp:Login>
   
    </div>
    </div>
</asp:Content>
