using EjemploPrestamo;

Console.WriteLine("---Registro de Préstamo---");

// Fecha de inicio
Console.Write("Ingrese la fecha de inicio del préstamo (yyyy-mm-dd): ");
DateTime fechaInicio = DateTime.Parse(Console.ReadLine()!);

// Fecha límite
Console.Write("Ingrese la fecha límite de devolución (yyyy-mm-dd): ");
DateTime fechaLimite = DateTime.Parse(Console.ReadLine()!);

// Estado del préstamo
Console.WriteLine("Seleccione el estado del préstamo:");
Console.WriteLine("1 - Activo\n2 - Devuelto\n3 - Vencido");
int opcionEstado = int.Parse(Console.ReadLine()!);
EstadoPrestamo estado = (EstadoPrestamo)(opcionEstado - 1);

// Crear el objeto préstamo
Prestamo prestamo = new Prestamo(fechaInicio,fechaLimite,estado);

// Mostrar resultados
Console.WriteLine("-----------------------------");
Console.WriteLine("Fecha de inicio:" + prestamo.FechaInicio.ToShortDateString());
Console.WriteLine($"Fecha límite:" + prestamo.FechaLimite.ToShortDateString());
Console.WriteLine($"Estado: "+ prestamo.Estado);
Console.WriteLine("-----------------------------");

