using System.Data.SqlClient;

namespace GestionUsuarios
{
    public class DBConnection
    {
        private string ConnectionString = "Data Source = LAPTOP-O8SAEK9T;Initial Catalog=laboratorio3;User=sa;Password=sa;Integrated Security=false;MultipleActiveResultSets=true; TrustServerCertificate=True;";
        public SqlConnection ObtenerConexion()
        {
            SqlConnection conection = new SqlConnection(ConnectionString);
            return conection;
        }

    }
}
