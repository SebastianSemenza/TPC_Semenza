<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modulo1_FechasXTickets.aspx.cs" Inherits="PresentacionWebForm.FechasXTickets" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h4>MODULO 1: Fechas</h4>
    <h5>Busqueda:</h5>

    <table style="width: 100%">
        <tr>
            <td style="width: 10%">
                <asp:Label ID="lblTicket" runat="server" Text="Ticket: " Height="40px"></asp:Label>
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
                <asp:Label ID="lblFecha" runat="server" Text="Fecha de Carga: " Height="40px"></asp:Label>
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
                <input id="dtpDesde" runat="server" width="200" />
                <script>
                    $("#<%=dtpDesde.ClientID%>").datepicker({
                        uiLibrary: 'bootstrap4',
                        format: 'dd/mm/yyyy'
                    });
                </script>
            </td>
        </tr>

        <tr>
            <td style="width: 10%">
                <asp:Label ID="lblHasta" runat="server" Text="Hasta: "></asp:Label>
            </td>

            <td style="width: 40%">
                <input id="dtpHasta" runat="server" width="200" />
                <script>
                    $("#<%=dtpHasta.ClientID%>").datepicker({
                        uiLibrary: 'bootstrap4',
                        format: 'dd/mm/yyyy'
                    });
                </script>
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
                <asp:GridView ID="dgvResultadoBusqueda" runat="server" class="table table-striped"></asp:GridView>
            </td>
        </tr>
    </table>

</asp:Content>
