using EjemploEditorial;


Console.WriteLine("=== Registro de Editorial ===");


Console.Write("Ingrese el nombre de la editorial: ");
string nombre = Console.ReadLine()!;
Validaciones.ValidarNombre(nombre, "El nombre de la editorial no es válido.");


Console.Write("Ingrese el país de origen: ");
string pais = Console.ReadLine()!;
Validaciones.ValidarPais(pais, "El país de origen no es válido.");


Console.Write("Ingrese el año de fundación (yyyy): ");
string anioInput = Console.ReadLine()!;
int anio = Validaciones.ValidarAnioFundacion(anioInput, "El año de fundación no es válido.");


Console.Write("Ingrese el sitio web oficial (ej. www.ejemplo.com): ");
string sitioWeb = Console.ReadLine()!;
Validaciones.ValidarSitioWeb(sitioWeb, "El sitio web no es válido.");


Editorial editorial = new Editorial();
editorial.Nombre = nombre;
editorial.PaisOrigen = pais;
editorial.AnioFundacion = anio;
editorial.SitioWeb = sitioWeb;


Console.WriteLine("-----------------------------");
Console.WriteLine("Registro Final");
Console.WriteLine($"Nombre: {editorial.Nombre}");
Console.WriteLine($"País de origen: {editorial.PaisOrigen}");
Console.WriteLine($"Año de fundación: {editorial.AnioFundacion}");
Console.WriteLine($"Sitio web: {editorial.SitioWeb}");
Console.WriteLine("-----------------------------");