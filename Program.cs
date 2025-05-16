namespace LibraSphereApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var editoriales = new List<Editorial>();
            var libros = new List<Libro>();
            var usuarios = new List<Usuario>();
            var prestamos = new List<Prestamo>();

            editoriales.Add(new Editorial("Ivrea", "Argentina", 1997, "https://ivrea.com.ar"));
            editoriales.Add(new Editorial("Panini", "Italia", 1961, "https://paninicomics.com"));
            editoriales.Add(new Editorial("Shueisha", "Japón", 1925, "https://shueisha.co.jp"));

            libros.Add(new Libro(9780000000001, "Historias de la noche", "Lopez", 210, "Español"));
            libros.Add(new Libro(9780000000002, "El rugido del silencio", "Leon", 310, "Español"));
            libros.Add(new Libro(9780000000003, "Sombras del mañana", "Aguirre", 180, "Español"));

            usuarios.Add(new Usuario("Angel García", "angel@mail.com", new DateTime(2001, 5, 1), "12345678", "Calle Falsa 123", "claveAngel", true));
            usuarios.Add(new Usuario("Celedonio Pérez", "celedonio@mail.com", new DateTime(2000, 8, 22), "87654321", "Avenida Siempre Viva 742", "claveCeledonio", true));
            usuarios.Add(new Usuario("Ericc Núñez", "ericc@mail.com", new DateTime(2002, 3, 14), "45678912", "Boulevard de los Sueños 10", "claveEricc", false));

            var libroParaPrestar = libros[0];
            if (!libroParaPrestar.GetLibroEnUso())
            {
                var prestamo = new Prestamo(
                    1,
                    DateOnly.FromDateTime(DateTime.Now).ToString("yyyy-MM-dd"),
                    libroParaPrestar,
                    DateOnly.FromDateTime(DateTime.Now.AddDays(7)).ToString("yyyy-MM-dd")
                );
                prestamos.Add(prestamo);
                libroParaPrestar.SetLibroEnUso(true);
            }

            Console.WriteLine("=== EDITORIALES ===");
            foreach (var e in editoriales)
                Console.WriteLine($"{e.GetNombre()} ({e.GetPaisOrigen()}, {e.GetAnioFundacion()}) - {e.GetSitioWeb()}");

            Console.WriteLine("\n=== LIBROS ===");
            foreach (var l in libros)
                Console.WriteLine($"{l.GetISBN()} | {l.GetTitulo()} | {l.GetAutor()} | {l.GetCantPag()} págs | {l.GetIdioma()} | En uso: {l.GetLibroEnUso()}");

            Console.WriteLine("\n=== USUARIOS ===");
            foreach (var u in usuarios)
                Console.WriteLine($"{u.GetNombreCompleto()} | {u.GetEmail()} | Doc: {u.GetDocumento()} | Nac: {u.GetFechaNacimiento():yyyy-MM-dd} | Membresía: {u.GetMembresia()}");

            Console.WriteLine("\n=== PRÉSTAMOS ===");
            foreach (var p in prestamos)
                Console.WriteLine($"ID: {p.GetIdPrestamo()} | Libro: {p.GetLibro().GetTitulo()} | Emisión: {p.GetFechaEmision():yyyy-MM-dd} | Devolución: {p.GetFechaDevolucion():yyyy-MM-dd} | Estado: {p.GetEstadoPrestamo()}");
        }
    }
}