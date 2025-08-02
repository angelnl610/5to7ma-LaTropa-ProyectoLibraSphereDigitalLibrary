namespace DigitalLibrary;

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

    public void PrestarMaterial(MaterialDigital material)
    {
        if (material is IPrestable prestable)
            prestable.Prestar(this);
        else
            throw new InvalidOperationException("El material no es prestable.");
    }

    public void DevolverMaterial(MaterialDigital material)
    {
        if (material is IPrestable prestable)
            prestable.Devolver();
        else
            throw new InvalidOperationException("El material no es prestable.");
    }
}