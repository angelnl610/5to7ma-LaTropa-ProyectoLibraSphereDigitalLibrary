namespace EjemploEditorial
{
   public class Editorial
   {
       private string nombre;
       private string paisOrigen;
       private int anioFundacion;
       private string sitioWeb;


       public string Nombre
       {
           get { return nombre; }
           set
           {
               Validaciones.ValidarNombre(value, "El nombre de la editorial no es válido.");
               nombre = value;
           }
       }


       public string PaisOrigen
       {
           get { return paisOrigen; }
           set
           {
               Validaciones.ValidarPais(value, "El país de origen no es válido.");
               paisOrigen = value;
           }
       }


       public int AnioFundacion
       {
           get { return anioFundacion; }
           set
           {
               Validaciones.ValidarAnioFundacion(value, "El año de fundación no es válido.");
               anioFundacion = value;
           }
       }


       public string SitioWeb
       {
           get { return sitioWeb; }
           set
           {
               Validaciones.ValidarSitioWeb(value, "El sitio web no es válido.");
               sitioWeb = value;
           }
       }
   }
}