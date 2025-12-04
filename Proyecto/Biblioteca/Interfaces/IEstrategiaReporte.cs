using Biblioteca.Models;

namespace Biblioteca.Interfaces;
public interface IEstrategiaReporte
{
    void Exportar(List<MaterialDigital> catalogo, string archivo);
}

