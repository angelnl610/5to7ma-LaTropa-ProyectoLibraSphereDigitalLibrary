namespace LibraSphere;
public class Editorial
{
    private string _nombre;
    private string _paisOrigen;
    private int _anioFundacion;
    private string _sitioWeb;

    // Constructor
    public Editorial(string nombre, string paisOrigen, int anioFundacion, string sitioWeb)
    {
        Validaciones.CadenaMin(nombre, 3, "El nombre de la editorial debe tener al menos 3 caracteres.");
        Validaciones.CadenaMin(paisOrigen, 3, "El país de origen debe tener al menos 3 caracteres.");
        Validaciones.AnioValido(anioFundacion, "El año de fundación debe ser válido.");
        Validaciones.UrlValida(sitioWeb, "El sitio web no es válido. Debe tener formato de URL.");

        _nombre = nombre;
        _paisOrigen = paisOrigen;
        _anioFundacion = anioFundacion;
        _sitioWeb = sitioWeb;
    }

    // Setters
    public void SetNombre(string nombre)
    {
        Validaciones.CadenaMin(nombre, 3, "El nombre de la editorial debe tener al menos 3 caracteres.");
        _nombre = nombre;
    }

    public void SetPaisOrigen(string paisOrigen)
    {
        Validaciones.CadenaMin(paisOrigen, 3, "El país de origen debe tener al menos 3 caracteres.");
        _paisOrigen = paisOrigen;
    }

    public void SetAnioFundacion(int anioFundacion)
    {
        Validaciones.AnioValido(anioFundacion, "El año de fundación debe ser válido.");
        _anioFundacion = anioFundacion;
    }

    public void SetSitioWeb(string sitioWeb)
    {
        Validaciones.UrlValida(sitioWeb, "El sitio web no es válido. Debe tener formato de URL.");
        _sitioWeb = sitioWeb;
    }

    // Getters
    public string GetNombre() => _nombre;
    public string GetPaisOrigen() => _paisOrigen;
    public int GetAnioFundacion() => _anioFundacion;
    public string GetSitioWeb() => _sitioWeb;

    public void MostrarDatos() => Console.WriteLine($"Nombre: {_nombre}\nPaís de Origen: {_paisOrigen}\nAño de Fundación: {_anioFundacion}\nSitio Web: {_sitioWeb}");
}