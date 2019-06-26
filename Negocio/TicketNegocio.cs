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
        public List<Ticket>listarPlanillaPrioridades()//PLANILLA DE PRIORIDADES
        {
            List<Ticket> listado = new List<Ticket>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("select t.NTicket, t.Asunto, t.Descripcion, t.ER, t.PosicionPlanilla, u.Nombre+' '+ u.Apellido, p.Nombre, s.Nombre, ep.Descripcion, c.Descripcion ,t.FechaCarga from TICKETS as t inner join USUARIOS as u on u.ID = t.IDUsuario inner join PRIORIDADES as p on p.ID = t.IDPrioridad inner join SISTEMAS as s on s.ID = t.IDSistema inner join ESTADOSPLANILLA as ep on ep.ID = t.IDEstadoPlanilla inner join CATEGORIAS as c on c.ID = t.Categoria order by PosicionPlanilla asc");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while(accesoDatos.Lector.Read())
                {
                    Ticket ticket = new Ticket();
                    ticket.NTicket = accesoDatos.Lector.GetInt32(0);
                    ticket.Asunto = accesoDatos.Lector.GetString(1);
                    ticket.Descripcion = accesoDatos.Lector.GetString(2);
                    ticket.ER = accesoDatos.Lector.GetString(3);
                    if (!Convert.IsDBNull(accesoDatos.Lector["PosicionPlanilla"]))
                        ticket.PosicionPlanilla = accesoDatos.Lector.GetInt32(4);
                    ticket.UsuarioTicket = new UsuarioTester();
                    ticket.UsuarioTicket.Nombre = accesoDatos.Lector.GetString(5);
                    ticket.Prioridad = new Prioridad();
                    ticket.Prioridad.TipoPrioridad = accesoDatos.Lector.GetString(6);
                    ticket.Sistema = new Sistema();
                    ticket.Sistema.Nombre = accesoDatos.Lector.GetString(7);
                    ticket.estadoPlanilla = new EstadoPlanillaP();
                    ticket.estadoPlanilla.descripcion = accesoDatos.Lector.GetString(8);
                    ticket.Categoria = accesoDatos.Lector.GetString(9);
                    ticket.FechaCarga = accesoDatos.Lector.GetDateTime(10);
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
                accesoDatos.cerrarConexion();
            }
        }

        public List<Ticket> filtrarTickets(string sFiltro)//MOLUDO TIEMPOS 
        {
            List<Ticket> listado = new List<Ticket>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                if (sFiltro == "")
                {
                    accesoDatos.setearConsulta("select t.NTicket, t.Asunto, t.Descripcion, t.ER, t.PosicionPlanilla, u.Nombre, u.Apellido, p.Nombre, s.Nombre, ep.Descripcion, c.Descripcion ,t.FechaCarga from TICKETS as t inner join USUARIOS as u on u.ID = t.IDUsuario inner join PRIORIDADES as p on p.ID = t.IDPrioridad inner join SISTEMAS as s on s.ID = t.IDSistema inner join ESTADOSPLANILLA as ep on ep.ID = t.IDEstadoPlanilla inner join CATEGORIAS as c on c.ID = t.Categoria ");
                }
                else
                {
                    accesoDatos.setearConsulta("select t.NTicket, t.Asunto, t.Descripcion, t.ER, t.PosicionPlanilla, u.Nombre, u.Apellido, p.Nombre, s.Nombre, ep.Descripcion, c.Descripcion ,t.FechaCarga from TICKETS as t inner join USUARIOS as u on u.ID = t.IDUsuario inner join PRIORIDADES as p on p.ID = t.IDPrioridad inner join SISTEMAS as s on s.ID = t.IDSistema inner join ESTADOSPLANILLA as ep on ep.ID = t.IDEstadoPlanilla inner join CATEGORIAS as c on c.ID = t.Categoria where " + sFiltro);
                }
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    Ticket ticket = new Ticket();
                    ticket.NTicket = accesoDatos.Lector.GetInt32(0);
                    ticket.Asunto = accesoDatos.Lector.GetString(1);
                    ticket.Descripcion = accesoDatos.Lector.GetString(2);
                    ticket.ER = accesoDatos.Lector.GetString(3);
                    if (!Convert.IsDBNull(accesoDatos.Lector["PosicionPlanilla"]))
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
                    ticket.FechaCarga = accesoDatos.Lector.GetDateTime(11);
                    ticket.HistoricoEstados = new List<EstadoTicket>();
                    listarHistoricosEstados(ticket);
                    ticket.TiempoAnalisis = calcularTiempoAnalisis(ticket);
                    ticket.TiempoDesarrollo = calcularTiempoDesarrollo(ticket);
                    ticket.TiempoTesteo = calcularTiempoTesteo(ticket);
                    ticket.TiempoPuestaProduccion = calcularTiempoPuestaProduccion(ticket);
                    ticket.EstadoActual = buscarEstadoActual(ticket);
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
                accesoDatos.cerrarConexion();
            }
        }

        public void listarHistoricosEstados(Ticket ticket)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            ticket.HistoricoEstados = new List<EstadoTicket>();
            try
            {
                accesoDatos.setearConsulta("select IDEstado,FechaEstado from ESTADOS_X_TICKETS where IDTicket=" + ticket.NTicket.ToString());
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while(accesoDatos.Lector.Read())
                {
                    EstadoTicket estadoTicket = new EstadoTicket();
                    estadoTicket.ID = accesoDatos.Lector.GetInt32(0);
                    estadoTicket.FechaEstado = accesoDatos.Lector.GetDateTime(1);
                    ticket.HistoricoEstados.Add(estadoTicket);
                }
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


        public string calcularTiempoAnalisis(Ticket ticket)
        {
            string resultado;
            DateTime fechaEnProceso = new DateTime();
            try
            {
                foreach(var estado in ticket.HistoricoEstados)
                {
                    if(estado.ID==3)
                    {
                        fechaEnProceso = estado.FechaEstado;
                    }
                }
                if(fechaEnProceso==Convert.ToDateTime("01/01/0001 0:00:00"))
                {
                    return "N/A";
                }
                else
                {
                    TimeSpan ts = fechaEnProceso - ticket.FechaCarga;
                    resultado = Convert.ToString(ts.Days);
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string calcularTiempoDesarrollo(Ticket ticket)
        {
            string resultado;
            DateTime fechaEnProceso = new DateTime();
            DateTime fechaEnTesting = new DateTime();
            try
            {
                foreach (var estado in ticket.HistoricoEstados)
                {
                    if (estado.ID == 3)
                    {
                        fechaEnProceso = estado.FechaEstado;
                    }
                    if (estado.ID == 4)
                    {
                        fechaEnTesting = estado.FechaEstado;
                    }
                }
                if (fechaEnProceso.ToString() == "01/01/0001 0:00:00" || fechaEnTesting == Convert.ToDateTime("01/01/0001 0:00:00"))
                {
                    return "N/A";
                }
                else
                {
                    TimeSpan ts = fechaEnTesting - fechaEnProceso;
                    resultado = Convert.ToString(ts.Days);
                    return resultado;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string calcularTiempoTesteo(Ticket ticket)
        {
            string resultado;
            DateTime fechaTestingOK = new DateTime();
            DateTime fechaEnTesting = new DateTime();
            try
            {
                foreach (var estado in ticket.HistoricoEstados)
                {
                    if (estado.ID == 4)
                    {
                        fechaEnTesting = estado.FechaEstado;
                    }
                    if (estado.ID == 6)
                    {
                        fechaTestingOK = estado.FechaEstado;
                    }
                }
                if (fechaEnTesting.ToString() == "01/01/0001 0:00:00" || fechaTestingOK.ToString() == "01/01/0001 0:00:00")
                {
                    return "N/A";
                }
                else
                {
                    TimeSpan ts = fechaTestingOK - fechaEnTesting;
                    resultado = Convert.ToString(ts.Days);
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string calcularTiempoPuestaProduccion(Ticket ticket)
        {
            string resultado;
            DateTime fechaTestingOK = new DateTime();
            DateTime fehcaProduccion = new DateTime();
            try
            {
                foreach (var estado in ticket.HistoricoEstados)
                {
                    if (estado.ID == 6)
                    {
                        fechaTestingOK = estado.FechaEstado;
                    }
                    if (estado.ID == 11)
                    {
                        fehcaProduccion = estado.FechaEstado;
                    }
                }
                if (fechaTestingOK.ToString() == "01/01/0001 0:00:00" || fehcaProduccion.ToString() == "01/01/0001 0:00:00")
                {
                    return "N/A";
                }
                else
                {
                    TimeSpan ts = fehcaProduccion - fechaTestingOK;
                    resultado = Convert.ToString(ts.Days);
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TotalTiemposTickets> calcularTotales(List<Ticket> listado)
        {
            List<TotalTiemposTickets> Totales = new List<TotalTiemposTickets>();
            try
            {
                TotalTiemposTickets total = new TotalTiemposTickets();
                foreach (var tiempos in listado)
                {
                    int numero = 0;
                    if (int.TryParse(tiempos.TiempoAnalisis, out numero))
                        total.TotalAnalisis += numero;
                    if (int.TryParse(tiempos.TiempoDesarrollo, out numero))
                        total.TotalDesarrollo += numero;
                    if (int.TryParse(tiempos.TiempoTesteo, out numero))
                        total.TotalTesting += numero;
                    if (int.TryParse(tiempos.TiempoPuestaProduccion, out numero))
                        total.TotalProduccion += numero;
                }
                Totales.Add(total);
                return Totales;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public EstadoTicket buscarEstadoActual (Ticket ticket)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            EstadoTicket estado = new EstadoTicket(); ;
            try
            {
                accesoDatos.setearConsulta("select top 1 et.IDEstado,e.Descripcion,et.FechaEstado from ESTADOS_X_TICKETS as et inner join ESTADOSTICKET as e on e.ID=et.IDEstado where et.IDTicket="+ ticket.NTicket +" order by FechaEstado desc");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while(accesoDatos.Lector.Read())
                {
                    estado.ID = accesoDatos.Lector.GetInt32(0);
                    estado.Nombre = accesoDatos.Lector.GetString(1);
                    estado.FechaEstado = accesoDatos.Lector.GetDateTime(2);
                }
                return estado;
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
