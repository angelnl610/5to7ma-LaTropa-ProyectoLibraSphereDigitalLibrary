namespace DigitalLibrary;

public class LibroInteractivo : MaterialDigital, IPrestable, IMultimedia
{
    public string Plataforma { get; private set; }
    public int RecursosMultimedia { get; private set; }

    public LibroInteractivo(string id, string titulo, string autor, DateOnly fechaPublicacion, string plataforma, int recursosMultimedia)
        : base(id, titulo, autor, fechaPublicacion)
    {
        Validaciones.ValidarPlataforma(plataforma, "La plataforma debe ser iOS, Android o Web.");
        Validaciones.EnteroMin(recursosMultimedia, 0, "Los recursos multimedia no pueden ser negativos.");

        Plataforma = plataforma;
        RecursosMultimedia = recursosMultimedia;
    }

    public override void MostrarResumen()
    {
        Console.WriteLine($"Libro Interactivo: {Titulo} | Autor: {Autor} | Plataforma: {Plataforma} | Recursos Multimedia: {RecursosMultimedia}");
    }

    public override void ValidarIntegridad()
    {
        Validaciones.ValidarISBN(Id, "El ISBN del libro interactivo es inválido.");
        if (!new[] { "iOS", "Android", "Web" }.Contains(Plataforma, StringComparer.OrdinalIgnoreCase))
            throw new ArgumentException("La plataforma es inválida.");
        if (RecursosMultimedia < 0) throw new ArgumentException("Los recursos multimedia no pueden ser negativos.");
    }

    public override void Eliminar(List<Prestamo> prestamos)
    {
        prestamos.RemoveAll(p => p.Material.Id == Id);
        Console.WriteLine($"Eliminando libro interactivo {Titulo}, sus préstamos y dando de baja en la plataforma {Plataforma}...");
    }

    public void Prestar(UsuarioBase usuario)
    {
        if (!VerificarDisponibilidad()) throw new InvalidOperationException("El libro interactivo no está disponible.");
        if (usuario is VisitanteTemporal) throw new InvalidOperationException("Los visitantes no pueden prestar materiales.");
        EstaPrestado = true;
        Console.WriteLine($"Libro interactivo {Titulo} prestado a {usuario.Nombre}");
    }

    public void Devolver()
    {
        if (!EstaPrestado) throw new InvalidOperationException("El libro interactivo no está prestado.");
        EstaPrestado = false;
        Console.WriteLine($"Libro interactivo {Titulo} devuelto");
    }

    public bool VerificarDisponibilidad()
    {
        return !EstaPrestado;
    }

    public void Reproducir()
    {
        Console.WriteLine($"Reproduciendo libro interactivo {Titulo} en plataforma {Plataforma}...");
    }

    public void MostrarDemo()
    {
        Console.WriteLine($"Mostrando demo del libro interactivo {Titulo} con {RecursosMultimedia} recursos multimedia...");
    }
}