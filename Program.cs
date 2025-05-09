// Program de Celedonio FALTA MODIFICAR ATRIBUTOS y UTILIZAR METODOS.  

using LibraSphere;

Console.WriteLine("---Registro de Préstamo---");

Console.Write("Ingrese la fecha de inicio del préstamo (yyyy-mm-dd): ");
DateTime fechaEmision  = DateTime.Parse(Console.ReadLine()!);

Console.Write("Ingrese la fecha límite de devolución (yyyy-mm-dd): ");
DateTime fechaDevolucion = DateTime.Parse(Console.ReadLine()!); 

Console.WriteLine("Seleccione el estado del préstamo:");
Console.WriteLine("1 - Activo\n2 - Devuelto\n3 - Vencido");
int EstadoPrestamo = int.Parse(Console.ReadLine()!);

/* EEstadoPrestamo estado = (EstadoPrestamo)(estado - 1);

Prestamo prestamo = new Prestamo(fechaEmision,fechaDevolucion,estado); */

/* Console.WriteLine("-----------------------------");
Console.WriteLine("Fecha de inicio:" + Prestamo.FechaEmision.ToShortDateString());
Console.WriteLine($"Fecha límite:" + Prestamo.FechaDevolucion.ToShortDateString());
Console.WriteLine($"Estado: "+ Prestamo.estado);
Console.WriteLine("-----------------------------"); */


// Program Eric FALTA MODIFICAR ATRIBUTOS y UTILIZAR METODOS.

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


/* Console.WriteLine("Registro Final");
Console.WriteLine($"Nombre: {editorial.Nombre}");
Console.WriteLine($"País de origen: {editorial.PaisOrigen}");
Console.WriteLine($"Año de fundación: {editorial.AnioFundacion}");
Console.WriteLine($"Sitio web: {editorial.SitioWeb}"); */