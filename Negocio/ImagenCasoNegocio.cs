using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class ImagenCasoNegocio
    {
        SqlConnection cn;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;
        DataRow dr;
        SqlDataReader sqldr;

        public string abrirConexion()
        {
            try
            {
                cn = new SqlConnection("data source=DESKTOP-MMD2L10\\SQLExpress; initial catalog=TPC_SEMENZA; integrated security=sspi");
                cn.Open();
                return "Conectado";
            }
            catch (Exception ex)
            {
                return "No conectado: " + ex.ToString();
            }
        }

        public string insertarImagen(int IDCaso, string Descripcion, PictureBox pbImagen)
        {
            string mensaje = "Se inserto la imagen";
            try
            {
                cmd = new SqlCommand("Insert into IMAGENES_PRUEBAS(IDCaso,Imagen,Descripcion) values(@IDCaso,@Imagen,@Descripcion)", cn);
                cmd.Parameters.Add("@IDCaso", SqlDbType.Int);
                cmd.Parameters.Add("@Imagen", SqlDbType.Image);
                cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);

                cmd.Parameters["@IDCaso"].Value = IDCaso;
                cmd.Parameters["@Descripcion"].Value = Descripcion;
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                pbImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                cmd.Parameters["@Imagen"].Value = ms.GetBuffer();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                mensaje = "No se inserto la imagen: " + ex.ToString();
            }
            return mensaje;
        }

        public void verImagen(PictureBox pbFoto, int IDCaso, string Descripcion)
        {
            try
            {
                da = new SqlDataAdapter("Select Imagen from IMAGENES_PRUEBAS where IDCaso = " + IDCaso + " and Descripcion= '" + Descripcion + "'", cn);
                ds = new DataSet();
                da.Fill(ds, "IMAGENES_PRUEBAS");
                byte[] datos = new byte[0];
                dr = ds.Tables["IMAGENES_PRUEBAS"].Rows[0];
                datos = (byte[])dr["Imagen"];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(datos);
                pbFoto.Image = System.Drawing.Bitmap.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo consultar la Imagen: " + ex.ToString());
            }
        }

        public void cargarImagenes(ComboBox cbImg, int IDCaso)
        {
            try
            {
                cmd = new SqlCommand("Select Descripcion from IMAGENES_PRUEBAS where IDCaso= " + IDCaso, cn);
                sqldr = cmd.ExecuteReader();
                while (sqldr.Read())
                {
                    cbImg.Items.Add(sqldr["Descripcion"]);
                }
                sqldr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargaron las imagenes en el ComboBox: " + ex.ToString());
            }
        }

        public List<ImagenCaso> obtenerImagenes(int ID)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            List<ImagenCaso> listado = new List<ImagenCaso>();
            ImagenCaso imagen;
            try
            {
                accesoDatos.setearConsulta("select ID,descripcion,Imagen from IMAGENES_PRUEBAS where IDCaso= " + ID);
                accesoDatos.abrirConexion();
                accesoDatos.ejecutarConsulta();
                while (accesoDatos.Lector.Read())
                {
                    imagen = new ImagenCaso();
                    imagen.ID = accesoDatos.Lector.GetInt32(0);
                    imagen.Descripcion = accesoDatos.Lector.GetString(1);
                    imagen.Imagen = (byte[])accesoDatos.Lector["Imagen"];

                    //Lo siguiente no creo que sea lo mas optimo pero es lo unico que se me ocurre por ahora
                    //da = new SqlDataAdapter("Select Imagen from IMAGENES_PRUEBAS where IDCaso = " + ID, cn);
                    //ds = new DataSet();
                    //da.Fill(ds, "IMAGENES_PRUEBAS");
                    //dr = ds.Tables["IMAGENES_PRUEBAS"].Rows[con];
                    //imagen.Imagen = (byte[])dr["Imagen"];

                    listado.Add(imagen);
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

        public void pasarImagenes(List<ImagenCaso> listado, int ID)
        {
            AccesoDatosManager accesoDatos = new AccesoDatosManager();
            try
            {
                foreach (var imagen in listado)
                {
                    //accesoDatos.setearConsulta("insert into IMAGENES_PRUEBAS (descripcion,Imagen,IDCaso) values ('" + imagen.Descripcion.ToString() + "'," + imagen.Imagen.ToString() + "," + ID);
                    //accesoDatos.abrirConexion();
                    //accesoDatos.ejecutarConsulta();
                    //accesoDatos.cerrarConexion();


                    cmd = new SqlCommand("insert into IMAGENES_PRUEBAS (descripcion,Imagen,IDCaso) values (@Descripcion,@Imagen,@IDCaso)", cn);
                    cmd.Parameters.Add("@IDCaso", SqlDbType.Int);
                    cmd.Parameters.Add("@Imagen", SqlDbType.Image);
                    cmd.Parameters.Add("@Descripcion", SqlDbType.VarChar);

                    cmd.Parameters["@IDCaso"].Value = ID;
                    cmd.Parameters["@Descripcion"].Value = imagen.Descripcion;

                    //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    //pbImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    cmd.Parameters["@Imagen"].Value = imagen.Imagen;
                    cmd.ExecuteNonQuery();

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
