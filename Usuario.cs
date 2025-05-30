

namespace LibraSphere;

public class Usuario 
{
    private string NombreCompleto { get;  set; }
    private string CorreoElectronico { get;  set; }
    private DateOnly FechaNacimiento { get;  set; }
    private string NumeroDocumento { get;  set; }
    private string Direccion { get;  set; }
    private string Contraseña { get;  set; }
    private bool MembresiaActiva { get; set; }

        // Constructor
    public Usuario(string nombreCompleto, string correoElectronico, string fechaNacimiento, 
                   string numeroDocumento, string direccion, string contraseña, bool membresiaActiva)
    {
        Validaciones.CadenaMin(nombreCompleto, 4, "El nombre debe tener al menos 2 caracteres.");
        this.NombreCompleto = nombreCompleto;

        Validaciones.CorreoElectronico(correoElectronico, "El correo electronico no es valido.");
        this.CorreoElectronico = correoElectronico;
        this.FechaNacimiento = Validaciones.FechaValida(fechaNacimiento);
        Validaciones.FechaMayorDeTrece(FechaNacimiento, "El usuario debe tener al menos 13 años.");
        
        

        Validaciones.CadenaMin(numeroDocumento, 6, "El numero de documento debe tener al menos 6 caracteres.");
        this.NumeroDocumento = numeroDocumento;

        Validaciones.CadenaMin(direccion, 10, "La direccion debe tener al menos 10 caracteres.");
        this.Direccion = direccion;

        Validaciones.CadenaMin(contraseña, 8, "La contraseña debe tener al menos 8 caracteres.");
        this.Contraseña = contraseña;
        
        this.MembresiaActiva = membresiaActiva;
    }

        // Setters 
        public void SetNombre(string nombreCompleto)
        {
            Validaciones.CadenaMin(nombreCompleto, 3, "El nombre debe tener al menos 3 caracteres");
            this.NombreCompleto = nombreCompleto;
        }

        public void SetEmail(string email)
        {
            Validaciones.CorreoElectronico(email, "El correo electronico no es valido");
            this.CorreoElectronico = email;
        }

        public void SetFechaNacimiento(DateOnly fechaNacimiento)
        {
            Validaciones.FechaMayorDeTrece(fechaNacimiento, "El usuario debe ser mayor de edad");
            this.FechaNacimiento = fechaNacimiento;
        }

        public void SetContraseña(string contraseña)
        {
            Validaciones.CadenaMin(contraseña, 6, "La contraseña debe tener al menos 6 caracteres");
            this.Contraseña = contraseña;
        }

        public void SetMembresiaActiva(bool membresiaActiva)
        {
            this.MembresiaActiva = membresiaActiva;
        }
    
        // Getters
    public string GetNombreCompleto() => NombreCompleto;
        public string GetEmail() => CorreoElectronico;
        public DateOnly GetFechaNacimiento() => FechaNacimiento;
        public string GetDocumento() => NumeroDocumento;
        public string GetContraseña() => Contraseña;
        public bool GetMembresia() => MembresiaActiva;

    // metodoss
    
    public void MostrarDatosUsuario() => Console.WriteLine($"Nombre: {NombreCompleto} \nDNI: {NumeroDocumento} \nCorreo Electronico: {CorreoElectronico}  \nNacimiento: {FechaNacimiento} \nMembresia activa: {MembresiaActiva}");


}