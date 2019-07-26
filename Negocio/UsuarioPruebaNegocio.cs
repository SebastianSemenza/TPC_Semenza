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

        public void modificarUsuarioP(Test testMod,UsuarioPrueba usuMod)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("update USUARIOSPRUEBA set Nombre=@Nombre,Apellido=@Apellido,Documento=@Documento,Contraseña=@Contraseña,IDPerfil=@IDPerfil,Compañia=@Compañia where IDTest="+testMod.ID+" and IDVersionTest="+testMod.Version+" and ID="+usuMod.ID);
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Nombre", usuMod.Nombre);
                accesoDatos.Comando.Parameters.AddWithValue("@Apellido", usuMod.Apellido);
                accesoDatos.Comando.Parameters.AddWithValue("@Documento", usuMod.Documento);
                accesoDatos.Comando.Parameters.AddWithValue("@Contraseña", usuMod.Contraseña);
                accesoDatos.Comando.Parameters.AddWithValue("@IDPerfil", usuMod.Perfil.id);
                accesoDatos.Comando.Parameters.AddWithValue("@Compañia", usuMod.Compañia.ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
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

        public void eliminarUsuarioP(UsuarioPrueba usuMod)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("delete from USUARIOSPRUEBA where id= "+usuMod.ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
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

        public bool verificarEnUso (UsuarioPrueba usuMod,Test test)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            bool enUso=false;
            try
            {
                accesoDatos.setearConsulta("select * from CASOSPRUEBA where IDUsuario = " + usuMod.ID +" and IDTest= "+ test.ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while(accesoDatos.Lector.Read())
                {
                    enUso = true;
                }
                return enUso;
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

        public List<UsuarioPrueba>obtenerUsuarioVersion(Test test)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<UsuarioPrueba> listado = new List<UsuarioPrueba>();
            UsuarioPrueba usuario;
            try
            {
                accesoDatos.setearConsulta("select IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia from USUARIOSPRUEBA where IDTest="+test.ID+" and IDVersionTest="+test.Version);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while(accesoDatos.Lector.Read())
                {
                    usuario = new UsuarioPrueba();
                    usuario.Test = new Test();
                    usuario.Test.ID = accesoDatos.Lector.GetInt32(0);
                    usuario.Test.Version = accesoDatos.Lector.GetInt32(1) + 1;
                    usuario.Nombre = accesoDatos.Lector.GetString(2);
                    usuario.Apellido = accesoDatos.Lector.GetString(3);
                    usuario.Documento = accesoDatos.Lector.GetString(4);
                    usuario.Contraseña = accesoDatos.Lector.GetString(5);
                    usuario.Perfil = new Perfil();
                    usuario.Perfil.id = accesoDatos.Lector.GetInt32(6);
                    usuario.Compañia = new Compañia();
                    usuario.Compañia.ID = accesoDatos.Lector.GetInt32(7);
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

        public void pasarUsuariosVersion(List<UsuarioPrueba> listado)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                foreach(var up in listado)
                {
                    accesoDatos.setearConsulta("insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia) values ("+up.Test.ID+","+up.Test.Version+",'"+up.Nombre.ToString()+"','"+up.Apellido.ToString()+"','"+up.Documento.ToString()+"','"+up.Contraseña.ToString()+"',"+up.Perfil.id+","+up.Compañia.ID+")");
                    accesoDatos.abrirConexion();
                    accesoDatos.ejecutarConsulta();
                    accesoDatos.cerrarConexion();
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

        public bool verificarUsuarioCargado(Test test)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            bool resultado = false;
            try
            {
                accesoDatos.setearConsulta("select * from USUARIOSPRUEBA where IDTest = " + test.ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                if (accesoDatos.Lector.Read())
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
