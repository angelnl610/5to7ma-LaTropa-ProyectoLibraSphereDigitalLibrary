    namespace Biblioteca.Models;

    public class Empleado
    {
        public int Id { get; private set; } 
        public string DNI { get; set; }
        public string Nombre { get;  set; }
        public int Edad { get;  set; }
        public string Correo { get;  set; }
        public string Contrasena { get;  set; } // almacenar hash
        public int NivelPermiso { get;  set; } // 1,2,3...

        public Empleado() { }
        
        public Empleado(int id, string dni ,string nombre, int edad, string correo, string contrasena, int nivelPermiso)
        {
            
            Id = id ;
            DNI = dni;
            Nombre = nombre;
            Edad = edad;
            Correo = correo;
            Contrasena = contrasena;
            NivelPermiso = nivelPermiso;     
        }
           public void MostrarDatos()
        {
            Console.WriteLine($"\nDNI: {DNI}\nNombre: {Nombre}\nEdad: {Edad}\nCorreo: {Correo}\nNivelPermiso: {NivelPermiso}");
        }
        
        public bool ValidarEdad()
        {
            return Edad >= 18;
        }
    }
