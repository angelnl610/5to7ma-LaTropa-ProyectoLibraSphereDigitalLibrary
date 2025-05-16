namespace LibraSphere;

public class ManejoBiblioteca
{
    private List<Libro> Libros = new();
    private List<Usuario> Usuarios = new();
    private List<Editorial> Editoriales = new();
    private List<Prestamo> Prestamos = new();

    // Métodos para libro
    public void CrearLibro(long isbn, string titulo, string autor, int cantidadPaginas, string idioma)
    {
        var libro = new Libro(isbn, titulo, autor, cantidadPaginas, idioma);
        Libros.Add(libro);
    }

    public void BorrarLibro(long isbn)
    {
        var libro = Libros.Find(l => l.GetISBN() == isbn);
        if (libro != null)
            Libros.Remove(libro);
    }

    public void MostrarLibros()
    {
        foreach (var libro in Libros)
        {
            Console.WriteLine($"ISBN: {libro.GetISBN()} - Título: {libro.GetTitulo()} - Autor: {libro.GetAutor()} - Idioma: {libro.GetIdioma()} - Páginas: {libro.GetCantPag()} - En uso: {libro.GetLibroEnUso()}");
        }
    }

    // Métodos para usuario
    public void CrearUsuario(string nombreCompleto, string correoElectronico, DateTime fechaNacimiento, string numeroDocumento, string direccion, string contraseña, bool membresiaActiva)
    {
        var usuario = new Usuario(nombreCompleto, correoElectronico, fechaNacimiento, numeroDocumento, direccion, contraseña, membresiaActiva);
        Usuarios.Add(usuario);
    }

    public void BorrarUsuario(string numeroDocumento)
    {
        var usuario = Usuarios.Find(u => u.GetDocumento() == numeroDocumento);
        if (usuario != null)
            Usuarios.Remove(usuario);
    }

    public void MostrarUsuarios()
    {
        foreach (var usuario in Usuarios)
        {
            Console.WriteLine($"Nombre: {usuario.GetNombreCompleto()} - Email: {usuario.GetEmail()} - Documento: {usuario.GetDocumento()} - Fecha Nac: {usuario.GetFechaNacimiento()} - Membresía activa: {usuario.GetMembresia()}");
        }
    }

    // Métodos para editorial
    public void CrearEditorial(string nombre, string paisOrigen, int anioFundacion, string sitioWeb)
    {
        var editorial = new Editorial(nombre, paisOrigen, anioFundacion, sitioWeb);
        Editoriales.Add(editorial);
    }

    public void BorrarEditorial(string nombre)
    {
        var editorial = Editoriales.Find(e => e.GetNombre() == nombre);
        if (editorial != null)
            Editoriales.Remove(editorial);
    }

    public void MostrarEditoriales()
    {
        foreach (var editorial in Editoriales)
        {
            Console.WriteLine($"Nombre: {editorial.GetNombre()} - País: {editorial.GetPaisOrigen()} - Año: {editorial.GetAnioFundacion()} - Sitio Web: {editorial.GetSitioWeb()}");
        }
    }

    // Métodos para prestamo
public void CrearPrestamo(int idPrestamo, string fechaEmision, Libro libro, string fechaDevolucion)
{
    if (!libro.GetLibroEnUso())
    {
        var prestamo = new Prestamo(idPrestamo, fechaEmision, libro, fechaDevolucion);
        Prestamos.Add(prestamo);
        libro.SetLibroEnUso(true);
    }
    else
    {
        throw new ArgumentException("El libro ya se encuentra en uso.");
    }
}

public void DevolverPrestamo(int idPrestamo, string fechaDevolucionReal)
{
    var p = Prestamos.Find(x => x.GetIdPrestamo() == idPrestamo);
    if (p == null) throw new ArgumentException("Préstamo no encontrado.");

    p.SetFechaDevolucionReal(fechaDevolucionReal);

    if (p.GetFechaDevolucionReal() <= p.GetFechaDevolucion())
        p.SetEstado(EEstadoPrestamo.Devuelto);
    else
        p.SetEstado(EEstadoPrestamo.DevueltoVencido);

    p.GetLibro().SetLibroEnUso(false);
}

public void BorrarPrestamo(int idPrestamo)
{
    var p = Prestamos.Find(x => x.GetIdPrestamo() == idPrestamo);
    if (p == null) throw new ArgumentException("Préstamo no encontrado.");

    var estado = p.GetEstadoPrestamo();
    if (estado == EEstadoPrestamo.Devuelto || estado == EEstadoPrestamo.DevueltoVencido)
        Prestamos.Remove(p);
    else
        throw new InvalidOperationException("Debe devolver el libro antes de borrar el préstamo.");
}
