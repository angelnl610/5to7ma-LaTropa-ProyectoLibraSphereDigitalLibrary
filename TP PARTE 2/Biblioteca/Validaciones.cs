namespace DigitalLibrary;

public static class Validaciones
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
            throw new ArgumentException("El correo electrónico no puede estar vacío");
        try
        {
            var addr = new System.Net.Mail.MailAddress(correo);
            if (addr.Address != correo)
                throw new ArgumentException();
        }
        catch
        {
            throw new ArgumentException("El formato de correo electrónico no es válido");
        }
    }

    public static void FechaNoFutura(DateOnly fecha, string mensaje)
    {
        if (fecha > DateOnly.FromDateTime(DateTime.Now))
            throw new ArgumentException(mensaje);
    }
}