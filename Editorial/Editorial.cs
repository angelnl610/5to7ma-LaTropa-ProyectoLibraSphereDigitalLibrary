namespace EjemploEditorial
{
   public class Editorial
   {
       private string nombre;
       private string paisOrigen;
       private int anioFundacion;
       private string sitioWeb;

       public Editorial(string nombre , string paisOrigen, int anioFundacion, string sitioWeb)
       {
        Validaciones.Nombre(nombre, "El nombre de la editorial no es válido.");
        Validaciones.Pais(paisOrigen, "El país de origen no es válido.");
        Validaciones.AnioFundacion(anioFundacion, "El año de fundación no es válido.");
        Validaciones.SitioWeb(sitioWeb, "El sitio web no es válido.");

        this.nombre = nombre;
        this.paisOrigen = paisOrigen;
        this.anioFundacion = anioFundacion;
        this.sitioWeb = sitioWeb;
       }


       public string Nombre
       {
           get { return nombre; }
           set
           {
               Validaciones.Nombre(value, "El nombre de la editorial no es válido.");
               nombre = value;
           }
       }


       public string PaisOrigen
       {
           get { return paisOrigen; }
           set
           {
               Validaciones.Pais(value, "El país de origen no es válido.");
               paisOrigen = value;
           }
       }


       public int AnioFundacion
       {
           get { return anioFundacion; }
           set
           {
               Validaciones.AnioFundacion(value, "El año de fundación no es válido.");
               anioFundacion = value;
           }
       }


       public string SitioWeb
       {
           get { return sitioWeb; }
           set
           {
               Validaciones.SitioWeb(value, "El sitio web no es válido.");
               sitioWeb = value;
           }
       }
   }
}
