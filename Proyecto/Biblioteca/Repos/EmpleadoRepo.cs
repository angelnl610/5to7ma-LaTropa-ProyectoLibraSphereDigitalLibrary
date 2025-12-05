using Biblioteca.Data;
using Biblioteca.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace Biblioteca.Repos
{
    public class EmpleadoRepo
    {
        private ConexionFactory _conexion = new ConexionFactory();

        public void Insertar(Empleado e)
        {
            using var conn = _conexion.CrearConexion();
            conn.Open();

            using var cmd = new MySqlCommand("SP_InsertEmpleado", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("pDNI", e.DNI);
            cmd.Parameters.AddWithValue("pNombre", e.Nombre);
            cmd.Parameters.AddWithValue("pEdad", e.Edad);
            cmd.Parameters.AddWithValue("pEmail", e.Correo);
            cmd.Parameters.AddWithValue("pContrasena", e.Contrasena);
            cmd.Parameters.AddWithValue("pNivelPermiso", e.NivelPermiso);

            cmd.ExecuteNonQuery();
        }
    }
}
