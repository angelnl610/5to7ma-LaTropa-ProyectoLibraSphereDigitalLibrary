// Faltan metodos

namespace LibraSphere;

public class Editorial
{
    private string Nombre { get;  set; }
    private string PaisOrigen { get;  set; }
    private int AnioFundacion { get;  set; }
    private string SitioWeb { get;  set; }

    // Constructor
    public Editorial(string nombre, string paisOrigen, int anioFundacion, string sitioWeb)
    {
        Validaciones.CadenaMin(nombre, 3, "El nombre de la editorial debe tener al menos 3 caracteres.");
        this.Nombre = nombre;

        Validaciones.CadenaMin(paisOrigen, 3, "El pais de origen debe tener al menos 3 caracteres.");
        this.PaisOrigen = paisOrigen;

 
        Validaciones.AnioValido(anioFundacion, "El año de fundacion debe ser valido");
        this.AnioFundacion = anioFundacion;

        Validaciones.UrlValida(sitioWeb, "El sitio web no es valido. Debe tener formato de URL.");
        this.SitioWeb = sitioWeb;
    }

    // Set
    
    public void SetNombre(string nombre)
    {
        this.Nombre = nombre;
    }        
    public void SetPaisOrigen(string paisOrigen)
    {
        this.PaisOrigen = paisOrigen;
    }        public void SetAnioFundacion(int anioFundacion)
    {
        this.AnioFundacion = anioFundacion;
    }        public void SetSitioWeb(string sitioWeb)
    {
        this.SitioWeb = sitioWeb;
    }
    // Get
    public string GetNombre() => Nombre;
    public string GetPaisOrigen() => PaisOrigen;
    public int GetAnioFundacion() => AnioFundacion;
    public string GetSitioWeb() => SitioWeb;

// metodos


}
