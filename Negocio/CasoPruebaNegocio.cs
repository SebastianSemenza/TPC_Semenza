using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class CasoPruebaNegocio
    {
        public List<CasoPrueba>ListarCasosPrueba(Test test)
        {
            List<CasoPrueba> listado = new List<CasoPrueba>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            CasoPrueba casoPrueba;
            try
            {
                accesoDatos.setearConsulta("select cp.ID,cp.IDTest,cp.IDVersionTest,cp.Descripcion,cp.Resultado,cp.Observaciones,cp.DetalleFalla,up.Nombre,up.Apellido,dp.Dato,cp.Automatico from CASOSPRUEBA as cp  inner join USUARIOSPRUEBA as up on cp.IDUsuario=up.ID inner join DATOSPRUEBA as dp on cp.IDDatoPrueba=dp.ID where cp.IDTest =" + test.ID.ToString() + " and cp.IDVersionTest = " + test.Version.ToString());
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while(accesoDatos.Lector.Read())
                {
                    casoPrueba = new CasoPrueba();
                    casoPrueba.ID = accesoDatos.Lector.GetInt32(0);
                    casoPrueba.Descripcion = accesoDatos.Lector.GetString(3);
                    casoPrueba.Resultado = accesoDatos.Lector.GetBoolean(4);
                    casoPrueba.Observaciones = accesoDatos.Lector.GetString(5);
                    casoPrueba.TextoFalla = accesoDatos.Lector.GetString(6);
                    casoPrueba.Automatico = accesoDatos.Lector.GetBoolean(10);
                    casoPrueba.Usuario = new UsuarioPrueba();
                    casoPrueba.Usuario.Nombre = accesoDatos.Lector.GetString(7);
                    casoPrueba.Usuario.Apellido = accesoDatos.Lector.GetString(8);
                    casoPrueba.Siniestro = new SiniestroPrueba();
                    casoPrueba.Siniestro.NroSiniestro = accesoDatos.Lector.GetString(9);
                    casoPrueba.Test = new Test();
                    casoPrueba.Test.ID = accesoDatos.Lector.GetInt32(1);
                    casoPrueba.Test.Version = accesoDatos.Lector.GetInt32(2);
                    listado.Add(casoPrueba);
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

        public void agregarDatoPrueba(Test test,CasoPrueba caso)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("insert into CASOSPRUEBA(IDTest,IDVersionTest,Descripcion,Resultado,Observaciones,DetalleFalla,IDUsuario,IDDatoPrueba,Automatico) values ("+ test.ID.ToString() +","+test.Version.ToString()+",'"+caso.Descripcion.ToString()+"','"+caso.Resultado.ToString()+"','"+caso.Observaciones.ToString()+"','"+caso.TextoFalla.ToString()+"',"+(Int16)caso.Usuario.ID+","+(Int16)caso.Siniestro.ID+",'"+caso.Automatico.ToString()+"')");
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

        public void modificarDatoPrueba(Test test, CasoPrueba caso)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("update CASOSPRUEBA set Descripcion=@Descripcion,Resultado=@Resultado,Observaciones=@Observaciones,DetalleFalla=@DetalleFalla,IDUsuario=@IDUsuario,IDDatoPrueba=@IDDatoPrueba,Automatico=@Automatico where IDTest=" + test.ID + " and IDVersionTest=" + test.Version + " and ID=" + caso.ID);
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@Descripcion", caso.Descripcion);
                accesoDatos.Comando.Parameters.AddWithValue("@Resultado", caso.Resultado);
                accesoDatos.Comando.Parameters.AddWithValue("@Observaciones", caso.Observaciones);
                accesoDatos.Comando.Parameters.AddWithValue("@DetalleFalla", caso.TextoFalla);
                accesoDatos.Comando.Parameters.AddWithValue("@IDUsuario", caso.Usuario.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@IDDatoPrueba", caso.Siniestro.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@Automatico", caso.Automatico);
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


        public void eliminarDatoPrueba(CasoPrueba caso)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("delete from CASOSPRUEBA where ID="+caso.ID);
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

        public List<CasoPrueba> obtenerCasoVersion(Test test)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<CasoPrueba> listado = new List<CasoPrueba>();
            CasoPrueba Caso;
            ImagenCasoNegocio imagenNegocio = new ImagenCasoNegocio();
            try
            {
                accesoDatos.setearConsulta("select IDTest,IDVersionTest,Descripcion,Resultado,Observaciones,DetalleFalla,IDUsuario,IDDatoPrueba,Automatico,ID from CASOSPRUEBA where IDTest=" + test.ID + " and IDVersionTest=" + test.Version + " and Resultado=0");
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    Caso = new CasoPrueba();
                    Caso.ID = accesoDatos.Lector.GetInt32(9);
                    Caso.Test = new Test();
                    Caso.Test.ID = accesoDatos.Lector.GetInt32(0);
                    Caso.Test.Version = accesoDatos.Lector.GetInt32(1) + 1;
                    Caso.Descripcion = accesoDatos.Lector.GetString(2);
                    Caso.Resultado = accesoDatos.Lector.GetBoolean(3);
                    Caso.Observaciones = accesoDatos.Lector.GetString(4);
                    Caso.TextoFalla = accesoDatos.Lector.GetString(5);
                    Caso.Usuario = new UsuarioPrueba();
                    Caso.Usuario.ID = accesoDatos.Lector.GetInt32(6);
                    Caso.Siniestro = new SiniestroPrueba();
                    Caso.Siniestro.ID = accesoDatos.Lector.GetInt32(7);
                    Caso.Automatico = accesoDatos.Lector.GetBoolean(8);
                    //Caso.Imagenes = imagenNegocio.obtenerImagenes(Caso.ID);
                    listado.Add(Caso);
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

        public void pasarCasosVersion(List<CasoPrueba> listado)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                foreach (var caso in listado)
                {
                    accesoDatos.setearConsulta("insert into CASOSPRUEBA(IDTest,IDVersionTest,Descripcion,Resultado,Observaciones,DetalleFalla,IDUsuario,IDDatoPrueba,Automatico) values ("+caso.Test.ID+","+caso.Test.Version+",'"+caso.Descripcion.ToString()+"','"+caso.Resultado.ToString()+"','"+caso.Observaciones.ToString()+"','"+caso.TextoFalla.ToString()+"',"+caso.Usuario.ID+","+caso.Siniestro.ID+",'"+caso.Automatico.ToString()+"')");
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

    }
}
