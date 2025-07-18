using DigitalLibrary;

class Program
{
    static List<MaterialDigital> catalogo;
    static List<UsuarioBase> usuarios;
    static void Main()
    {
        try
        {
            InicializarDatos();

            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== Biblioteca Digital ===");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1 - Explorar catálogo como Bibliotecario");
                Console.WriteLine("2 - Explorar catálogo como Usuario Premium");
                Console.WriteLine("3 - Explorar catálogo como Visitante Temporal");
                Console.WriteLine("4 - Salir");

                var tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.D1:
                        MostrarCatalogoBibliotecario();
                        break;
                    case ConsoleKey.D2:
                        MostrarCatalogoUsuarioPremium();
                        break;
                    case ConsoleKey.D3:
                        MostrarCatalogoVisitante();
                        break;
                    case ConsoleKey.D4:
                        salir = true;
                    Console.WriteLine("\nGracias por usar la Biblioteca Digital. Hasta luego!");
                    break;

                    default:
                        Console.WriteLine("Opción inválida. Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("Pulse una tecla para salir...");
            Console.ReadKey();
        }
    }

    static void InicializarDatos()
    {
        catalogo = new List<MaterialDigital>
        {
            new Audiolibro("0987654321", "1984", "George Orwell", new DateOnly(1949, 6, 8), "John Doe", 540, "MP3"),
            new Revista("1112223334", "National Geographic", "Varios", new DateOnly(2023, 1, 15), 123, "Mensual", false),
            new LibroInteractivo("4445556667", "Aprende Python", "Jane Doe", new DateOnly(2022, 10, 10), "Web", 50)
        };

        usuarios = new List<UsuarioBase>
        {
            new Bibliotecario("B001", "Celedoio Leon ", "leon@biblioteca.com"),
            new UsuarioPremium("P001", "Eric Aguirre", "eric@gmail.com"),
            new VisitanteTemporal("V001", "Angel Lopez", "lopez@gmail.com")
        };
    }


    static void MostrarCatalogoBibliotecario()
    {
        Console.Clear();
        var bibliotecario = usuarios.OfType<Bibliotecario>().First();
        Console.WriteLine(">> Bibliotecario explorando catálogo completo:");
        bibliotecario.ExplorarCatalogo(catalogo);
        Console.WriteLine("\nPresione una tecla para volver al menú...");
        Console.ReadKey();
    }

    static void MostrarCatalogoUsuarioPremium()
    {
        Console.Clear();
        var usuarioPremium = usuarios.OfType<UsuarioPremium>().First();
        Console.WriteLine(">> Usuario Premium explorando catálogo con demos:");
        usuarioPremium.ExplorarCatalogo(catalogo);

        // Ejemplo de préstamo
        var audiolibro = catalogo.OfType<Audiolibro>().FirstOrDefault();
        if (audiolibro != null)
        {
            Console.WriteLine("\nIntentando prestar audiolibro...");
            try
            {
                usuarioPremium.PrestarMaterial(catalogo.OfType<Audiolibro>().First());
            }
            
            catch (Exception e)
            {
                Console.WriteLine($"No se pudo prestar: {e.Message}");
            }
        }

        Console.WriteLine("\nPresione una tecla para volver al menú...");
        Console.ReadKey();
    }

    static void MostrarCatalogoVisitante()
    {
        Console.Clear();
        var visitante = usuarios.OfType<VisitanteTemporal>().First();
        Console.WriteLine(">> Visitante temporal explorando catálogo limitado:");
        visitante.ExplorarCatalogo(catalogo);
        Console.WriteLine("\nPresione una tecla para volver al menú...");
        Console.ReadKey();
    }
}
