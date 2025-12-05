using MySql.Data.MySqlClient;
using System.Data;

namespace Biblioteca.Data
{
    public class ConexionFactory
    {
        private readonly string _connectionString =
            "Server=localhost;Database=LibraSphereDB;User=root;Password=Pass123!;";

        public MySqlConnection CrearConexion()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
