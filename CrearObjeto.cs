namespace LibraSphere
{
    public class CrearObjeto
    {
        
        public static Editorial Editorial()
        { 


            string Nombre = ConversionParse.Cadena("Ingrese el nombre de la editorial");
            string PaisOrigen = ConversionParse.Cadena("Ingrese el pais de origen");
            int AnioFundacion = ConversionParse.Entero("Ingrese el año de fundacion");
            string SitioWeb  = ConversionParse.Cadena("Ingrese el sitio web");

            Editorial editorial = new Editorial (Nombre, PaisOrigen, AnioFundacion, SitioWeb);

            return editorial;
        }


        /* No se por qué en Libro tira error. 
        public static Libro Libro()
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
        */

        /* Aca pasa algo similar pero en FechaNacimiento
        public static Usuario Usuario()
        {


            string NombreCompleto = ConversionParse.Cadena("Ingrese su nombre completo");
            string CorreoElectronico = ConversionParse.Cadena("Ingrese su correo electronico");
            string FechaNacimiento = ConversionParse.Cadena("Ingrese su fecha de nacimiento en formato YYYY-MM-DD");
            string NumeroDocumento = ConversionParse.Cadena("Ingrese su numero de documento");
            string Direccion = ConversionParse.Cadena("Ingrese su direccion");
            string Contraseña = ConversionParse.Cadena("Ingrese su contraseña");
            bool MembresiaActiva = false;

            Usuario usuario = new Usuario(NombreCompleto, CorreoElectronico, FechaNacimiento, NumeroDocumento, Direccion, Contraseña, MembresiaActiva)

            return usuario;
        }

        */


        // Falta metodo para crear Prestamo







    }
}