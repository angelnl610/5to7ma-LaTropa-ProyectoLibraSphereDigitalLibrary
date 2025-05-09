namespace EjemploPrestamo
{
   public static class Validaciones
   {
       public static void FechaInicio(DateTime FechaInicio,string error)
       {
           if (FechaInicio > DateTime.Now)
           {
               throw new ArgumentException("La fecha de inicio no puede ser futura.");
           }
       }


       public static void FechaLimite(DateTime fechaInicio, DateTime fechaLimite,string error)
       {
           if (fechaLimite <= fechaInicio)
           {
               throw new ArgumentException("La fecha límite debe ser posterior a la fecha de inicio.");
           }
       }


       public static void Estado(EstadoPrestamo estado,string error)
       {
           if (!Enum.IsDefined(typeof(EstadoPrestamo), estado))
     {
           throw new ArgumentException("Estado no válido.");
      }
 }
   }
}
