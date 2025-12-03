namespace DigitalLibrary;

public class VisitanteTemporal : UsuarioBase
{
    public VisitanteTemporal(string id, string nombre, string correo)
        : base(id, nombre, correo)
    {
    }

    public override void ExplorarCatalogo(List<MaterialDigital> catalogo)
    {
        Console.WriteLine($"Visitante temporal {Nombre} explorando catálogo limitado:");
        var materialesLimitados = catalogo.Take(5).ToList();
        foreach (var material in materialesLimitados)
            material.MostrarResumen();
    }
}   