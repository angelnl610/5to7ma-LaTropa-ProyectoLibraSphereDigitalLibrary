using Microsoft.VisualBasic;

namespace LibraSphere
{
    public class CrearObjeto
    {

        public static Editorial CrearEditorial()
        {


            string Nombre = ConversionParse.Cadena("Ingrese el nombre de la editorial");
            string PaisOrigen = ConversionParse.Cadena("Ingrese el pais de origen");
            int AnioFundacion = ConversionParse.Entero("Ingrese el año de fundacion");
            string SitioWeb = ConversionParse.Cadena("Ingrese el sitio web");

            Editorial editorial = new Editorial(Nombre, PaisOrigen, AnioFundacion, SitioWeb);

            return editorial;
        }

        public static Libro CrearLibro()
        {

            long Isbn = ConversionParse.Long("Ingrese el ISBN del libro");
            string Titulo = ConversionParse.Cadena("Ingrese el titulo del libro");
            string Autor = ConversionParse.Cadena("Ingrese el autor del libro");
            int CantPag = ConversionParse.Entero("Ingrese la cantidad de paginas del libro");
            string Idioma = ConversionParse.Cadena("Ingrese el idioma del libro");
            bool LibroEnUso = false;

            Libro libro = new Libro(Isbn, Titulo, Autor, CantPag, Idioma, LibroEnUso);

            return libro;

        }



        public static Usuario CrearUsuario()
        {


            string NombreCompleto = ConversionParse.Cadena("Ingrese su nombre completo");
            string CorreoElectronico = ConversionParse.Cadena("Ingrese su correo electronico");
            string FechaNacimiento = ConversionParse.Cadena("Ingrese su fecha de nacimiento en formato YYYY-MM-DD");
            string NumeroDocumento = ConversionParse.Cadena("Ingrese su numero de documento");
            string Direccion = ConversionParse.Cadena("Ingrese su direccion");
            string Contraseña = ConversionParse.Cadena("Ingrese su contraseña");
            bool MembresiaActiva = false;

            Usuario usuario = new Usuario(NombreCompleto, CorreoElectronico, FechaNacimiento, NumeroDocumento, Direccion, Contraseña, MembresiaActiva);

            return usuario;
        }


        public static Prestamo CrearPrestamo(Libro libro, Usuario usuario)
        {
            string fechaDevolucion = ConversionParse.Cadena("Ingrese la fecha con el formato 'YYYY-MM-DD'");

            Prestamo prestamo = new Prestamo(libro, fechaDevolucion, usuario);

            return prestamo;
        }


    }
}