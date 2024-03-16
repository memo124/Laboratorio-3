using GestionUsuarios;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio__2
{
    internal class producto
    {
        public int codigoprod { get; set; }
        public string nombreprod { get; set; }
        public string nombreprov { get; set; }
        public double preciounit { get; set; }
        public int unidades { get; set; }

        public List<producto> Obtener()
        {
            DBConnection conn = new DBConnection(); 
            List<producto> usuarios = new List<producto>();
            string query = "select codigoprod, nombreprod, nombreprov,preciounit, unidades from producto";
            using (SqlConnection connection = conn.ObtenerConexion())
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        producto usuario = new producto();
                        usuario.codigoprod = reader.GetInt32(0);
                        usuario.nombreprod = reader.GetString(1);
                        usuario.nombreprov = reader.GetString(2);
                        usuario.preciounit = reader.GetDouble(3);
                        usuario.unidades = reader.GetInt32(4);
                        usuarios.Add(usuario);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }
            }
            return usuarios;
        }
        public producto ObtenerUsuario(int? Id)
        {

            DBConnection conn = new DBConnection();
            string query = "select codigoprod, nombreprod, nombreprov,preciounit, unidades from producto WHERE codigoprod=@id";
            using (SqlConnection connection = conn.ObtenerConexion())

            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", Id);
                try

                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    producto usuario = new producto();
                    usuario.codigoprod = reader.GetInt32(0);
                    usuario.nombreprod = reader.GetString(1);
                    usuario.nombreprov = reader.GetString(2);
                    usuario.preciounit = reader.GetDouble(3);
                    usuario.unidades = reader.GetInt32(4);
                    reader.Close();
                    connection.Close();
                    return usuario;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }

            }
        }
        public void Agregar(int codigoprod, string nombreprod, string nombreprov, double precio, int unidades)
        {

            DBConnection conn = new DBConnection();
            string query = "insert into producto(codigoprod, nombreprod, nombreprov,preciounit, unidades)values(@codigo,@prod,@prov,@precio,@uni)";

            using (SqlConnection connection = conn.ObtenerConexion())
            {

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@codigo", codigoprod);
                command.Parameters.AddWithValue("@prod", nombreprod);
                command.Parameters.AddWithValue("@prov", nombreprov);
                command.Parameters.AddWithValue("@precio", precio);
                command.Parameters.AddWithValue("@uni", unidades);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                catch (Exception ex)
                {

                    throw new Exception("Error: " + ex.Message);

                }
            }
        }

        public void Actualizar(int codigoprod, string nombreprod, string nombreprov, double precio, int unidades,int cod)
        {

            DBConnection conn = new DBConnection();
            string query = "update producto set nombreprod = @prod, nombreprov =@prov, preciounit=@precio,unidades= @uni where codigoprod =@codigo";

            using (SqlConnection connection = conn.ObtenerConexion())
            {

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@codigo", cod);
                command.Parameters.AddWithValue("@prod", nombreprod);
                command.Parameters.AddWithValue("@prov", nombreprov);
                command.Parameters.AddWithValue("@precio", precio);
                command.Parameters.AddWithValue("@uni", unidades);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);
                }

            }
        }
        public void Eliminar(int Id)
        {

            DBConnection conn = new DBConnection();
            string query = "DELETE FROM producto WHERE codigoprod=@id";

            using (SqlConnection connection = conn.ObtenerConexion())
            {

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex.Message);

                }

            }

        }

    }
}
