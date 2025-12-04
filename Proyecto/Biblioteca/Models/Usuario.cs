using Biblioteca.Enums;
using Biblioteca.Interfaces; 

namespace Biblioteca.Models;
public class Usuario : UsuarioBase
{
    public string FechaNacimiento { get; private set; }
    public string NumeroDocumento { get; private set; }
    public string Direccion { get; private set; }
    public string Contrasena { get; private set; }
    public TipoMembresia Membresia { get; private set; }

    public Usuario(string id, string nombre, string correo, string fechaNacimiento, string numeroDocumento, string direccion, string contrasena, TipoMembresia membresia)
        : base(id, nombre, correo)
    {
        Validacion.FechaValida(fechaNacimiento, "La fecha de nacimiento no es válida (use YYYY-MM-DD).");
        Validacion.FechaMayorDeTrece(DateOnly.Parse(fechaNacimiento), "El usuario debe tener al menos 13 años.");
        Validacion.CadenaMin(numeroDocumento, 6, "El número de documento debe tener al menos 6 caracteres.");
        Validacion.CadenaMin(direccion, 10, "La dirección debe tener al menos 10 caracteres.");
        Validacion.CadenaMin(contrasena, 8, "La contraseña debe tener al menos 8 caracteres.");

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