using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class EstadoTicketNegocio
    {
        public List<EstadoTicket> listarEstadosT()
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<EstadoTicket> listado = new List<EstadoTicket>();
            EstadoTicket estado;
            try
            {
                accesoDatos.setearConsulta("select ID,Descripcion from ESTADOSTICKET");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    estado = new EstadoTicket();
                    estado.ID = accesoDatos.Lector.GetInt32(0);
                    estado.Nombre = accesoDatos.Lector.GetString(1);
                    listado.Add(estado);
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
    }
}
