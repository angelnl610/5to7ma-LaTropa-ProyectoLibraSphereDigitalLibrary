namespace DigitalLibrary;

public abstract class UsuarioBase
{
    public string Id { get; private set; }
    public string Nombre { get; private set; }
    public string Correo { get; private set; }

    protected UsuarioBase(string id, string nombre, string correo)
    {
        Validaciones.CadenaMin(id, 1, "El ID del usuario no puede estar vacío");
        this.Id = id;
        Validaciones.CadenaMin(nombre, 3, "El nombre debe tener al menos 3 caracteres");
        this.Nombre = nombre;
        Validaciones.ValidarCorreoElectronico(correo);
        this.Correo = correo;
    }

    public abstract void ExplorarCatalogo(List<MaterialDigital> catalogo);
}