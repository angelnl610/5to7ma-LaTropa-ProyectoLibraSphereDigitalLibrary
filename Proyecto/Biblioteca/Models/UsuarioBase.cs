using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Validaciones;
using Biblioteca.Models;

namespace Biblioteca.Models;
public abstract class UsuarioBase
{
    public string Id { get; private set; }
    public string Nombre { get; private set; }
    public string Correo { get; private set; }

    protected UsuarioBase(string id, string nombre, string correo)
    {
        Validaciones.CadenaMin(id, 1, "El ID del usuario no puede estar vacío.");
        Validaciones.CadenaMin(nombre, 3, "El nombre debe tener al menos 3 caracteres.");
        Validaciones.ValidarCorreoElectronico(correo);

        Id = id;
        Nombre = nombre;
        Correo = correo;
    }

    public abstract void ExplorarCatalogo(List<MaterialDigital> catalogo);
}