namespace DigitalLibrary;

public enum TipoMembresia
{
    Estandar,
    Premium
}

public class Usuario : UsuarioBase
{
    public string FechaNacimiento { get; set; }
    public string NumeroDocumento { get; set; }
    public string Direccion { get; set; }
    public string Contrasena { get; set; }
    public TipoMembresia Membresia { get; set; }

    public Usuario(string id, string nombre, string correo, string fechaNacimiento, string numeroDocumento, string direccion, string contrasena, TipoMembresia membresia)
        : base(id, nombre, correo)
    {
        Validaciones.FechaValida(fechaNacimiento, "La fecha de nacimiento no es válida (use YYYY-MM-DD).");
        Validaciones.FechaMayorDeTrece(DateOnly.Parse(fechaNacimiento), "El usuario debe tener al menos 13 años.");
        Validaciones.CadenaMin(numeroDocumento, 6, "El número de documento debe tener al menos 6 caracteres.");
        Validaciones.CadenaMin(direccion, 10, "La dirección debe tener al menos 10 caracteres.");
        Validaciones.CadenaMin(contrasena, 8, "La contraseña debe tener al menos 8 caracteres.");

        FechaNacimiento = fechaNacimiento;
        NumeroDocumento = numeroDocumento;
        Direccion = direccion;
        Contrasena = contrasena;
        Membresia = membresia;
    }

    public override void ExplorarCatalogo(List<MaterialDigital> catalogo)
    {
        if (Membresia == TipoMembresia.Premium)
        {
            Console.WriteLine($"Usuario premium {Nombre} explorando catálogo completo con acceso exclusivo:");
            foreach (var material in catalogo)
            {
                material.MostrarResumen();
                if (material is IMultimedia multimedia)
                    multimedia.MostrarDemo();
            }
        }
        else
        {
            Console.WriteLine($"Usuario estándar {Nombre} explorando catálogo:");
            foreach (var material in catalogo)
                material.MostrarResumen();
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