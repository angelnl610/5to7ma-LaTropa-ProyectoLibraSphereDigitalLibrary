namespace DigitalLibrary;

public class Libro : MaterialDigital, IPrestable
{
    public GeneroLiterario Genero { get; private set; }
    public int CantPaginas { get; private set; }
    public string Idioma { get; private set; }
    public Editorial Editorial { get; private set; }

    public Libro(string id, string titulo, string autor, DateOnly fechaPublicacion, GeneroLiterario genero, int cantPaginas, string idioma, Editorial editorial)
        : base(id, titulo, autor, fechaPublicacion)
    {
        Validaciones.CadenaMin(idioma, 4, "El idioma debe tener al menos 4 caracteres.");
        Validaciones.EnteroMin(cantPaginas, 1, "La cantidad de páginas debe ser mayor a 0.");
        if (editorial == null) throw new ArgumentException("El libro debe tener una editorial asociada.");

        Genero = genero;
        CantPaginas = cantPaginas;
        Idioma = idioma;
        Editorial = editorial;
    }

    public override void MostrarResumen()
    {
        Console.WriteLine($"Libro: {Titulo} | Autor: {Autor} | Género: {Genero} | Páginas: {CantPaginas} | Idioma: {Idioma} | Editorial: {Editorial.Nombre}");
    }

    public override void ValidarIntegridad()
    {
        Validaciones.ValidarISBN(Id, "El ISBN del libro es inválido.");
        if (string.IsNullOrEmpty(Idioma)) throw new ArgumentException("El idioma no puede estar vacío.");
        if (CantPaginas <= 0) throw new ArgumentException("La cantidad de páginas debe ser mayor a 0.");
        if (Editorial == null) throw new ArgumentException("El libro debe tener una editorial asociada.");
    }

    public override void Eliminar(List<Prestamo> prestamos)
    {
        prestamos.RemoveAll(p => p.Material.Id == Id);
        Console.WriteLine($"Eliminando libro {Titulo} y sus préstamos asociados...");
    }

    public void Prestar(UsuarioBase usuario)
    {
        if (!VerificarDisponibilidad()) throw new InvalidOperationException("El libro no está disponible.");
        if (usuario is VisitanteTemporal) throw new InvalidOperationException("Los visitantes no pueden prestar materiales.");
        EstaPrestado = true;
        Console.WriteLine($"Libro {Titulo} prestado a {usuario.Nombre}");
    }

    public void Devolver()
    {
        if (!EstaPrestado) throw new InvalidOperationException("El libro no está prestado.");
        EstaPrestado = false;
        Console.WriteLine($"Libro {Titulo} devuelto");
    }

    public bool VerificarDisponibilidad()
    {
        return !EstaPrestado;
    }
}