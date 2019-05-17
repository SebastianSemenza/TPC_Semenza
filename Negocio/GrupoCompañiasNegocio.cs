using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class GrupoCompañiasNegocio
    {
        public List<GrupoCompañias> listarGrupoCompañias()
        {
            List<GrupoCompañias> listado = new List<GrupoCompañias>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            GrupoCompañias grupoCompañias = new GrupoCompañias();
            try
            {
                accesoDatos.setearConsulta("select ID,Descripcion from GRUPOSCOMPAÑIAS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while(accesoDatos.Lector.Read())
                {
                    grupoCompañias = new GrupoCompañias();
                    grupoCompañias.id = (short)accesoDatos.Lector["ID"];
                    grupoCompañias.Nombre = accesoDatos.Lector["Descripcion"].ToString();
                    listado.Add(grupoCompañias);
                }
                return listado;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}
