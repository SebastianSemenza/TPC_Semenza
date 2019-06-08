<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modulo1_FechasXTickets.aspx.cs" Inherits="PresentacionWebForm.FechasXTickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderTITULO" runat="server">
    <link href="../../bootstrap/css/styleTester.css" rel="stylesheet" type="text/css" />
    <h2>MODULO 1</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <h3>Tiempos</h3>
    <h4>Busqueda:</h4>

    <table style="width: 100%">
        <tr>
            <td style="width: 10%">
                <asp:Label ID="lblTicket" runat="server" Text="Ticket: "></asp:Label>
            </td>
            <td style="width: 40%">
                <asp:TextBox ID="txbTicket" runat="server"></asp:TextBox>
            </td>
            <td style="width: 10%">
                <asp:Label ID="lblSistema" runat="server" Text="Sistema: "></asp:Label>
            </td>
            <td style="width: 40%">
                <asp:TextBox ID="txbSistema" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Label ID="lblFecha" runat="server" Text="Fecha de Carga: "></asp:Label>
            </td>

            <td style="width: 10%">
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label>
            </td>
            <td style="width: 40%">
                <asp:TextBox ID="txbUsuario" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="width: 10%">
                <asp:Label ID="lblDesde" runat="server" Text="Desde: "></asp:Label>
            </td>

            <td style="width: 40%">
                <asp:TextBox ID="txbDesde" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td style="width: 10%">
                <asp:Label ID="lblHasta" runat="server" Text="Hasta: "></asp:Label>
            </td>

            <td style="width: 40%">
                <asp:TextBox ID="txbHasta" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td colspan="2"></td>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="BUSCAR" class="btn btn-info" style="width:250px" OnClick="Button1_Click"/>
            </td>
        </tr>

        <tr>
            <td colspan="4">
                <p></p>
            </td>
        </tr>
                <tr>
            <td colspan="4">
                <p></p>
            </td>
        </tr>
                <tr>
            <td colspan="4">
                <p></p>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="dgvResultadoBusqueda" runat="server" class="table table-striped"></asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>
