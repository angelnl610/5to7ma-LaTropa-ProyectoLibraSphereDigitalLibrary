    namespace Biblioteca.Models;

    public class Empleado
    {
        public string Id { get; private set; } // uuid o dni
        public string Nombre { get; private set; }
        public int Edad { get; private set; }
        public string Correo { get; private set; }
        public string Contrasena { get; private set; } // almacenar hash
        public int NivelPermiso { get; private set; } // 1,2,3...

        public Empleado(string id, string nombre, int edad, string correo, string contrasena, int nivelPermiso)
        {
            
            Id = id;
            Nombre = nombre;
            Edad = edad;
            Correo = correo;
            Contrasena = contrasena;
            NivelPermiso = nivelPermiso;     
        }
           public void MostrarDatos()
        {
            Console.WriteLine($"ID: {Id}\nNombre: {Nombre}\nEdad: {Edad}\nCorreo: {Correo}\nNivelPermiso: {NivelPermiso}");
        }
        
        public bool ValidarEdad()
        {
            return Edad >= 18;
        }
    }
