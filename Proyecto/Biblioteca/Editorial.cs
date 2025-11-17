namespace DigitalLibrary;

public class Editorial
{
    public string Nombre { get; set; }
    public string PaisOrigen { get; set; }
    public int AnioFundacion { get; set; }
    public string SitioWeb { get; set; }

    public Editorial(string nombre, string paisOrigen, int anioFundacion, string sitioWeb)
    {
        Validaciones.CadenaMin(nombre, 3, "El nombre de la editorial debe tener al menos 3 caracteres.");
        Validaciones.CadenaMin(paisOrigen, 3, "El país de origen debe tener al menos 3 caracteres.");
        Validaciones.EnteroMin(anioFundacion, 1800, "El año de fundación debe ser mayor a 1800.");
        Validaciones.CadenaMin(sitioWeb, 1, "El sitio web no puede estar vacío.");

        Nombre = nombre;
        PaisOrigen = paisOrigen;
        AnioFundacion = anioFundacion;
        SitioWeb = sitioWeb;
    }

    public void MostrarDatos() => Console.WriteLine($"Nombre: {Nombre}\nPaís de Origen: {PaisOrigen}\nAño de Fundación: {AnioFundacion}\nSitio Web: {SitioWeb}");
}