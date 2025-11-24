namespace DigitalLibrary;

public static class CrearObjeto
{
    public static Editorial CrearEditorial()
    {
        try
        {
            Console.WriteLine("\n=== Ingresar datos de la editorial ===");
            Console.WriteLine("----");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("País de origen: ");
            string paisOrigen = Console.ReadLine();
            Console.Write("Año de fundación: ");
            int anioFundacion = int.Parse(Console.ReadLine());
            Console.Write("Sitio web (https://ejemplo.com): ");
            string sitioWeb = Console.ReadLine();
            Console.WriteLine("----");
            return new Editorial(nombre, paisOrigen, anioFundacion, sitioWeb);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public static MaterialDigital CrearMaterial()
    {
        try
        {
            Console.WriteLine("\n=== Ingresar datos del material ===");
            Console.WriteLine("----");
            Console.Write("Tipo de material (Libro/Audiolibro/Revista/LibroInteractivo): ");
            string tipo = Console.ReadLine().ToLower();
            Console.Write("ID (ISBN)(13 números): ");
            string id = Console.ReadLine();
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Fecha de publicación (YYYY-MM-DD): ");
            string fecha = Console.ReadLine();
            DateOnly fechaPublicacion = Validaciones.FechaValida(fecha);

            MaterialDigital material = tipo switch
            {
                "libro" => CrearLibro(id, titulo, autor, fechaPublicacion),
                "audiolibro" => CrearAudiolibro(id, titulo, autor, fechaPublicacion),
                "revista" => CrearRevista(id, titulo, autor, fechaPublicacion),
                "librointeractivo" => CrearLibroInteractivo(id, titulo, autor, fechaPublicacion),
                _ => throw new ArgumentException("Tipo de material no válido.")
            };
            Console.WriteLine("----");
            return material;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    private static Libro CrearLibro(string id, string titulo, string autor, DateOnly fechaPublicacion)
    {
        Console.Write("Género (Fantasia, CienciaFiccion, Drama, Romance, Misterio, Otro): ");
        string generoInput = Console.ReadLine();
        GeneroLiterario genero = Validaciones.ValidarGenero(generoInput, "Género no válido.");
        Console.Write("Cantidad de páginas: ");
        int cantPaginas = int.Parse(Console.ReadLine());
        Console.Write("Idioma: ");
        string idioma = Console.ReadLine();
        Editorial editorial = CrearEditorial();
        return new Libro(id, titulo, autor, fechaPublicacion, genero, cantPaginas, idioma, editorial);
    }

    private static Audiolibro CrearAudiolibro(string id, string titulo, string autor, DateOnly fechaPublicacion)
    {
        Console.Write("Narrador: ");
        string narrador = Console.ReadLine();
        Console.Write("Duración en minutos: ");
        int duracionMinutos = int.Parse(Console.ReadLine());
        Console.Write("Formato de archivo (MP3, AAC, WAV): ");
        string formatoArchivo = Console.ReadLine();
        return new Audiolibro(id, titulo, autor, fechaPublicacion, narrador, duracionMinutos, formatoArchivo);
    }

    private static Revista CrearRevista(string id, string titulo, string autor, DateOnly fechaPublicacion)
    {
        Console.Write("Número de edición: ");
        int numeroEdicion = int.Parse(Console.ReadLine());
        Console.Write("Periodicidad (Semanal, Mensual, Anual): ");
        string periodicidad = Console.ReadLine();
        Console.Write("¿Está archivada? (sí/no): ");
        bool estaArchivada = Console.ReadLine().ToLower() == "sí";
        return new Revista(id, titulo, autor, fechaPublicacion, numeroEdicion, periodicidad, estaArchivada);
    }

    private static LibroInteractivo CrearLibroInteractivo(string id, string titulo, string autor, DateOnly fechaPublicacion)
    {
        Console.Write("Plataforma (iOS, Android, Web): ");
        string plataforma = Console.ReadLine();
        Console.Write("Cantidad de recursos multimedia: ");
        int recursosMultimedia = int.Parse(Console.ReadLine());
        return new LibroInteractivo(id, titulo, autor, fechaPublicacion, plataforma, recursosMultimedia);
    }

    public static UsuarioBase CrearUsuario()
    {
        try
        {
            Console.WriteLine("\n=== Ingresar datos del usuario ===");
            Console.WriteLine("----");
            Console.Write("Tipo de usuario (Usuario/Bibliotecario/VisitanteTemporal): ");
            string tipo = Console.ReadLine().ToLower();
            Console.Write("ID: ");
            string id = Console.ReadLine();
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Correo electrónico (@ y .com): ");
            string correo = Console.ReadLine();

            UsuarioBase usuario = tipo switch
            {
                "usuario" => CrearUsuarioRegular(id, nombre, correo),
                "bibliotecario" => new Bibliotecario(id, nombre, correo),
                "visitantetemporal" => new VisitanteTemporal(id, nombre, correo),
                _ => throw new ArgumentException("Tipo de usuario no válido.")
            };
            Console.WriteLine("----");
            return usuario;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    private static Usuario CrearUsuarioRegular(string id, string nombre, string correo)
    {
        Console.Write("Fecha de nacimiento (YYYY-MM-DD): ");
        string fechaNacimiento = Console.ReadLine();
        Console.Write("Número de documento: ");
        string numeroDocumento = Console.ReadLine();
        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();
        Console.Write("Contraseña (8 caráteres): ");
        string contrasena = Console.ReadLine();
        Console.Write("Membresía (Estandar/Premium): ");
        string membresiaInput = Console.ReadLine();
        TipoMembresia membresia = Validaciones.ValidarMembresia(membresiaInput, "Membresía no válida.");
        return new Usuario(id, nombre, correo, fechaNacimiento, numeroDocumento, direccion, contrasena, membresia);
    }

    public static Prestamo CrearPrestamo(List<MaterialDigital> catalogo, List<UsuarioBase> usuarios)
    {
        try
        {
            Console.WriteLine("\n=== Ingresar datos del préstamo ===");
            Console.WriteLine("----");
            Console.Write("Título del material: ");
            string titulo = Console.ReadLine();
            MaterialDigital material = catalogo.Find(m => m.Titulo == titulo);
            if (material == null) throw new ArgumentException("Material no encontrado.");

            Console.Write("Nombre del usuario: ");
            string nombreUsuario = Console.ReadLine();
            UsuarioBase usuario = usuarios.Find(u => u.Nombre == nombreUsuario);
            if (usuario == null) throw new ArgumentException("Usuario no encontrado.");

            Console.Write("Ingrese Fecha de devolución (YYYY-MM-DD)(*Fecha de inicio : Fecha Actual*): ");
            string fechaDevolucion = Console.ReadLine();
            Console.WriteLine("----");
            return new Prestamo(material, fechaDevolucion, usuario);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}