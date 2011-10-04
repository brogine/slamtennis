<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SlamWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
        .style1
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 

<div style="height:400px; text-align:center">
<table width="80%" style="height:100%; margin-left:10%">
    <tr>
        <td class="style1">
            <asp:ImageButton ID="Medicos" runat="server" Height="137px" 
                Width="194px" />
            <br />
            Profecionales</td>
        <td class="style1">
            <asp:ImageButton ID="ImageButton2" runat="server" Height="137px" 
                Width="194px" />
            <br />
            Pacientes</td>
    </tr>
    <tr>
        <td class="style1">
            <asp:ImageButton ID="Turnos" runat="server" Height="137px" 
                Width="194px" />
            <br />
            Turno Pacientes</td>
        <td class="style1">
            <asp:ImageButton ID="HorariosMed" runat="server" Height="137px" 
                Width="194px" />
            <br />
            Medicos</td>
    </tr>
    
    </table>
</div>
</asp:Content>

