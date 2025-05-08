namespace EjemploEditorial
{
   public static class Validaciones
   {
       public static void Nombre(string nombre, string mensajeError)
       {
           if (string.IsNullOrWhiteSpace(nombre) || nombre.Length < 2)
           {
               throw new ArgumentException("{mensajeError} El nombre debe tener al menos 2 caracteres y/o no puede estar vacío.");
           }
       }


       public static void Pais(string pais, string mensajeError)
       {
           if (string.IsNullOrWhiteSpace(pais) || pais.Length < 4)
           {
               throw new ArgumentException("{mensajeError} El país debe tener al menos 4 caracteres y/o no puede estar vacío.");
           }
       }


       public static int AnioFundacion(string anioInput, string mensajeError)
       {
           if (string.IsNullOrWhiteSpace(anioInput) || !int.TryParse(anioInput, out int anio))
           {
               throw new ArgumentException("{mensajeError} El año debe ser un número válido.");
           }
           if (anioInput.Length != 4 || anio < 1000 || anio > DateTime.Now.Year)
           {
               throw new ArgumentException("{mensajeError} El año debe ser un número de 4 dígitos válido y/o no puede ser futuro.");
           }
           return anio;
       }


       public static void AnioFundacion(int anio, string mensajeError)
       {
           string anioStr = anio.ToString();
           if (anioStr.Length != 4 || anio < 1000 || anio > DateTime.Now.Year)
           {
               throw new ArgumentException($"{mensajeError} El año debe ser un número de 4 dígitos válido y/o no puede ser futuro.");
           }
       }


       public static void SitioWeb(string sitioWeb, string mensajeError)
       {
           if (string.IsNullOrWhiteSpace(sitioWeb) ||
               !sitioWeb.ToLower().StartsWith("www.") ||
               !sitioWeb.ToLower().EndsWith(".com") ||
               sitioWeb.Contains(" "))
           {
               throw new ArgumentException($"{mensajeError} El sitio web debe comenzar con 'www.', no tener espacios y/o terminar con '.com'.");
           }
       }
   }
}
