
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
        private int IdPrestamo { get;  set; }
        private DateOnly FechaEmision { get;  set; }
        private Libro Libro { get;  set; }
        private DateOnly FechaDevolucion { get;  set; }
        private DateOnly? FechaDevolucionReal { get;  set; }

        private EstadoPrestamo Estado {get;  set;  } 


        // Constructor
        public Prestamo(int idPrestamo, string fechaEmision, Libro libro, string fechaDevolucion)
        {
            Validaciones.Entero(idPrestamo, "El id de prestamo debe ser un numero entero.");
            this.IdPrestamo = idPrestamo;

            this.FechaEmision = DateOnly.Parse(fechaEmision);

            Validaciones.ValidarFechaNoPasada(DateOnly.Parse(fechaDevolucion), "La fecha de devolucion no puede ser antes que la fecha de emision.");
            this.FechaDevolucion = DateOnly.Parse(fechaDevolucion);


            this.Libro = libro;

            this.Estado = EstadoPrestamo.Devuelto;
            
        }

        // Setters
        public void SetIdPrestamo(int idPrestamo)
        {
            Validaciones.Entero(idPrestamo, "El ID de prestamo debe ser un numero entero.");
            this.IdPrestamo = idPrestamo;
        }

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
        public int GetIdPrestamo() => IdPrestamo;
        public DateOnly GetFechaEmision() => FechaEmision;
        public Libro GetLibro() => Libro;
        public DateOnly GetFechaDevolucion() => FechaDevolucion;
        public DateOnly? GetFechaDevolucionReal() => FechaDevolucionReal;

        public EstadoPrestamo GetEstadoPrestamo() => Estado;

        void MostrarDatos() => Console.WriteLine($"idPrestamo: {IdPrestamo} n/FechaEmision: {FechaEmision} n/Fecha devolucion: {FechaDevolucion} n/Fecha devolución real: {FechaDevolucionReal}");
    
    }