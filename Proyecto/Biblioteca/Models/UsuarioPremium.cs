using Biblioteca.Interfaces;

namespace Biblioteca.Models;
public class UsuarioPremium : UsuarioBase
{
    public UsuarioPremium(string id, string nombre, string correo)
        : base(id, nombre, correo)
    {
    }

    public override void ExplorarCatalogo(List<MaterialDigital> catalogo)
    {
        Console.WriteLine($"Usuario premium {Nombre} explorando catálogo completo con acceso exclusivo:");
        foreach (var material in catalogo)
        {
            material.MostrarResumen();
            if (material is IMultimedia multimedia)
                multimedia.MostrarDemo();
        }
    }
}