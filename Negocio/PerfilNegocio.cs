using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class PerfilNegocio
    {
        public List<Perfil> listarPerfiles()
        {
            List<Perfil> listado = new List<Perfil>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            Perfil perfil;
            try
            {
                accesoDatos.setearConsulta("select ID, Descripcion from PERFILES");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while(accesoDatos.Lector.Read())
                {
                    perfil = new Perfil();
                    perfil.id = (int)accesoDatos.Lector["ID"];
                    perfil.Nombre = accesoDatos.Lector["Descripcion"].ToString();
                    listado.Add(perfil);
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
