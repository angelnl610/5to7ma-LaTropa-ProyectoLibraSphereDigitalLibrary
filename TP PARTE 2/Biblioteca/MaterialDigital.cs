namespace DigitalLibrary;

public abstract class MaterialDigital
{
    public string Id { get; private set; }
    public string Titulo { get; private set; }
    public string Autor { get; private set; }
    public DateOnly FechaPublicacion { get; private set; }
    public bool EstaPrestado { get; protected set; }

    protected MaterialDigital(string id, string titulo, string autor, DateOnly fechaPublicacion)
    {
        Validaciones.ValidarISBN(id, "El ID debe ser un ISBN válido");
        this.Id = id;
        Validaciones.CadenaMin(titulo, 1, "El título no puede estar vacío");
        this.Titulo = titulo;
        Validaciones.CadenaMin(autor, 1, "El autor no puede estar vacío");
        this.Autor = autor;
        Validaciones.FechaNoFutura(fechaPublicacion, "La fecha de publicación no puede ser futura");
        this.FechaPublicacion = fechaPublicacion;
        this.EstaPrestado = false;
    }

    public abstract void MostrarResumen();
    public abstract void ValidarIntegridad();
    public abstract void Eliminar();
}
