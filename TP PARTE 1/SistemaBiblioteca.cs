namespace LibraSphere;

public class SistemaBiblioteca
{
    private List<Libro> _libros = new List<Libro>();
    private List<Prestamo> _prestamos = new List<Prestamo>();

    public void AgregarLibro(Libro libro)
    {
        if (libro == null) throw new LibraSphereException("El libro no puede ser nulo.");
        _libros.Add(libro);
    }

    public void AgregarPrestamo(Prestamo prestamo)
    {
        if (prestamo == null) throw new LibraSphereException("El préstamo no puede ser nulo.");
        _prestamos.Add(prestamo);
    }

    public void EliminarLibro(Libro libro)
    {
        if (libro == null) throw new LibraSphereException("El libro no puede ser nulo.");
        _prestamos.RemoveAll(p => p.GetLibro() == libro);
        _libros.Remove(libro);
    }

    public List<Libro> GetLibros() => _libros;
    public List<Prestamo> GetPrestamos() => _prestamos;
}