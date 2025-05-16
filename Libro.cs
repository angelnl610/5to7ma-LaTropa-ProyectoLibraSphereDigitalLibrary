
namespace LibraSphere 
{
    public class Libro
    {
        private long Isbn { get;  set; }
        private string Titulo { get;  set; }
        private string Autor { get;  set; }
        private int CantPag { get;  set; }
        private string Idioma {get;  set;}
        private bool LibroEnUso { get; set; }

        // Constructor
        public Libro(long isbn, string titulo, string autor, int cantPag, string idioma)
        {
            Validaciones.EnteroBetweenLong(isbn, 0, 9999999999999, "El ISBN debe contener 13 digitos");
            this.Isbn = isbn;   

            Validaciones.CadenaMin(titulo, 1, "El titulo debe tener minimo de 1 caracter");
            this.Titulo = titulo;

            Validaciones.CadenaMin(autor, 4, "El autor debe tener minimo de 4 caracteres");
            this.Autor = autor;

            Validaciones.Entero(cantPag, "La cantidad de paginas debe ser un numero entero positivo");
            this.CantPag = cantPag;

            Validaciones.CadenaMin(idioma, 4, "El pais no es valido.");
            this.Idioma = idioma;

            this.LibroEnUso = false; 
        }

        // Setters
        public void SetISBN(int isbn)
        {
            Validaciones.EnteroBetweenLong(isbn, 0, 9999999999999, "El ISBN no debe ser mayor que 99.999.999 ni menor que 0");
            this.Isbn = isbn;
        }

        public void SetTitulo(string titulo)
        {
            Validaciones.CadenaMin(titulo, 4, "El titulo debe contener un minimo de 4 caracteres");
            this.Titulo = titulo;
        }

        public void SetAutor(string autor)
        {
            Validaciones.CadenaMin(autor, 4, "El autor debe contener un minimo de 4 caracteres");
            this.Autor = autor;
        }

        public void SetCantPag(int cantPag)
        {
            Validaciones.Entero(cantPag, "La cantidad de paginas debe ser un numero entero positivo");
            this.CantPag = cantPag;
        }

        public void SetIdioma(string idioma)
        {
            Validaciones.CadenaMin(idioma, 4, "El pais no es valido");
            this.Idioma = idioma;
        }

        public void SetLibroEnUso(bool enUso)
        {
            this.LibroEnUso = enUso;
        }

        // Getters
        public long GetISBN() => Isbn;
        public string GetTitulo() => Titulo;
        public string GetIdioma() => Idioma;
        public string GetAutor() => Autor;
        public int GetCantPag() => CantPag;
        public bool GetLibroEnUso() => LibroEnUso;


        public void MostrarDatos() => Console.WriteLine($"Titulo: {Titulo} n/ISBN: {Isbn} n/Autor: {Autor} n/Idioma: {Idioma} n/Cantidad de paginas: {CantPag} n/Libro en uso: {LibroEnUso}");

    }

    
    
}


