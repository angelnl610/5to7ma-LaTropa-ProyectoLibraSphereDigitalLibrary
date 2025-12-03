
namespace DigitalLibrary;
public class Bibliotecario : UsuarioBase
{
    public Bibliotecario(string id, string nombre, string correo)
        : base(id, nombre, correo)
    {
    }

    public override void ExplorarCatalogo(List<MaterialDigital> catalogo)
    {
        Console.WriteLine($"Bibliotecario {Nombre} explorando el catálogo completo:");
        foreach (var material in catalogo)
            material.MostrarResumen();
    }

    public void AdministrarCatalogo(List<MaterialDigital> catalogo, MaterialDigital material, bool agregar, List<Prestamo> prestamos)
    {
        if (agregar)
        {
            material.ValidarIntegridad();
            catalogo.Add(material);
            Console.WriteLine($"Material {material.Titulo} agregado al catálogo.");
        }
        else
        {
            material.Eliminar(prestamos);
            catalogo.Remove(material);
            Console.WriteLine($"Material {material.Titulo} eliminado del catálogo.");
        }
    }

    public void GestionarPrestamoVencido(UsuarioBase usuario, MaterialDigital material, List<Prestamo> prestamos)
    {
        if (material is IPrestable prestable && !prestable.VerificarDisponibilidad())
        {
            var prestamo = prestamos.Find(p => p.Material.Id == material.Id && p.Estado == EstadoPrestamo.Activo);
            if (prestamo != null)
            {
                prestamo.ActualizarEstadoVencido();
                if (prestamo.Estado == EstadoPrestamo.Vencido)
                {
                    prestable.Devolver();
                    Console.WriteLine($"Préstamo vencido de {material.Titulo} gestionado para {usuario.Nombre}");
                }
            }
        }
    }
}