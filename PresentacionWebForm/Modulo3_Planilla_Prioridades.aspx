<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modulo3_Planilla_Prioridades.aspx.cs" Inherits="PresentacionWebForm.Modulo2_Planilla_Prioridades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderTITULO" runat="server">
    <h1>MODULO 2: PLANILLA DE PRIORIDADES</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table style="width: 100%">
        <tr>
            <td colspan="4">

                <asp:GridView ID="dgvResultadoBusqueda" runat="server" class="table table-striped" AutoGenerateColumns="false">
                    <columns>
                        <asp:BoundField HeaderText="Estado" DataField="estadoPlanilla.descripcion" />
                        <asp:BoundField HeaderText="Prioridad" DataField="PosicionPlanilla" />
                        <asp:BoundField HeaderText="Tipo Prioridad" DataField="Prioridad.TipoPrioridad" />
                        <asp:BoundField HeaderText="Ticket" DataField="Nticket" />
                        <asp:BoundField HeaderText="Asunto" DataField="Asunto" />
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                        <asp:BoundField HeaderText="Fecha de Carga" DataField="FechaCarga" />
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                        <asp:BoundField HeaderText="Sistema" DataField="Sistema.Nombre" />
                        <asp:BoundField HeaderText="Usuario" DataField="UsuarioTicket.Nombre" />
                    </columns>
                </asp:GridView>

            </td>
        </tr>
    </table>

</asp:Content>
