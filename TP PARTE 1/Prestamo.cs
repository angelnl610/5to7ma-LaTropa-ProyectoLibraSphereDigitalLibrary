namespace LibraSphere;

public class Prestamo
{
    public enum EstadoPrestamo
    {
        Activo,
        Devuelto,
        Vencido
    }

    private DateOnly _fechaEmision;
    private DateOnly _fechaDevolucion;
    private DateOnly? _fechaDevolucionReal;
    private EstadoPrestamo _estado;
    private string _subEstado; // Para manejar VencidoDevuelto o VencidoSinDevolver
    private Libro _libro;
    private Usuario _usuario;

    // Constructor
    public Prestamo(Libro libro, string fechaDevolucion, Usuario usuario)
    {
        if (libro == null || usuario == null) throw new LibraSphereException("El libro y el usuario no pueden ser nulos.");
        if (!libro.GetDisponible()) throw new LibraSphereException("El libro no está disponible para préstamo.");

        Validaciones.ValidarFechaNoPasada(DateOnly.Parse(fechaDevolucion), "La fecha de devolución no puede ser anterior a la fecha actual.");
        Validaciones.FechasPrestamoValidas(DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse(fechaDevolucion), "La fecha de devolución debe ser posterior a la fecha de emisión.");

        _fechaEmision = DateOnly.FromDateTime(DateTime.Now);
        _fechaDevolucion = DateOnly.Parse(fechaDevolucion);
        _estado = EstadoPrestamo.Activo;
        _subEstado = null;
        _libro = libro;
        _usuario = usuario;
        _libro.SetDisponible(false);
    }

    // Método para actualizar el estado si el préstamo está vencido
    public void ActualizarEstadoVencido()
    {
        if (_estado == EstadoPrestamo.Activo && _fechaDevolucion < DateOnly.FromDateTime(DateTime.Now))
        {
            _estado = EstadoPrestamo.Vencido;
            _subEstado = _fechaDevolucionReal == null ? "VencidoSinDevolver" : "VencidoDevuelto";
        }
    }

    // Setters
    public void SetFechaEmision(string fechaEmision)
    {
        DateOnly fecha = Validaciones.FechaValida(fechaEmision);
        Validaciones.FechasPrestamoValidas(fecha, _fechaDevolucion, "La fecha presentada no puede ser posterior a la fecha de devolución.");
        _fechaEmision = fecha;
    }

    public void SetFechaDevolucion(string fechaDevolucion)
    {
        DateOnly fecha = Validaciones.FechaValida(fechaDevolucion);
        Validaciones.FechasPrestamoValidas(_fechaEmision, fecha, "La fecha de devolución debe ser posterior a la fecha de emisión.");
        _fechaDevolucion = fecha;
    }

    public void SetFechaDevolucionReal(string fechaDevolucionReal)
    {
        DateOnly fechaReal = Validaciones.FechaValida(fechaDevolucionReal);
        _fechaDevolucionReal = fechaReal;
        if (fechaReal <= _fechaDevolucion)
        {
            _estado = EstadoPrestamo.Devuelto;
            _subEstado = null;
            _libro.SetDisponible(true);
        }
        else
        {
            _estado = EstadoPrestamo.Vencido;
            _subEstado = "VencidoDevuelto";
            _libro.SetDisponible(true);
        }
    }

    public void SetEstado(string estadoInput, string subEstado = null)
    {
        if (!Enum.TryParse<EstadoPrestamo>(estadoInput, true, out EstadoPrestamo estado))
        {
            throw new LibraSphereException("Estado de préstamo no válido. Use Activo, Devuelto o Vencido.");
        }
        _estado = estado;
        if (_estado == EstadoPrestamo.Vencido)
        {
            if (subEstado == null || (subEstado != "VencidoDevuelto" && subEstado != "VencidoSinDevolver"))
            {
                throw new LibraSphereException("Subestado no válido. Use VencidoDevuelto o VencidoSinDevolver.");
            }
            _subEstado = subEstado;
            if (subEstado == "VencidoDevuelto")
            {
                _libro.SetDisponible(true);
            }
        }
        else
        {
            _subEstado = null;
            if (_estado == EstadoPrestamo.Devuelto)
            {
                _libro.SetDisponible(true);
            }
        }
    }

    // Getters
    public DateOnly GetFechaEmision() => _fechaEmision;
    public DateOnly GetFechaDevolucion() => _fechaDevolucion;
    public DateOnly? GetFechaDevolucionReal() => _fechaDevolucionReal;
    public EstadoPrestamo GetEstado() => _estado;
    public string GetSubEstado() => _subEstado;
    public Libro GetLibro() => _libro;
    public Usuario GetUsuario() => _usuario;

    public void MostrarDatos()
    {
        string estadoCompleto = _estado.ToString();
        if (_estado == EstadoPrestamo.Vencido && _subEstado != null)
        {
            estadoCompleto += $" ({_subEstado})";
        }
        Console.WriteLine($"\nFecha de Emisión: {_fechaEmision}\nFecha de Devolución: {_fechaDevolucion}\nFecha de Devolución Real: {_fechaDevolucionReal?.ToString() ?? "No devuelto"}\nEstado: {estadoCompleto}\nLibro: {_libro.GetTitulo()}\nUsuario: {_usuario.GetNombreCompleto()}");
    }
}