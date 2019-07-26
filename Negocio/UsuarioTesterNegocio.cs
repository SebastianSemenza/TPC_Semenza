using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class UsuarioTesterNegocio
    {
        public List<UsuarioTester> listarUsuariosT()
        {
            List<UsuarioTester> listado = new List<UsuarioTester>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            UsuarioTester usuario = new UsuarioTester();
            try
            {
                accesoDatos.setearConsulta("select ID,Nombre,Apellido,Documento,Contraseña,Mail from USUARIOS");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    usuario = new UsuarioTester();
                    usuario.ID = (int)accesoDatos.Lector["ID"];
                    usuario.Nombre = accesoDatos.Lector["Nombre"].ToString();
                    usuario.Apellido = accesoDatos.Lector["Apellido"].ToString();
                    usuario.Documento = accesoDatos.Lector["Documento"].ToString();
                    usuario.Contraseña = accesoDatos.Lector["Contraseña"].ToString();
                    usuario.Mail = accesoDatos.Lector["Mail"].ToString();
                    listado.Add(usuario);
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


        public bool Login(string usuario,string contraseña)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            bool resultado = false;
            try
            {
                accesoDatos.setearConsulta("select * from USUARIOS where Documento = '"+usuario+"' and Contraseña= '"+contraseña+"'");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                if(accesoDatos.Lector.Read())
                {
                    resultado = true;
                }
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
