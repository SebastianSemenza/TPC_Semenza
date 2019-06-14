<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modulo2_CantidadesXTest.aspx.cs" Inherits="PresentacionWebForm.Modulo2_CantidadErroresXTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderTITULO" runat="server">
    <link href="../../bootstrap/css/styleTester.css" rel="stylesheet" type="text/css" />
    <h2>MODULO 2</h2>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Cantidad de Errores por Tests</h3>
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
                <asp:DropDownList ID="cmbSistemas" runat="server" Width="160px"></asp:DropDownList>
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
                <asp:DropDownList ID="cmbUsuarios" runat="server"  Width="160px"></asp:DropDownList>
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
                <asp:Button ID="btnBuscar" runat="server" Text="BUSCAR" class="btn btn-info" style="width:250px" OnClick="Button1_Click"/>
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
                <asp:GridView ID="dgvResultadoBusqueda" runat="server" class="table table-striped" AutoGenerateColumns="false">
                    <columns>
                        <asp:BoundField HeaderText="Test" DataField="NTicket" />
                        <asp:BoundField HeaderText="Asunto" DataField="Asunto" />
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                        <asp:BoundField HeaderText="Sistema" DataField="Sistema.Nombre" />
                        <asp:BoundField HeaderText="Finalizado" DataField="Finalizado" />
                        <asp:BoundField HeaderText="Cantidad de Errores detectados" DataField="CantErrores" />
                        <asp:BoundField HeaderText="Cantidad de Versiones" DataField="CantVersiones" />
                    </columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
