namespace DigitalLibrary;

public class Audiolibro : MaterialDigital, IPrestable, IMultimedia
{
    public string Narrador { get; private set; }
    public int DuracionMinutos { get; private set; }
    public string FormatoArchivo { get; private set; }

    public Audiolibro(string id, string titulo, string autor, DateOnly fechaPublicacion, string narrador, int duracionMinutos, string formatoArchivo)
        : base(id, titulo, autor, fechaPublicacion)
    {
        Validaciones.CadenaMin(narrador, 1, "El narrador no puede estar vacío");
        this.Narrador = narrador;
        Validaciones.EnteroMin(duracionMinutos, 1, "La duración debe ser mayor a 0");
        this.DuracionMinutos = duracionMinutos;
        Validaciones.CadenaMin(formatoArchivo, 1, "El formato de archivo no puede estar vacío");
        this.FormatoArchivo = formatoArchivo;
    }

    public override void MostrarResumen()
    {
        Console.WriteLine($"Audiolibro: {Titulo} | Autor: {Autor} | Narrador: {Narrador} | Duración: {DuracionMinutos} min | Formato: {FormatoArchivo}");
    }

    public override void ValidarIntegridad()
    {
        Validaciones.ValidarISBN(Id, "El ISBN del audiolibro es inválido");
        if (DuracionMinutos <= 0)
            throw new ArgumentException("La duración debe ser mayor a 0");
        if (string.IsNullOrEmpty(FormatoArchivo))
            throw new ArgumentException("El formato de archivo es inválido");
    }

    public override void Eliminar()
    {
        Console.WriteLine($"Eliminando audiolibro {Titulo}, sus préstamos y referencias a archivos multimedia...");
    }

    public void Prestar(UsuarioBase usuario)
    {
        if (!VerificarDisponibilidad())
            throw new InvalidOperationException("El audiolibro no está disponible");
        if (usuario is VisitanteTemporal)
            throw new InvalidOperationException("Los visitantes no pueden prestar materiales");
        EstaPrestado = true;
        Console.WriteLine($"Audiolibro {Titulo} prestado a {usuario.Nombre}");
    }

    public void Devolver()
    {
        if (!EstaPrestado)
            throw new InvalidOperationException("El audiolibro no está prestado");
        EstaPrestado = false;
        Console.WriteLine($"Audiolibro {Titulo} devuelto");
    }

    public bool VerificarDisponibilidad()
    {
        return !EstaPrestado;
    }

    public void Reproducir()
    {
        Console.WriteLine($"Reproduciendo audiolibro {Titulo} en formato {FormatoArchivo}...");
    }

    public void MostrarDemo()
    {
        Console.WriteLine($"Mostrando demo de 30 segundos del audiolibro {Titulo}...");
    }
}