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
        public List<UsuarioPrueba> listarUsuariosP()
        {
            List<UsuarioPrueba> listado = new List<UsuarioPrueba>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            UsuarioPrueba usuario;
            try
            {
                accesoDatos.setearConsulta("select up.ID,up.IDTest,up.IDVersionTest,up.Nombre,up.Apellido,up.Documento,up.Contraseña,p.Descripcion as pdesc,c.Nombre,up.Grabado from USUARIOSPRUEBA up inner join PERFILES p on p.ID=up.IDPerfil inner join COMPAÑIAS c on c.ID=up.Compañia");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    usuario = new UsuarioPrueba();
                    usuario.ID = (short)accesoDatos.Lector["ID"];
                    usuario.Nombre = accesoDatos.Lector["Nombre"].ToString();
                    usuario.Apellido = accesoDatos.Lector["Apellido"].ToString();
                    usuario.Documento = accesoDatos.Lector["Documento"].ToString();
                    usuario.Contraseña = accesoDatos.Lector["Contraseña"].ToString();
                    usuario.Test = new Test();
                    usuario.Test.ID = (short)accesoDatos.Lector["IDTest"];
                    usuario.Test.Estado = new EstadoTest();
                    usuario.Test.Estado.Version = (short)accesoDatos.Lector["IDVersionTest"];
                    usuario.Perfil = new Perfil();
                    usuario.Perfil.Nombre = accesoDatos.Lector.GetString(7);
                    usuario.Compañia = new Compañia();
                    usuario.Compañia.Nombre = accesoDatos.Lector.GetString(8);
                    usuario.Grabado = (bool)accesoDatos.Lector["Grabado"];
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

        //public void AgregarUsuarioP(UsuarioPrueba UsuarioP)
        //{
        //    AccesoDatosManager accesoDatos = new AccesoDatosManager();
        //    try
        //    {
        //        accesoDatos.setearConsulta("insert into USUARIOSPRUEBA(IDTest,IDVersionTest,Nombre,Apellido,Documento,Contraseña,IDPerfil,Compañia,Grabado) values(1, 2, 'Jose', 'Sanchez', '34235654', 'cesvi123', 2, 3, 1)");
        //        accesoDatos.abrirConexion();
        //        accesoDatos.ejecutarConsulta();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        accesoDatos.cerrarConexion();
        //    }
        //}
    }
}
