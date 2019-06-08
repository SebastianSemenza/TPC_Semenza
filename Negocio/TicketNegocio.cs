using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class TicketNegocio
    {
        public List<Ticket>listarTickets()
        {
            List<Ticket> listado = new List<Ticket>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("select t.NTicket, t.Asunto, t.Descripcion, t.ER, t.PosicionPlanilla, u.Nombre, u.Apellido, p.Nombre, s.Nombre, ep.Descripcion, c.Descripcion from TICKETS as t inner join USUARIOS as u on u.ID = t.IDUsuario inner join PRIORIDADES as p on p.ID = t.IDPrioridad inner join SISTEMAS as s on s.ID = t.IDSistema inner join ESTADOSPLANILLA as ep on ep.ID = t.IDEstadoPlanilla inner join CATEGORIAS as c on c.ID = t.Categoria ");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while(accesoDatos.Lector.Read())
                {
                    Ticket ticket = new Ticket();
                    ticket.NTicket = accesoDatos.Lector.GetInt32(0);
                    ticket.Asunto = accesoDatos.Lector.GetString(1);
                    ticket.Descripcion = accesoDatos.Lector.GetString(2);
                    ticket.ER = accesoDatos.Lector.GetString(3);
                    ticket.PosicionPlanilla = accesoDatos.Lector.GetInt32(4);
                    ticket.UsuarioTicket = new UsuarioTester();
                    ticket.UsuarioTicket.Nombre = accesoDatos.Lector.GetString(5);
                    ticket.UsuarioTicket.Apellido = accesoDatos.Lector.GetString(6);
                    ticket.Prioridad = new Prioridad();
                    ticket.Prioridad.TipoPrioridad = accesoDatos.Lector.GetString(7);
                    ticket.Sistema = new Sistema();
                    ticket.Sistema.Nombre = accesoDatos.Lector.GetString(8);
                    ticket.estadoPlanilla = new EstadoPlanillaP();
                    ticket.estadoPlanilla.descripcion = accesoDatos.Lector.GetString(9);
                    ticket.Categoria = accesoDatos.Lector.GetString(10);
                    listado.Add(ticket);
                }
                return listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public int calcularTiempoAnalisis(Ticket ticket)
        {
            int resultado;
            DateTime fechaEnProceso;
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("select FechaEstado from ESTADOS_X_TICKETS where IDTicket =" + ticket.NTicket.ToString() + "and IDEstado = 3");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                fechaEnProceso = accesoDatos.Lector.GetDateTime(0);
                TimeSpan ts = ticket.FechaCarga - fechaEnProceso;
                resultado = ts.Days;
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
