using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class SiniestroPruebaNegocio
    {
        public List<SiniestroPrueba> listarSiniestroP(Test test)
        {
            List<SiniestroPrueba> listado = new List<SiniestroPrueba>();
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            SiniestroPrueba siniestroP;
            try
            {
                accesoDatos.setearConsulta("SELECT dp.ID,dp.IDTest,dp.IDVersionTest,dp.Dato,dp.Patente,c.Nombre,s.Nombre from DATOSPRUEBA dp inner join COMPAÑIAS c on c.ID=dp.IDCompañia inner join SISTEMAS s on s.ID=dp.IDSistema where dp.IDTest =" + test.ID.ToString() + " and dp.IDVersionTest = " + test.Version.ToString());
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    siniestroP = new SiniestroPrueba();
                    siniestroP.ID = accesoDatos.Lector.GetInt32(0);
                    siniestroP.NroSiniestro = accesoDatos.Lector.GetString(3);
                    siniestroP.Patente = accesoDatos.Lector.GetString(4);
                    siniestroP.Test = new Test();
                    siniestroP.Test.ID = accesoDatos.Lector.GetInt32(1);
                    siniestroP.Test.Estado = new EstadoTest();
                    siniestroP.Test.Estado.Version = accesoDatos.Lector.GetInt32(2);
                    siniestroP.Compañia = new Compañia();
                    siniestroP.Compañia.Nombre = accesoDatos.Lector.GetString(5);
                    siniestroP.Sistema = new Sistema();
                    siniestroP.Sistema.Nombre = accesoDatos.Lector.GetString(6);
                    listado.Add(siniestroP);
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

        public void agregarSiniestroPrueba(Test test,SiniestroPrueba SP)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("insert into DATOSPRUEBA(IDTest,IDVersionTest,Dato,Patente,IDCompañia,IDSistema) values("+test.ID.ToString()+","+test.Version.ToString()+", '"+SP.NroSiniestro.ToString()+"', '"+SP.Patente.ToString()+"',"+(Int16)SP.Compañia.ID+", "+(Int16)SP.Sistema.id+")");
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
