using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class SistemaNegocio
    {
        public List<Sistema> listarSistemas()
        {
            List<Sistema> listado = new List<Sistema>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Sistema Sistema = new Sistema();
            try
            {
                accesoDatos.setearConsulta("select ID,Nombre from SISTEMAS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    Sistema = new Sistema();
                    Sistema.id = (int)accesoDatos.Lector["ID"];
                    Sistema.Nombre = accesoDatos.Lector["Nombre"].ToString();
                    listado.Add(Sistema);
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
