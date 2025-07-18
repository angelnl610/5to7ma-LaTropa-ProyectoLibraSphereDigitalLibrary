using LibraSphere;

try
{
    SistemaBiblioteca sistema = new SistemaBiblioteca();
    
    Editorial editorial1 = CrearObjeto.CrearEditorial();
    Libro libro1 = CrearObjeto.CrearLibro(editorial1);
    Usuario usuario1 = CrearObjeto.CrearUsuario();
    Prestamo prestamo1 = CrearObjeto.CrearPrestamo(libro1, usuario1);

    sistema.AgregarLibro(libro1);
    sistema.AgregarPrestamo(prestamo1);

    // Mostrar datos iniciales
    Console.WriteLine("\n=== Datos iniciales ===");
    editorial1.MostrarDatos();
    libro1.MostrarDatos();
    usuario1.MostrarDatosUsuario();
    prestamo1.MostrarDatos();

    CrearObjeto.ActualizarEstadoPrestamo(prestamo1);

    Console.WriteLine("\n=== Datos después de actualizar el estado ===");
    prestamo1.MostrarDatos();
}
catch (LibraSphereException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}