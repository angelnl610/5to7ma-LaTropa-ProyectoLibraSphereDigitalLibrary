namespace LibraSphere;

public class ConversionParse
{
    public static int Entero(string mensaje)
    {
        Console.WriteLine(mensaje);
        int resultado = int.Parse(Console.ReadLine());
        return resultado;
    }

    public static long Long(string mensaje)
    {
        Console.WriteLine(mensaje);
        long resultado = long.Parse(Console.ReadLine());
        return resultado;
    }

    public static string Cadena(string mensaje)
    {
        Console.WriteLine(mensaje);
        string resultado = Console.ReadLine();
        return resultado;
    }

    public static double Double(string mensaje)
    {
        Console.WriteLine(mensaje);
        double resultado = double.Parse(Console.ReadLine());
        return resultado;
    }

    public static short Short(string mensaje)
    {
        Console.WriteLine(mensaje);
        short resultado = short.Parse(Console.ReadLine());
        return resultado;
    }
}