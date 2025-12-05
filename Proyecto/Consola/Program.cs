using Biblioteca.Enums;
using Biblioteca.Interfaces;
using Biblioteca.Interfaces.Reports;
using Biblioteca.Models;

class Program
{
    static void Main()
    {
        List<MaterialDigital> catalogo = new List<MaterialDigital>();
        List<UsuarioBase> usuarios = new List<UsuarioBase>();
        List<Prestamo> prestamos = new List<Prestamo>();
        List<Empleado> empleados = new List<Empleado>();

        while (true)
        {
            Console.WriteLine("\n=== Menú de LibraSphere ===");
            Console.WriteLine("1. Crear Materiales, Usuarios y Préstamos");
            Console.WriteLine("2. Explorar Catálogo como Bibliotecario");
            Console.WriteLine("3. Explorar Catálogo como Usuario Premium");
            Console.WriteLine("4. Explorar Catálogo como Visitante");
            Console.WriteLine("5. Salir");
            Console.WriteLine("6. SAFE ENTRY - Gestión de Empleados");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();
            Console.WriteLine("----");

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("\n=== Crear ===");
                    Console.WriteLine("1. Crear Material");
                    Console.WriteLine("2. Crear Usuario");
                    Console.WriteLine("3. Crear Préstamo");
                    Console.Write("Seleccione una acción: ");
                    string accionCrear = Console.ReadLine();
                    if (accionCrear == "1")
                    {
                        try
                        {
                            MaterialDigital material = CrearObjeto.CrearMaterial();
                            catalogo.Add(material);
                            Console.WriteLine($"Material {material.Titulo} agregado al catálogo.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                    else if (accionCrear == "2")
                    {
                        try
                        {
                            UsuarioBase usuario = CrearObjeto.CrearUsuario();
                            usuarios.Add(usuario);
                            Console.WriteLine($"Usuario {usuario.Nombre} creado.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                    else if (accionCrear == "3")
                    {
                        try
                        {
                            Prestamo prestamo = CrearObjeto.CrearPrestamo(catalogo, usuarios);
                            prestamos.Add(prestamo);
                            Console.WriteLine($"Préstamo de {prestamo.Material.Titulo} creado para {prestamo.Usuario.Nombre}.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Acción no válida.");
                    }
                    break;

                case "2":
                    if (usuarios.Any(u => u is Bibliotecario))
                    {
                        Bibliotecario bibliotecario = (Bibliotecario)usuarios.First(u => u is Bibliotecario);
                        Console.WriteLine("\n=== Explorar como Bibliotecario ===");
                        bibliotecario.ExplorarCatalogo(catalogo);
                        Console.WriteLine("\nOpciones de Bibliotecario:");
                        Console.WriteLine("1. Agregar Material");
                        Console.WriteLine("2. Eliminar Material");
                        Console.WriteLine("3. Gestionar Préstamo Vencido");
                        Console.WriteLine("4. Exportar Reporte");
                        Console.Write("Seleccione una acción: ");
                        string accionBiblio = Console.ReadLine();
                        if (accionBiblio == "1")
                        {
                            try
                            {
                                MaterialDigital material = CrearObjeto.CrearMaterial();
                                bibliotecario.AdministrarCatalogo(catalogo, material, true, prestamos);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                        }
                        else if (accionBiblio == "2")
                        {
                            Console.WriteLine("\n=== Eliminar Material ===");
                            Console.Write("Título del material a eliminar: ");
                            string tituloEliminar = Console.ReadLine();
                            MaterialDigital material = catalogo.Find(m => m.Titulo == tituloEliminar);
                            if (material != null)
                            {
                                bibliotecario.AdministrarCatalogo(catalogo, material, false, prestamos);
                            }
                            else
                            {
                                Console.WriteLine("Material no encontrado.");
                            }
                        }
                        else if (accionBiblio == "3")
                        {
                            Console.WriteLine("\n=== Gestionar Préstamo Vencido ===");
                            Console.Write("Título del material: ");
                            string tituloPrestamo = Console.ReadLine();
                            MaterialDigital materialPrestamo = catalogo.Find(m => m.Titulo == tituloPrestamo);
                            if (materialPrestamo != null)
                            {
                                Prestamo prestamo = prestamos.Find(p => p.Material == materialPrestamo && p.Estado == EstadoPrestamo.Activo);
                                if (prestamo != null)
                                {
                                    bibliotecario.GestionarPrestamoVencido(prestamo.Usuario, materialPrestamo, prestamos);
                                }
                                else
                                {
                                    Console.WriteLine("No hay préstamos activos para este material.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Material no encontrado.");
                            }
                        }
                        else if (accionBiblio == "4")
                        {
                            Console.WriteLine("\n=== Exportar Reporte ===");
                            Console.WriteLine("Seleccione formato de reporte (1: PDF, 2: CSV, 3: JSON): ");
                            string formato = Console.ReadLine();
                            IEstrategiaReporte estrategia = formato switch
                            {
                                "1" => new ReportePDF(),
                                "2" => new ReporteCSV(),
                                "3" => new ReporteJSON(),
                                _ => null
                            };
                            if (estrategia != null)
                                estrategia.Exportar(catalogo, $"reporte.{formato}");
                            else
                                Console.WriteLine("Formato inválido.");
                        }
                        else
                        {
                            Console.WriteLine("Acción no válida.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No hay bibliotecarios registrados. Cree uno primero.");
                    }
                    break;
                case "3":
                    if (usuarios.Any(u =>
                            (u is Usuario usu && usu.Membresia == TipoMembresia.Premium)
                            || u is UsuarioPremium))
                    {
                        UsuarioBase usuarioPremium =
                            usuarios.First(u =>
                                (u is Usuario usu && usu.Membresia == TipoMembresia.Premium)
                                || u is UsuarioPremium);

                        Console.WriteLine("\n=== Explorar como Usuario Premium ===");
                        usuarioPremium.ExplorarCatalogo(catalogo);
                    }
                    else
                    {
                        Console.WriteLine("No hay usuarios premium registrados. Cree uno primero.");
                    }
                    break;

                case "4":
                    if (usuarios.Any(u => u is VisitanteTemporal))
                    {
                        VisitanteTemporal visitante = (VisitanteTemporal)usuarios.First(u => u is VisitanteTemporal);
                        Console.WriteLine("\n=== Explorar como Visitante ===");
                        visitante.ExplorarCatalogo(catalogo);
                    }
                    else
                    {
                        Console.WriteLine("No hay visitantes registrados. Cree uno primero.");
                    }
                    break;

                case "5":
                    Console.WriteLine("Saliendo del sistema...");
                    return;
                    
                      case "6":
                        bool salirSafeEntry = false;

                        while (!salirSafeEntry)
                        {
                            Console.WriteLine("\n=== SAFE ENTRY ===");
                            Console.WriteLine("1. Registrar nuevo empleado");
                            Console.WriteLine("2. Mostrar empleados registrados");
                            Console.WriteLine("3. Validar acceso de un empleado");
                            Console.WriteLine("4. Salir de SAFE ENTRY");
                            Console.Write("Seleccione una opción: ");
                            string opcionSafe = Console.ReadLine();

                            switch (opcionSafe)
                            {
                                case "1":
                                    try
                                    {
                                        Console.Write("ID del empleado (DNI o UUID): ");
                                        string id = Console.ReadLine();

                                        Console.Write("Nombre: ");
                                        string nombre = Console.ReadLine();

                                        Console.Write("Edad: ");
                                        int edad = int.Parse(Console.ReadLine());
                                        if (edad < 18)
                                        {
                                            Console.WriteLine("No se puede registrar a menores de 18 años.");
                                            break;
                                        }

                                        Console.Write("Correo electrónico: ");
                                        string correo = Console.ReadLine();
                                        if (!correo.Contains("@") || !correo.Contains("."))
                                        {
                                            Console.WriteLine("Correo inválido.");
                                            break;
                                        }

                                        Console.Write("Contraseña: ");
                                        string contrasena = Console.ReadLine();
                                        if (contrasena.Length < 8 || !contrasena.Any(char.IsUpper))
                                        {
                                            Console.WriteLine("Contraseña insegura. Debe tener al menos 8 caracteres y una mayúscula.");
                                            break;
                                        }

                                        Console.Write("Nivel de permiso (1,2,3...): ");
                                        int nivelPermiso = int.Parse(Console.ReadLine());

                                        Empleado nuevoEmpleado = new Empleado(id, nombre, edad, correo, contrasena, nivelPermiso);
                                        empleados.Add(nuevoEmpleado);
                                        Console.WriteLine($"Empleado {nombre} registrado correctamente.");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;

                                case "2":
                                    Console.WriteLine("\n=== Empleados Registrados ===");
                                    foreach (var emp in empleados)
                                    {
                                        emp.MostrarDatos();
                                        Console.WriteLine("----");
                                    }
                                    break;

                                case "3":
                                    Console.Write("Ingrese el ID del empleado a validar: ");
                                    string idValidar = Console.ReadLine();
                                    Empleado empVal = empleados.Find(e => e.Id == idValidar);
                                    if (empVal != null)
                                    {
                                        if (empVal.ValidarEdad())
                                            Console.WriteLine($"{empVal.Nombre} puede acceder.");
                                        else
                                            Console.WriteLine($"{empVal.Nombre} NO puede acceder.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Empleado no encontrado.");
                                    }
                                    break;

                                case "4":
                                    salirSafeEntry = true;
                                    break;

                                default:
                                    Console.WriteLine("Opción no válida.");
                                    break;
                            }
                        }
                        break;
                        default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
            Console.WriteLine("----");
            }
        }
  }