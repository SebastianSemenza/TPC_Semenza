using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class UsuarioPruebaNegocio
    {
        public List<UsuarioPrueba> listarUsuariosP(Test test)
        {
            List<UsuarioPrueba> listado = new List<UsuarioPrueba>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            UsuarioPrueba usuario;
            try
            {
                accesoDatos.setearConsulta("select up.ID,up.IDTest,up.IDVersionTest,up.Nombre,up.Apellido,up.Documento,up.Contraseña,p.Descripcion as pdesc,c.Nombre from USUARIOSPRUEBA up inner join PERFILES p on p.ID=up.IDPerfil inner join COMPAÑIAS c on c.ID=up.Compañia where up.IDTest ="+test.ID.ToString()+" and up.IDVersionTest = "+test.Version.ToString());
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    usuario = new UsuarioPrueba();
                    usuario.ID = (int)accesoDatos.Lector["ID"];
                    usuario.Nombre = accesoDatos.Lector["Nombre"].ToString();
                    usuario.Apellido = accesoDatos.Lector["Apellido"].ToString();
                    usuario.Documento = accesoDatos.Lector["Documento"].ToString();
                    usuario.Contraseña = accesoDatos.Lector["Contraseña"].ToString();
                    usuario.Test = new Test();
                    usuario.Test.ID = (int)accesoDatos.Lector["IDTest"];
                    usuario.Test.Estado = new EstadoTest();
                    usuario.Test.Estado.Version = (int)accesoDatos.Lector["IDVersionTest"];
                    usuario.Perfil = new Perfil();
                    usuario.Perfil.Nombre = accesoDatos.Lector.GetString(7);
                    usuario.Compañia = new Compañia();
                    usuario.Compañia.Nombre = accesoDatos.Lector.GetString(8);
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

        public void agregarUsuarioP(Test testMod,UsuarioPrueba usuMod)
        {
            AccesoDatosManager accesodatos = new AccesoDatosManager();
            try
            {
                accesodatos.setearConsulta("insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia) values("+testMod.ID.ToString() + "," + testMod.Version.ToString() + ",'"+usuMod.Nombre.ToString() +"','"+usuMod.Apellido.ToString()+"','"+ usuMod.Documento.ToString() +"','"+ usuMod.Contraseña.ToString() +"',"+ (Int16)usuMod.Perfil.id +","+(Int16)usuMod.Compañia.ID+")");
                accesodatos.abrirConexion();
                accesodatos.ejecutarConsulta();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesodatos.cerrarConexion();
            }
        }
    }
}
