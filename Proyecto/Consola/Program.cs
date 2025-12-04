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

        while (true)
        {
            Console.WriteLine("\n=== Menú de LibraSphere ===");
            Console.WriteLine("1. Crear Materiales, Usuarios y Préstamos");
            Console.WriteLine("2. Explorar Catálogo como Bibliotecario");
            Console.WriteLine("3. Explorar Catálogo como Usuario Premium");
            Console.WriteLine("4. Explorar Catálogo como Visitante");
            Console.WriteLine("5. Salir");
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
                    if (usuarios.Any(u => u is Usuario u2 && u2.Membresia == TipoMembresia.Premium || u is UsuarioPremium))
                    {
                        UsuarioBase usuarioPremium = usuarios.First(u => u is Usuario u2 && u2.Membresia == TipoMembresia.Premium || u is UsuarioPremium);
                        Console.WriteLine("\n=== Explorar como Usuario Premium ===");
                        usuarioPremium.ExplorarCatalogo(catalogo);
                        Console.WriteLine("\nOpciones de Usuario Premium:");
                        Console.WriteLine("1. Prestar Material");
                        Console.WriteLine("2. Devolver Material");
                        Console.Write("Seleccione una acción: ");
                        string accionPremium = Console.ReadLine();
                        if (accionPremium == "1")
                        {
                            Console.WriteLine("\n=== Prestar Material ===");
                            Console.Write("Título del material: ");
                            string tituloPrestar = Console.ReadLine();
                            MaterialDigital material = catalogo.Find(m => m.Titulo == tituloPrestar);
                            if (material != null)
                            {
                                try
                                {
                                    Console.Write("Fecha de devolución (YYYY-MM-DD): ");
                                    string fechaDevolucion = Console.ReadLine();
                                    Prestamo prestamo = new Prestamo(material, fechaDevolucion, usuarioPremium);
                                    prestamos.Add(prestamo);
                                    if (usuarioPremium is Usuario u)
                                        u.PrestarMaterial(material);
                                    else if (usuarioPremium is UsuarioPremium up)
                                        up.PrestarMaterial(material);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Material no encontrado.");
                            }
                        }
                        else if (accionPremium == "2")
                        {
                            Console.WriteLine("\n=== Devolver Material ===");
                            Console.Write("Título del material: ");
                            string tituloDevolver = Console.ReadLine();
                            MaterialDigital material = catalogo.Find(m => m.Titulo == tituloDevolver);
                            if (material != null)
                            {
                                try
                                {
                                    if (usuarioPremium is Usuario u)
                                        u.DevolverMaterial(material);
                                    else if (usuarioPremium is UsuarioPremium up)
                                        up.DevolverMaterial(material);
                                    Prestamo prestamo = prestamos.Find(p => p.Material == material);
                                    if (prestamo != null)
                                    {
                                        prestamo.ActualizarFechaDevolucionReal(DateOnly.FromDateTime(DateTime.Now).ToString());
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error: {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Material no encontrado.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Acción no válida.");
                        }
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

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
            Console.WriteLine("----");
        }
    }
}