using System.Text.RegularExpressions;

namespace LibraSphere;

public class LibraSphereException : Exception
{
    public LibraSphereException(string message) : base(message) { }
}

public static class Validaciones
{
    public static void CadenaMin(string texto, int minimo, string mensaje)
    {
        if (string.IsNullOrWhiteSpace(texto) || texto.Trim().Length < minimo)
        {
            throw new LibraSphereException(mensaje);
        }
    }

    public static void Entero(int valor, string mensaje = "El número debe ser positivo.")
    {
        if (valor < 0)
        {
            throw new LibraSphereException(mensaje);
        }
    }

    public static void EnteroBetweenLong(long valor, long minimo, long maximo, string mensaje)
    {
        if (valor < minimo || valor > maximo)
        {
            throw new LibraSphereException(mensaje);
        }
    }

    public static void ValidarISBN(long isbn, string mensaje)
    {
        string isbnStr = isbn.ToString();
        if (isbnStr.Length != 13 || !Regex.IsMatch(isbnStr, @"^\d{13}$"))
        {
            throw new LibraSphereException(mensaje);
        }
    }

    public static void AnioValido(int anio, string mensaje)
    {
        int anioActual = DateTime.Now.Year;
        if (anio < 1400 || anio > anioActual)
        {
            throw new LibraSphereException(mensaje);
        }
    }

    public static DateOnly FechaValida(string fecha)
    {
        if (!DateOnly.TryParse(fecha, out DateOnly resultado))
        {
            throw new LibraSphereException("El formato de la fecha debe ser 'YYYY-MM-DD'.");
        }
        return resultado;
    }

    public static void CorreoElectronico(string correo, string mensaje)
    {
        if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            throw new LibraSphereException(mensaje);
        }
    }

    public static void FechaMayorDeTrece(DateOnly fechaNacimiento, string mensaje)
    {
        int edad = DateTime.Today.Year - fechaNacimiento.Year;
        if (DateTime.Today.DayOfYear < fechaNacimiento.DayOfYear)
            edad--;
        if (edad < 13)
        {
            throw new LibraSphereException(mensaje);
        }
    }

    public static void UrlValida(string url, string mensaje)
    {
        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            throw new LibraSphereException(mensaje);
        }
    }

    public static void FechasPrestamoValidas(DateOnly inicio, DateOnly devolucion, string mensaje)
    {
        if (devolucion <= inicio)
        {
            throw new LibraSphereException(mensaje);
        }
    }

    public static void ValidarFechaNoPasada(DateOnly fecha, string mensaje)
    {
        if (fecha < DateOnly.FromDateTime(DateTime.Now))
        {
            throw new LibraSphereException(mensaje);
        }
    }

    public static void ValidarFechaDevolucion(DateOnly fechaDevolucionReal, DateOnly fechaDevolucionEsperada, string mensaje)
    {
        if (fechaDevolucionReal > fechaDevolucionEsperada)
        {
            throw new LibraSphereException(mensaje);
        }
    }
}