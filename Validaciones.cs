// Verificar y comentarizar las validaciones

namespace LibraSphere
{
    public static class Validaciones
    {
        // 
        public static void CadenaMin(string texto, int minimo, string mensaje)
        {
            if (string.IsNullOrWhiteSpace(texto) || texto.Trim().Length < minimo)
            {
                throw new ArgumentException(mensaje);
            }
        }

        // 
        public static void Entero(int valor, string mensaje = "El numero debe ser positivo.")
        {
            if (valor < 0)
            {
                throw new ArgumentException(mensaje);
            }
        }

        // 
        public static void EnteroBetween(int valor, int minimo, long maximo, string mensaje)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new ArgumentException(mensaje);
            }
        }
        public static void EnteroBetweenLong(long valor, long minimo, long maximo, string mensaje)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new ArgumentException(mensaje);
            }
        }

        // 
        public static void AnioValido(int anio, string mensaje)
        {
            int anioActual = DateTime.Now.Year;
            if (anio < 1400 || anio > anioActual)
            {
                throw new ArgumentException(mensaje);
            }
        }

        // 
        public static void CorreoElectronico(string nombreAtributo, string mensaje)
        {
            if(nombreAtributo.LastIndexOf("@") < nombreAtributo.LastIndexOf("."))
            {
                if (!((nombreAtributo.LastIndexOf("@") >= 3) && ((nombreAtributo.Substring(nombreAtributo.LastIndexOf("@"), nombreAtributo.LastIndexOf(".") - nombreAtributo.LastIndexOf("@"))).Length >= 4) && ((nombreAtributo.Substring(nombreAtributo.LastIndexOf("."))).Length == 4)))
                {
                    throw new ArgumentException(mensaje); 
                }
            }else
                throw new ArgumentException(mensaje);   
        }


        // 
        public static void EdadMinima(DateOnly fechaNacimiento, int edadMinima, string mensaje)
        {
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (DateTime.Now.DayOfYear < fechaNacimiento.DayOfYear)
                edad--;

            if (edad < edadMinima)
            {
                throw new ArgumentException(mensaje);
            }
        }

        // 
        public static void UrlValida(string url, string mensaje)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))  
            {
                throw new ArgumentException(mensaje);
            }
        }

        // 
        public static void FechasPrestamoValidas(DateOnly inicio, DateOnly devolucion, string mensaje)
        {
            if (devolucion <= inicio)
            {
                throw new ArgumentException(mensaje);
            }
        }

        public static void ValidarFechaNoPasada(DateOnly fecha, string mensaje)
        {
            if (fecha < DateOnly.FromDateTime(DateTime.Now))
            {
            throw new ArgumentException(mensaje);
            }
        }

        public static void ValidarFechaDevolucion(DateOnly fechaDevolucionReal, DateOnly fechaDevolucionEsperada, string mensaje)
        {
            if (fechaDevolucionReal > fechaDevolucionEsperada)
            {
        throw new ArgumentException(mensaje);
            }
        }
        public static void FechaMayorDeEdad(DateTime fechaNacimiento, string mensaje)
        {
            int edad = DateTime.Today.Year - fechaNacimiento.Year;
 
            if (fechaNacimiento > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }

            if (edad < 18)
            {
            throw new ArgumentException(mensaje);
            }
        }
    }

    
}