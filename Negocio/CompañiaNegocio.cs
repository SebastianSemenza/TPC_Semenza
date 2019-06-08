using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class CompañiaNegocio
    {
        public List<Compañia> listarCompañias()
        {
            List<Compañia> listado = new List<Compañia>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Compañia Compañia = new Compañia();
            try
            {
                accesoDatos.setearConsulta("select ID,Nombre,CP,Pais,Provincia,Localidad from COMPAÑIAS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    Compañia = new Compañia();
                    Compañia.ID = (int)accesoDatos.Lector["ID"];
                    Compañia.Nombre = accesoDatos.Lector["Nombre"].ToString();
                    Compañia.Pais = accesoDatos.Lector["Pais"].ToString();
                    Compañia.Provincia = accesoDatos.Lector["Provincia"].ToString();
                    Compañia.Localidad = accesoDatos.Lector["Localidad"].ToString();
                    Compañia.CP = (short)accesoDatos.Lector["CP"];
                    listado.Add(Compañia);
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
