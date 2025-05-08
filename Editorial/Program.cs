using EjemploEditorial;


Console.WriteLine("Registro de Editorial");


Console.Write("Ingrese el nombre de la editorial: ");
string nombre = Console.ReadLine()!;


Console.Write("Ingrese el país de origen: ");
string paisOrigen = Console.ReadLine()!;


Console.Write("Ingrese el año de fundación (yyyy): ");
int anioFundacion = int.Parse(Console.ReadLine()!);


Console.Write("Ingrese el sitio web oficial (ej. www.ejemplo.com): ");
string sitioWeb = Console.ReadLine()!;



Editorial editorial = new Editorial(nombre, paisOrigen, anioFundacion,sitioWeb);


Console.WriteLine("Registro Final");
Console.WriteLine($"Nombre: {editorial.Nombre}");
Console.WriteLine($"País de origen: {editorial.PaisOrigen}");
Console.WriteLine($"Año de fundación: {editorial.AnioFundacion}");
Console.WriteLine($"Sitio web: {editorial.SitioWeb}");
