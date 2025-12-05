using Biblioteca.Enums;
using Biblioteca.Interfaces;

namespace Biblioteca.Models;

public class Prestamo
{
    public DateOnly FechaEmision { get; private set; }
    public DateOnly FechaDevolucion { get; private set; }
    public DateOnly? FechaDevolucionReal { get; private set; }
    public EstadoPrestamo Estado { get; private set; }
    public MaterialDigital Material { get; private set; }
    public UsuarioBase Usuario { get; private set; }

    public Prestamo(MaterialDigital material, string fechaDevolucion, UsuarioBase usuario)
    {
        if (material == null || usuario == null)
            throw new ArgumentException("El material y el usuario no pueden ser nulos.");

        if (usuario is VisitanteTemporal)
            throw new InvalidOperationException("Los visitantes no pueden prestar materiales.");

        if (material is IPrestable prestable)
        {
            if (!prestable.VerificarDisponibilidad())
                throw new InvalidOperationException("El material no está disponible para préstamo.");

            prestable.Prestar(usuario);
        }
        else
        {
            throw new InvalidOperationException("El material no es prestable.");
        }

        DateOnly fechaDev = Validacion.FechaValida(fechaDevolucion);

        if ((usuario is Usuario u && u.Membresia == TipoMembresia.Premium) || usuario is UsuarioPremium)
        {
            Validacion.FechasPrestamoValidas(
                DateOnly.FromDateTime(DateTime.Now), fechaDev, 30,
                "La fecha de devolución no puede exceder los 30 días para usuarios premium."
            );
        }
        else
        {
            Validacion.FechasPrestamoValidas(
                DateOnly.FromDateTime(DateTime.Now), fechaDev, 15,
                "La fecha de devolución no puede exceder los 15 días para usuarios estándar."
            );
        }

        FechaEmision = DateOnly.FromDateTime(DateTime.Now);
        FechaDevolucion = fechaDev;
        Estado = EstadoPrestamo.Activo;
        Material = material;
        Usuario = usuario;
    }

    public void ActualizarEstadoVencido()
    {
        if (Estado == EstadoPrestamo.Activo &&
            FechaDevolucion < DateOnly.FromDateTime(DateTime.Now))
        {
            Estado = EstadoPrestamo.Vencido;
        }
    }

    public void ActualizarFechaDevolucionReal(string fechaDevolucionReal)
    {
        DateOnly fechaReal = Validacion.FechaValida(fechaDevolucionReal);
        FechaDevolucionReal = fechaReal;

        if (fechaReal <= FechaDevolucion)
        {
            Estado = EstadoPrestamo.Devuelto;
        }
        else
        {
            Estado = EstadoPrestamo.Vencido;
        }

        if (Material is IPrestable prestable)
            prestable.Devolver();
    }

    public void MostrarDatos()
    {
        Console.WriteLine(
        $"\nFecha de Emisión: {FechaEmision}" + $"\nFecha de Devolución: {FechaDevolucion}" +$"\nFecha de Devolución Real: {FechaDevolucionReal?.ToString() ?? "No devuelto"}" +
        $"\nEstado: {Estado}" +
        $"\nMaterial: {Material.Titulo}" +
        $"\nUsuario: {Usuario.Nombre}");
    }
}