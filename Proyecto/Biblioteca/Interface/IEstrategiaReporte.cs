namespace DigitalLibrary;

public interface IEstrategiaReporte
{
    void Exportar(List<MaterialDigital> catalogo, string archivo);
}

