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
                accesoDatos.setearConsulta("select cp.ID,cp.IDTest,cp.IDVersionTest,cp.Descripcion,cp.Resultado,cp.Observaciones,cp.DetalleFalla,up.Nombre,up.Apellido,dp.Dato,cp.Automatico from CASOSPRUEBA as cp  inner join USUARIOSPRUEBA as up on cp.IDUsuario=up.ID inner join DATOSPRUEBA as dp on cp.IDDatoPrueba=dp.ID where up.IDTest =" + test.ID.ToString() + " and up.IDVersionTest = " + test.Version.ToString());
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

    }
}
