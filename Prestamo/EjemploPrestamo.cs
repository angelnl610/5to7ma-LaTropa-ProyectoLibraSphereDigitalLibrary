namespace EjemploPrestamo
   {
       public enum EstadoPrestamo
       {
           Activo,
           Devuelto,
           Vencido
       }
   public class Prestamo
   {
       private DateTime fechaInicio;
       private DateTime fechaLimite;
       private EstadoPrestamo estado;


       public Prestamo(DateTime fechaInicio,DateTime fechaLimite, EstadoPrestamo estado)
       {
           Validaciones.FechaInicio(fechaInicio,"La fecha de inicio no es válido.");
           Validaciones.FechaLimite(fechaInicio,fechaLimite,"La fecha limite no es válido.");
           Validaciones.Estado(estado,"El estado no es válidad.");
        

           this.fechaInicio = fechaInicio;
           this.fechaLimite = fechaLimite;
           this.estado = estado;
       }
       
       public DateTime FechaInicio{
        get {return fechaInicio ;}

        set{Validaciones.FechaInicio(value,"error");
            fechaInicio = value;


       }
       }
      
       public DateTime FechaLimite
       {
        get{return fechaLimite ;}

        set{
            Validaciones.FechaLimite(fechaInicio,value,"");
            fechaInicio = value;    
           }
       }
      
       public EstadoPrestamo Estado
       {
       get{return  estado;}
       set{
           Validaciones.Estado(value,"error");
           estado = value;
          }

           }
          }
       }
