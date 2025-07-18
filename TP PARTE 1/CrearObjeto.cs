namespace LibraSphere;

public class CrearObjeto
{
    public static Editorial CrearEditorial()
    {
        try
        {
            Console.WriteLine("\n=== Ingrese los datos de la editorial ===");
            Console.WriteLine("----");
            string nombre = ConversionParse.Cadena("Ingrese el nombre de la editorial");
            string paisOrigen = ConversionParse.Cadena("Ingrese el país de origen");
            int anioFundacion = ConversionParse.Entero("Ingrese el año de fundación (YYYY)");
            string sitioWeb = ConversionParse.Cadena("Ingrese el sitio web (https://www.ejemplo.com)");
            Console.WriteLine("----");
            return new Editorial(nombre, paisOrigen, anioFundacion, sitioWeb);
        }
        catch (LibraSphereException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public static Libro CrearLibro(Editorial editorial)
    {
        try
        {
            Console.WriteLine("\n=== Ingrese los datos del libro ===");
            Console.WriteLine("----");
            long isbn = ConversionParse.Long("Ingrese el ISBN del libro (13 dígitos)");
            string titulo = ConversionParse.Cadena("Ingrese el título del libro");
            string autor = ConversionParse.Cadena("Ingrese el autor del libro");
            Console.WriteLine("Ingrese el género literario (Fantasia, CienciaFiccion, Drama, Romance, Misterio, Otro)");
            string generoInput = ConversionParse.Cadena("Género: ");
            if (!Enum.TryParse<GeneroLiterario>(generoInput, true, out GeneroLiterario genero))
            {
                throw new LibraSphereException("Género literario no válido.");
            }
            int anioPublicacion = ConversionParse.Entero("Ingrese el año de publicación (YYYY)");
            int cantPaginas = ConversionParse.Entero("Ingrese la cantidad de páginas");
            string idioma = ConversionParse.Cadena("Ingrese el idioma del libro");
            Console.WriteLine("----");
            return new Libro(isbn, titulo, autor, genero, anioPublicacion, cantPaginas, idioma, editorial);
        }
        catch (LibraSphereException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public static Usuario CrearUsuario()
    {
        try
        {
            Console.WriteLine("\n=== Ingrese los datos del usuario ===");
            Console.WriteLine("----");
            string nombreCompleto = ConversionParse.Cadena("Ingrese su nombre completo");
            string correoElectronico = ConversionParse.Cadena("Ingrese su correo electrónico (ejemplo.ejem@gmail.com)");
            string fechaNacimiento = ConversionParse.Cadena("Ingrese su fecha de nacimiento (YYYY-MM-DD)");
            string numeroDocumento = ConversionParse.Cadena("Ingrese su número de documento (8 dígitos)");
            string direccion = ConversionParse.Cadena("Ingrese su dirección (10 dígitos)");
            string contrasena = ConversionParse.Cadena("Ingrese su contraseña");
            Console.WriteLine("Ingrese el tipo de membresía (Gratuita, Premium)");
            string membresiaInput = ConversionParse.Cadena("Membresía: ");
            if (!Enum.TryParse<TipoMembresia>(membresiaInput, true, out TipoMembresia membresia))
            {
                throw new LibraSphereException("Tipo de membresía no válido.");
            }
            Console.WriteLine("----");
            return new Usuario(nombreCompleto, correoElectronico, fechaNacimiento, numeroDocumento, direccion, contrasena, membresia);
        }
        catch (LibraSphereException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public static Prestamo CrearPrestamo(Libro libro, Usuario usuario)
    {
        try
        {
            Console.WriteLine("\n=== Ingrese los datos del préstamo ===");
            Console.WriteLine("----");
            if (!libro.GetDisponible()) throw new LibraSphereException("El libro no está disponible.");
            string fechaDevolucion = ConversionParse.Cadena("Ingrese la fecha de devolución (YYYY-MM-DD)");
            Console.WriteLine("----");
            return new Prestamo(libro, fechaDevolucion, usuario);
        }
        catch (LibraSphereException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public static void ActualizarEstadoPrestamo(Prestamo prestamo)
    {
        try
        {
            Console.WriteLine("\n=== Actualizar estado del préstamo ===");
            Console.WriteLine("----");
            Console.WriteLine("Opciones de estado: Activo, Devuelto, Vencido");
            string estadoInput = ConversionParse.Cadena("Ingrese el estado del préstamo: ");
            if (!Enum.TryParse<Prestamo.EstadoPrestamo>(estadoInput, true, out Prestamo.EstadoPrestamo estado))
            {
                throw new LibraSphereException("Estado de préstamo no válido. Use Activo, Devuelto o Vencido.");
            }
            string subEstado = null;
            if (estado == Prestamo.EstadoPrestamo.Vencido)
            {
                Console.WriteLine("Opciones de subestado: VencidoDevuelto, VencidoSinDevolver");
                subEstado = ConversionParse.Cadena("Ingrese el subestado: ");
                if (subEstado != "VencidoDevuelto" && subEstado != "VencidoSinDevolver")
                {
                    throw new LibraSphereException("Subestado no válido. Use VencidoDevuelto o VencidoSinDevolver.");
                }
            }
            prestamo.SetEstado(estadoInput, subEstado);
            Console.WriteLine("Estado actualizado correctamente.");
            Console.WriteLine("----");
        }
        catch (LibraSphereException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}