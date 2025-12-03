namespace DigitalLibrary;

public class Prestamo
{
    public DateOnly FechaEmision { get; private set; }
    public DateOnly FechaDevolucion { get; private set; }
    public DateOnly? FechaDevolucionReal { get; private set; }
    public EstadoPrestamo Estado { get; private set; }
    public string SubEstado { get; private set; }
    public MaterialDigital Material { get; private set; }
    public UsuarioBase Usuario { get; private set; }

    public Prestamo(MaterialDigital material, string fechaDevolucion, UsuarioBase usuario)
    {
        if (material == null || usuario == null) throw new ArgumentException("El material y el usuario no pueden ser nulos.");
        if (usuario is VisitanteTemporal) throw new InvalidOperationException("Los visitantes no pueden prestar materiales.");
        if (material is IPrestable prestable)
        {
            if (!prestable.VerificarDisponibilidad()) throw new InvalidOperationException("El material no está disponible para préstamo.");
            prestable.Prestar(usuario);
        }
        else
        {
            throw new InvalidOperationException("El material no es prestable.");
        }

        DateOnly fechaDev = Validaciones.FechaValida(fechaDevolucion);
        if (usuario is Usuario u && u.Membresia == TipoMembresia.Premium || usuario is UsuarioPremium)
        {
            Validaciones.FechasPrestamoValidas(DateOnly.FromDateTime(DateTime.Now), fechaDev, 30, "La fecha de devolución debe ser posterior a la fecha de emisión y no exceder los 30 días para usuarios premium.");
        }
        else
        {
            Validaciones.FechasPrestamoValidas(DateOnly.FromDateTime(DateTime.Now), fechaDev, 15, "La fecha de devolución debe ser posterior a la fecha de emisión y no exceder los 15 días.");
        }

        FechaEmision = DateOnly.FromDateTime(DateTime.Now);
        FechaDevolucion = fechaDev;
        Estado = EstadoPrestamo.Activo;
        SubEstado = null;
        Material = material;
        Usuario = usuario;
    }

    public void ActualizarEstadoVencido()
    {
        if (Estado == EstadoPrestamo.Activo && FechaDevolucion < DateOnly.FromDateTime(DateTime.Now))
        {
            Estado = EstadoPrestamo.Vencido;
            SubEstado = FechaDevolucionReal == null ? "VencidoSinDevolver" : "VencidoDevuelto";
        }
    }

    public void ActualizarEstado(string estadoInput, string subEstado = null)
    {
        if (!Enum.TryParse<EstadoPrestamo>(estadoInput, true, out EstadoPrestamo estado))
        {
            throw new ArgumentException("Estado de préstamo no válido. Use Activo, Devuelto o Vencido.");
        }
        Estado = estado;
        if (Estado == EstadoPrestamo.Vencido)
        {
            if (subEstado == null || (subEstado != "VencidoDevuelto" && subEstado != "VencidoSinDevolver"))
            {
                throw new ArgumentException("Subestado no válido. Use VencidoDevuelto o VencidoSinDevolver.");
            }
            SubEstado = subEstado;
            if (subEstado == "VencidoDevuelto" && Material is IPrestable prestable)
            {
                prestable.Devolver();
            }
        }
        else
        {
            SubEstado = null;
            if (Estado == EstadoPrestamo.Devuelto && Material is IPrestable prestable)
            {
                prestable.Devolver();
            }
        }
    }

    public void ActualizarFechaDevolucionReal(string fechaDevolucionReal)
    {
        DateOnly fechaReal = Validaciones.FechaValida(fechaDevolucionReal);
        FechaDevolucionReal = fechaReal;
        if (fechaReal <= FechaDevolucion)
        {
            Estado = EstadoPrestamo.Devuelto;
            SubEstado = null;
            if (Material is IPrestable prestable)
                prestable.Devolver();
        }
        else
        {
            Estado = EstadoPrestamo.Vencido;
            SubEstado = "VencidoDevuelto";
            if (Material is IPrestable prestable)
                prestable.Devolver();
        }
    }

    public void MostrarDatos()
    {
        string estadoCompleto = Estado.ToString();
        if (Estado == EstadoPrestamo.Vencido && SubEstado != null)
        {
            estadoCompleto += $" ({SubEstado})";
        }
        Console.WriteLine($"\nFecha de Emisión: {FechaEmision}\nFecha de Devolución: {FechaDevolucion}\nFecha de Devolución Real: {FechaDevolucionReal?.ToString() ?? "No devuelto"}\nEstado: {estadoCompleto}\nMaterial: {Material.Titulo}\nUsuario: {Usuario.Nombre}");
    }
}