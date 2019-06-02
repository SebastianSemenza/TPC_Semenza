<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modulo1_Tiempo_Analisis.aspx.cs" Inherits="PresentacionWebForm.Modulo1_Tiempos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderTITULO" runat="server">
    <h2>MODULO 1: TIEMPOS</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Tiempo de analisis</h3>
    <h3>Busqueda:</h3>
    
    <asp:Label ID="lblTicket" runat="server" Text="Ticket: "></asp:Label>
    <asp:TextBox ID="txtTicket" runat="server"></asp:TextBox>

    <asp:Label ID="lblFecha" runat="server" Text="Fecha: "></asp:Label>


    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>





    <asp:Table ID="Table1" runat="server"></asp:Table>
</asp:Content>
