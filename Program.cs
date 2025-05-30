using LibraSphere;

Editorial editorial1 = CrearObjeto.CrearEditorial();

Libro libro1 = CrearObjeto.CrearLibro();

Usuario usuario1 = CrearObjeto.CrearUsuario();

Prestamo prestamo1 = CrearObjeto.CrearPrestamo(libro1, usuario1);



editorial1.MostrarDatos();
libro1.MostrarDatos();
usuario1.MostrarDatosUsuario();
prestamo1.MostrarDatos();

