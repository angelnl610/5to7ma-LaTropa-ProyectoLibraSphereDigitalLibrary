using Biblioteca.Enums;

namespace Biblioteca
{
    public static class Validacion
    {
        public static void CadenaMin(string valor, int minimo, string mensaje)
        {
            if (string.IsNullOrWhiteSpace(valor) || valor.Length < minimo)
                throw new ArgumentException(mensaje);
        }

        public static void EnteroMin(int valor, int minimo, string mensaje)
        {
            if (valor < minimo)
                throw new ArgumentException(mensaje);
        }

        public static void ValidarISBN(string isbn, string mensaje)
        {
            if (string.IsNullOrWhiteSpace(isbn) || !System.Text.RegularExpressions.Regex.IsMatch(isbn, @"^\d{10}(\d{3})?$"))
                throw new ArgumentException(mensaje);
        }

        public static void ValidarCorreoElectronico(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
                throw new ArgumentException("El correo electrónico no puede estar vacío.");
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                if (addr.Address != correo)
                    throw new ArgumentException();
            }
            catch
            {
                throw new ArgumentException("El formato de correo electrónico no es válido.");
            }
        }

        public static DateOnly FechaValida(string fecha, string mensaje = "El formato de fecha no es válido (use YYYY-MM-DD).")
        {
            if (!DateOnly.TryParse(fecha, out DateOnly resultado))
                throw new ArgumentException(mensaje);
            return resultado;
        }

        public static void FechaNoFutura(DateOnly fecha, string mensaje)
        {
            if (fecha > DateOnly.FromDateTime(DateTime.Now))
                throw new ArgumentException(mensaje);
        }

        public static void FechaMayorDeTrece(DateOnly fechaNacimiento, string mensaje)
        {
            var hoy = DateOnly.FromDateTime(DateTime.Now);
            var edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento > hoy.AddYears(-edad)) edad--;
            if (edad < 13)
                throw new ArgumentException(mensaje);
        }

        public static void FechasPrestamoValidas(DateOnly fechaEmision, DateOnly fechaDevolucion, int maxDias, string mensaje)
        {
            if (fechaDevolucion <= fechaEmision || fechaDevolucion > fechaEmision.AddDays(maxDias))
                throw new ArgumentException(mensaje);
        }

        public static void ValidarFormatoArchivo(string formato, string mensaje)
        {
            var formatosValidos = new[] { "MP3", "AAC", "WAV" };
            if (!formatosValidos.Contains(formato, StringComparer.OrdinalIgnoreCase))
                throw new ArgumentException(mensaje);
        }

        public static void ValidarPlataforma(string plataforma, string mensaje)
        {
            var plataformasValidas = new[] { "iOS", "Android", "Web" };
            if (!plataformasValidas.Contains(plataforma, StringComparer.OrdinalIgnoreCase))
                throw new ArgumentException(mensaje);
        }

        public static void ValidarPeriodicidad(string periodicidad, string mensaje)
        {
            var periodicidadesValidas = new[] { "Semanal", "Mensual", "Anual" };
            if (!periodicidadesValidas.Contains(periodicidad, StringComparer.OrdinalIgnoreCase))
                throw new ArgumentException(mensaje);
        }

        public static GeneroLiterario ValidarGenero(string generoInput, string mensaje)
        {
            if (!Enum.TryParse<GeneroLiterario>(generoInput, true, out GeneroLiterario genero))
                throw new ArgumentException(mensaje);
            return genero;
        }

        public static TipoMembresia ValidarMembresia(string membresiaInput, string mensaje)
        {
            if (!Enum.TryParse<TipoMembresia>(membresiaInput, true, out TipoMembresia membresia))
                throw new ArgumentException(mensaje);
            return membresia;
        }
    }
}