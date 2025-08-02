namespace DigitalLibrary;

public interface IEstrategiaReporte
{
    void Exportar(List<MaterialDigital> catalogo, string archivo);
}

public class ReportePDF : IEstrategiaReporte
{
    public void Exportar(List<MaterialDigital> catalogo, string archivo)
    {
        Console.WriteLine($"Exportando catálogo a PDF: {archivo}");
        foreach (var material in catalogo)
            Console.WriteLine($"[PDF] {material.Titulo}");
    }
}

public class ReporteCSV : IEstrategiaReporte
{
    public void Exportar(List<MaterialDigital> catalogo, string archivo)
    {
        Console.WriteLine($"Exportando catálogo a CSV: {archivo}");
        Console.WriteLine("Titulo,Autor,FechaPublicacion");
        foreach (var material in catalogo)
            Console.WriteLine($"{material.Titulo},{material.Autor},{material.FechaPublicacion}");
    }
}

public class ReporteJSON : IEstrategiaReporte
{
    public void Exportar(List<MaterialDigital> catalogo, string archivo)
    {
        Console.WriteLine($"Exportando catálogo a JSON: {archivo}");
        Console.WriteLine("[");
        foreach (var material in catalogo)
            Console.WriteLine($"  {{ \"Titulo\": \"{material.Titulo}\", \"Autor\": \"{material.Autor}\", \"Fecha\": \"{material.FechaPublicacion}\" }},");
        Console.WriteLine("]");
    }
}