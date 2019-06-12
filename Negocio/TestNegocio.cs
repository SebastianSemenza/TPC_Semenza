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
                    accesoDatos.setearConsulta("select t.ID,t.IDVersion,t.NTicket,s.Nombre,u.Nombre,u.Apellido,p.Nombre,c.Nombre,gc.Descripcion,t.Asunto,t.Descripcion,s.ID,u.ID,c.ID,gc.ID,p.ID,t.Finalizado,t.VersionFinal,t.Ultimo,t.FechaCarga,t.fechaFinalizacion from TESTS t inner join SISTEMAS s on t.IDSistema=s.ID inner join USUARIOS u on t.IDUsuario=u.ID inner join PRIORIDADES p on p.ID=t.IDPrioridad inner join COMPAÑIAS c on c.ID=t.IDCompañia inner join GRUPOSCOMPAÑIAS gc on gc.ID=t.IDGrupoCompañias");
                }
                else
                {
                    accesoDatos.setearConsulta("select t.ID,t.IDVersion,t.NTicket,s.Nombre,u.Nombre,u.Apellido,p.Nombre,c.Nombre,gc.Descripcion,t.Asunto,t.Descripcion,s.ID,u.ID,c.ID,gc.ID,p.ID,t.Finalizado,t.VersionFinal,t.Ultimo from TESTS t inner join SISTEMAS s on t.IDSistema=s.ID inner join USUARIOS u on t.IDUsuario=u.ID inner join PRIORIDADES p on p.ID=t.IDPrioridad inner join COMPAÑIAS c on c.ID=t.IDCompañia inner join GRUPOSCOMPAÑIAS gc on gc.ID=t.IDGrupoCompañias where " + sFiltro);
                }
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while(accesoDatos.Lector.Read())
                {
                    test = new Test();
                    test.ID = accesoDatos.Lector.GetInt32(0);
                    test.Version = accesoDatos.Lector.GetInt32(1);
                    test.NTicket = accesoDatos.Lector.GetInt32(2);
                    test.Asunto = accesoDatos.Lector.GetString(9);
                    test.Descripcion = accesoDatos.Lector.GetString(10);
                    test.Finalizado = accesoDatos.Lector.GetBoolean(16);
                    test.VersionFinal = accesoDatos.Lector.GetBoolean(17);
                    test.Ultimo = accesoDatos.Lector.GetBoolean(18);
                    test.FechaCarga = accesoDatos.Lector.GetDateTime(19);

                    //fecha de finalizacion acepta nullos
                    if (!Convert.IsDBNull(accesoDatos.Lector["fechaFinalizacion"]))
                        test.FechaFinalizacion = accesoDatos.Lector.GetDateTime(20);

                    test.Prioridad = new Prioridad();
                    test.Prioridad.TipoPrioridad = accesoDatos.Lector.GetString(6);
                    test.Prioridad.ID = accesoDatos.Lector.GetInt32(15);
                    test.Sistema = new Sistema();
                    test.Sistema.Nombre = accesoDatos.Lector.GetString(3);
                    test.Sistema.id = accesoDatos.Lector.GetInt32(11);
                    test.UsuarioT = new UsuarioTester();
                    test.UsuarioT.Nombre = accesoDatos.Lector.GetString(4);
                    test.UsuarioT.Apellido = accesoDatos.Lector.GetString(5);
                    test.UsuarioT.ID = accesoDatos.Lector.GetInt32(12);
                    test.CiaSolicitante = new Compañia();
                    test.CiaSolicitante.Nombre = accesoDatos.Lector.GetString(7);
                    test.CiaSolicitante.ID = accesoDatos.Lector.GetInt32(13);
                    test.GrupoCia = new GrupoCompañias();
                    test.GrupoCia.Nombre = accesoDatos.Lector.GetString(8);
                    test.GrupoCia.id = accesoDatos.Lector.GetInt32(14);
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
        

        public int agregarTest(Test test)
        {
            int ID;
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("insert into TESTS(IDVersion,NTicket,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion) output inserted.ID values(1,'" + test.NTicket.ToString() + "'," + test.Sistema.id.ToString() + "," + test.UsuarioT.ID.ToString() + "," + test.Prioridad.ID.ToString() + "," + test.CiaSolicitante.ID.ToString() + "," + test.GrupoCia.id.ToString() + ",'" + test.Asunto + "','" + test.Descripcion + "',0,0,0,1,GETDATE(),null)");
                accesoDatos.abrirConexion();
                ID=accesoDatos.ejecutarAccionReturn();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
            return ID;
        }

        public void modificarTest(Test test)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("update TESTS set NTicket=@Nticket ,IDSistema=@IDSistema ,IDUsuario=@IDUsuario ,IDPrioridad=@IDPrioridad, IDCompañia=@IDCompañia, IDGrupoCompañias=@IDGrupoCompañias, Asunto=@Asunto, Descripcion=@Descripcion where ID=" + test.ID.ToString() + " AND IDVersion=" + test.Version.ToString());
                accesoDatos.Comando.Parameters.Clear();
                accesoDatos.Comando.Parameters.AddWithValue("@NTicket", test.NTicket);
                accesoDatos.Comando.Parameters.AddWithValue("@IDSistema", test.Sistema.id);
                accesoDatos.Comando.Parameters.AddWithValue("@IDUsuario", test.UsuarioT.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@IDPrioridad", test.Prioridad.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@IDCompañia", test.CiaSolicitante.ID);
                accesoDatos.Comando.Parameters.AddWithValue("@IDGrupoCompañias", test.GrupoCia.id);
                accesoDatos.Comando.Parameters.AddWithValue("@Asunto", test.Asunto);
                accesoDatos.Comando.Parameters.AddWithValue("@Descripcion", test.Descripcion);
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

        public void agregarVersion(Test test)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("update TESTS set Ultimo=0 where ID=" + test.ID.ToString() + " AND IDVersion=" + test.Version.ToString() +" SET IDENTITY_INSERT TESTS ON insert into TESTS(ID,IDVersion,NTicket,IDSistema,IDUsuario,IDPrioridad,IDCompañia,IDGrupoCompañias,Asunto,Descripcion,Borrado,Finalizado,VersionFinal,Ultimo,FechaCarga,FechaFinalizacion) values(" + test.ID.ToString()+","+(test.Version+1).ToString()+",'" + test.NTicket.ToString() + "'," + test.Sistema.id.ToString() + "," + test.UsuarioT.ID.ToString() + "," + test.Prioridad.ID.ToString() + "," + test.CiaSolicitante.ID.ToString() + "," + test.GrupoCia.id.ToString() + ",'" + test.Asunto + "','" + test.Descripcion + "',0,0,0,1,GETDATE(),null)SET IDENTITY_INSERT TESTS OFF");
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

        public void finalizarVersion(Test test)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("update TESTS set Finalizado=1,fechaFinalizacion=GETDATE() where ID=" + test.ID.ToString() + " AND IDVersion=" + test.Version.ToString());
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

        public void generarVersionFinal(Test test)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                accesoDatos.setearConsulta("update TESTS set Finalizado=1 ,VersionFinal=1,fechaFinalizacion=GETDATE() where ID=" + test.ID.ToString() + " AND IDVersion=" + test.Version.ToString());
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
