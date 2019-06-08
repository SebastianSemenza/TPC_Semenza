using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class PrioridadNegocio
    {
        public List<Prioridad> listarPrioridades()
        {
            List<Prioridad> listado = new List<Prioridad>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Prioridad prioridad = new Prioridad();
            try
            {
                accesoDatos.setearConsulta("select ID,Nombre from PRIORIDADES");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    prioridad = new Prioridad();
                    prioridad.ID = (int)accesoDatos.Lector["ID"];
                    prioridad.TipoPrioridad = accesoDatos.Lector["Nombre"].ToString();
                    listado.Add(prioridad);
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
