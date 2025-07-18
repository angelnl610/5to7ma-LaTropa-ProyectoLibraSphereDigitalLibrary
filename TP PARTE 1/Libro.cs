namespace LibraSphere;

public enum GeneroLiterario
{
    Fantasia,
    CienciaFiccion,
    Drama,
    Romance,
    Misterio,
    Otro
}

public class Libro
{
    private long _isbn;
    private string _titulo;
    private string _autor;
    private GeneroLiterario _genero;
    private int _anioPublicacion;
    private int _cantPaginas;
    private string _idioma;
    private bool _disponible;
    private Editorial _editorial;

    // Constructor
    public Libro(long isbn, string titulo, string autor, GeneroLiterario genero, int anioPublicacion, int cantPaginas, string idioma, Editorial editorial)
    {
        Validaciones.ValidarISBN(isbn, "El ISBN debe contener exactamente 13 dígitos.");
        Validaciones.CadenaMin(titulo, 1, "El título debe tener al menos 1 carácter.");
        Validaciones.CadenaMin(autor, 4, "El autor debe tener al menos 4 caracteres.");
        Validaciones.AnioValido(anioPublicacion, "El año de publicación debe ser válido.");
        Validaciones.Entero(cantPaginas, "La cantidad de páginas debe ser un número entero positivo.");
        Validaciones.CadenaMin(idioma, 4, "El idioma no es válido.");
        if (editorial == null) throw new LibraSphereException("El libro debe tener una editorial asociada.");

        _isbn = isbn;
        _titulo = titulo;
        _autor = autor;
        _genero = genero;
        _anioPublicacion = anioPublicacion;
        _cantPaginas = cantPaginas;
        _idioma = idioma;
        _disponible = true;
        _editorial = editorial;
    }

    // Setters
    public void SetISBN(long isbn)
    {
        Validaciones.ValidarISBN(isbn, "El ISBN debe contener exactamente 13 dígitos.");
        _isbn = isbn;
    }

    public void SetTitulo(string titulo)
    {
        Validaciones.CadenaMin(titulo, 1, "El título debe tener al menos 1 carácter.");
        _titulo = titulo;
    }

    public void SetAutor(string autor)
    {
        Validaciones.CadenaMin(autor, 4, "El autor debe tener al menos 4 caracteres.");
        _autor = autor;
    }

    public void SetGenero(GeneroLiterario genero)
    {
        _genero = genero;
    }

    public void SetAnioPublicacion(int anioPublicacion)
    {
        Validaciones.AnioValido(anioPublicacion, "El año de publicación debe ser válido.");
        _anioPublicacion = anioPublicacion;
    }

    public void SetCantPaginas(int cantPaginas)
    {
        Validaciones.Entero(cantPaginas, "La cantidad de páginas debe ser un número entero positivo.");
        _cantPaginas = cantPaginas;
    }

    public void SetIdioma(string idioma)
    {
        Validaciones.CadenaMin(idioma, 4, "El idioma no es válido.");
        _idioma = idioma;
    }

    public void SetDisponible(bool disponible)
    {
        _disponible = disponible;
    }

    public void SetEditorial(Editorial editorial)
    {
        if (editorial == null) throw new LibraSphereException("El libro debe tener una editorial asociada.");
        _editorial = editorial;
    }

    // Getters
    public long GetISBN() => _isbn;
    public string GetTitulo() => _titulo;
    public string GetAutor() => _autor;
    public GeneroLiterario GetGenero() => _genero;
    public int GetAnioPublicacion() => _anioPublicacion;
    public int GetCantPaginas() => _cantPaginas;
    public string GetIdioma() => _idioma;
    public bool GetDisponible() => _disponible;
    public Editorial GetEditorial() => _editorial;

    public void MostrarDatos() => Console.WriteLine($"Título: {_titulo}\nISBN: {_isbn}\nAutor: {_autor}\nGénero: {_genero}\nAño: {_anioPublicacion}\nPáginas: {_cantPaginas}\nIdioma: {_idioma}\nDisponible: {_disponible}\nEditorial: {_editorial.GetNombre()}");
}