
using System.Dynamic;

namespace LibraSphere;



public class Prestamo
{

    public enum EstadoPrestamo
    {
        Activo,
        Devuelto,
        DevueltoVencido

    }



    // Atributos
    private DateOnly FechaEmision { get; set; }
    private Libro Libro { get; set; }
    private DateOnly FechaDevolucion { get; set; }
    private DateOnly? FechaDevolucionReal { get; set; }
    private EstadoPrestamo Estado { get; set; }
    private Usuario usuario;


    // Constructor
    public Prestamo(Libro libro, string fechaDevolucion, Usuario usuario)
    {

        this.FechaEmision = DateOnly.FromDateTime(DateTime.Now);

        Validaciones.ValidarFechaNoPasada(DateOnly.Parse(fechaDevolucion), "La fecha de devolucion no puede ser antes que la fecha de emision.");
        this.FechaDevolucion = Validaciones.FechaValida(fechaDevolucion);

        this.Libro = libro;

        this.Estado = EstadoPrestamo.Activo;

        this.usuario = usuario;

    }

    // Setters


    public void SetFechaEmision(string fechaEmision)
    {
        this.FechaEmision = DateOnly.Parse(fechaEmision);
    }

    public void SetLibro(Libro libro)
    {
        this.Libro = libro;
    }

    public void SetFechaDevolucion(string fechaDevolucion)
    {
        Validaciones.ValidarFechaNoPasada(DateOnly.Parse(fechaDevolucion), "La fecha de devolucion no puede ser anterior a la fecha de emision");
        this.FechaDevolucion = DateOnly.Parse(fechaDevolucion);
    }

    public void SetFechaDevolucionReal(string fechaDevolucionReal)
    {
        DateOnly fechaReal = DateOnly.Parse(fechaDevolucionReal);
        Validaciones.ValidarFechaDevolucion(fechaReal, this.FechaDevolucion, "La fecha de devolucion real no puede ser posterior a la fecha de devolucion esperada");
        this.FechaDevolucionReal = fechaReal;
    }

    public void SetEstado(EstadoPrestamo estadoPrestamo)
    {
        this.Estado = EstadoPrestamo.Devuelto;
    }

    // Getters
    public DateOnly GetFechaEmision() => FechaEmision;
    public Libro GetLibro() => Libro;
    public DateOnly GetFechaDevolucion() => FechaDevolucion;
    public DateOnly? GetFechaDevolucionReal() => FechaDevolucionReal;

    public EstadoPrestamo GetEstadoPrestamo() => Estado;

    public void MostrarDatos()
    {
        Console.WriteLine($"\nFechaEmision: {FechaEmision} \nFecha devolucion: {FechaDevolucion} \nFecha devolución real: {FechaDevolucionReal} \nUsuario: ");
        usuario.MostrarDatosUsuario();
        
    } 
    
    
    }