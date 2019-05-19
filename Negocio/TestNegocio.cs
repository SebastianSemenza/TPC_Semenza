using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class TestNegocio
    {
        public List<Test> listarTests(string sFiltro)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<Test> listado = new List<Test>();
            Test test;
            try
            {
                if(sFiltro=="")
                {
                    accesoDatos.setearConsulta("select t.ID,t.IDVersion,t.NTicket,s.Nombre,u.Nombre,u.Apellido,p.Nombre,c.Nombre,gc.Descripcion,t.Asunto,t.Descripcion,s.ID,u.ID,c.ID,gc.ID,p.ID from TESTS t inner join SISTEMAS s on t.IDSistema=s.ID inner join USUARIOS u on t.IDUsuario=u.ID inner join PRIORIDADES p on p.ID=t.IDPrioridad inner join COMPAÑIAS c on c.ID=t.IDCompañia inner join GRUPOSCOMPAÑIAS gc on gc.ID=t.IDGrupoCompañias");
                }
                else
                {
                    accesoDatos.setearConsulta("select t.ID,t.IDVersion,t.NTicket,s.Nombre,u.Nombre,u.Apellido,p.Nombre,c.Nombre,gc.Descripcion,t.Asunto,t.Descripcion,s.ID,u.ID,c.ID,gc.ID,p.ID from TESTS t inner join SISTEMAS s on t.IDSistema=s.ID inner join USUARIOS u on t.IDUsuario=u.ID inner join PRIORIDADES p on p.ID=t.IDPrioridad inner join COMPAÑIAS c on c.ID=t.IDCompañia inner join GRUPOSCOMPAÑIAS gc on gc.ID=t.IDGrupoCompañias where " + sFiltro);
                }
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while(accesoDatos.Lector.Read())
                {
                    test = new Test();
                    test.ID = accesoDatos.Lector.GetInt16(0);
                    test.Version = accesoDatos.Lector.GetInt16(1);
                    test.NTicket = accesoDatos.Lector.GetInt16(2);
                    test.Asunto = accesoDatos.Lector.GetString(9);
                    test.Descripcion = accesoDatos.Lector.GetString(10);

                    //test.Estado = new EstadoTest();
                    //test.Estado.Version = accesoDatos.Lector.GetInt16(1);
                    //test.Ticket = new Ticket();
                    //test.Ticket.IDTicket= accesoDatos.Lector.GetInt16(2);
                    //test.Ticket.Asunto = accesoDatos.Lector.GetString(9);
                    //test.Ticket.Descripcion = accesoDatos.Lector.GetString(10);

                    test.Prioridad = new Prioridad();
                    test.Prioridad.TipoPrioridad = accesoDatos.Lector.GetString(6);
                    test.Prioridad.ID = accesoDatos.Lector.GetInt16(15);
                    test.Sistema = new Sistema();
                    test.Sistema.Nombre = accesoDatos.Lector.GetString(3);
                    test.Sistema.id = accesoDatos.Lector.GetInt16(11);
                    test.UsuarioT = new UsuarioTester();
                    test.UsuarioT.Nombre = accesoDatos.Lector.GetString(4);
                    test.UsuarioT.Apellido = accesoDatos.Lector.GetString(5);
                    test.UsuarioT.ID = accesoDatos.Lector.GetInt16(12);
                    test.CiaSolicitante = new Compañia();
                    test.CiaSolicitante.Nombre = accesoDatos.Lector.GetString(7);
                    test.CiaSolicitante.ID = accesoDatos.Lector.GetInt16(13);
                    test.GrupoCia = new GrupoCompañias();
                    test.GrupoCia.Nombre = accesoDatos.Lector.GetString(8);
                    test.GrupoCia.id = accesoDatos.Lector.GetInt16(14);
                    listado.Add(test);
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


        public void agregarTest(Test test)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("insert into TESTS(NTicket,IDVersion,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion)values('" + test.NTicket.ToString() + "'," + test.Version.ToString() + "," + test.Sistema.id.ToString() + "," + test.UsuarioT.ID.ToString() + "," + test.Prioridad.ID.ToString() + "," + test.CiaSolicitante.ID.ToString() + "," + test.GrupoCia.id.ToString() + ",'" + test.Asunto + "','" + test.Descripcion + "')");
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
