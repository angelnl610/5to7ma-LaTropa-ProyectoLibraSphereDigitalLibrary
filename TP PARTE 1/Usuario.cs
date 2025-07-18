namespace LibraSphere;

public enum TipoMembresia
{
    Gratuita,
    Premium
}

public class Usuario
{
    private string _nombreCompleto;
    private string _correoElectronico;
    private DateOnly _fechaNacimiento;
    private string _numeroDocumento;
    private string _direccion;
    private string _contrasena;
    private TipoMembresia _membresia;

    // Constructor
    public Usuario(string nombreCompleto, string correoElectronico, string fechaNacimiento, string numeroDocumento, string direccion, string contrasena, TipoMembresia membresia)
    {
        Validaciones.CadenaMin(nombreCompleto, 4, "El nombre debe tener al menos 4 caracteres.");
        Validaciones.CorreoElectronico(correoElectronico, "El correo electrónico no es válido.");
        DateOnly fecha = Validaciones.FechaValida(fechaNacimiento);
        Validaciones.FechaMayorDeTrece(fecha, "El usuario debe tener al menos 13 años.");
        Validaciones.CadenaMin(numeroDocumento, 6, "El número de documento debe tener al menos 6 caracteres.");
        Validaciones.CadenaMin(direccion, 10, "La dirección debe tener al menos 10 caracteres.");
        Validaciones.CadenaMin(contrasena, 8, "La contraseña debe tener al menos 8 caracteres.");

        _nombreCompleto = nombreCompleto;
        _correoElectronico = correoElectronico;
        _fechaNacimiento = fecha;
        _numeroDocumento = numeroDocumento;
        _direccion = direccion;
        _contrasena = contrasena;
        _membresia = membresia;
    }

    // Setters
    public void SetNombreCompleto(string nombreCompleto)
    {
        Validaciones.CadenaMin(nombreCompleto, 4, "El nombre debe tener al menos 4 caracteres.");
        _nombreCompleto = nombreCompleto;
    }

    public void SetCorreoElectronico(string correoElectronico)
    {
        Validaciones.CorreoElectronico(correoElectronico, "El correo electrónico no es válido.");
        _correoElectronico = correoElectronico;
    }

    public void SetFechaNacimiento(string fechaNacimiento)
    {
        DateOnly fecha = Validaciones.FechaValida(fechaNacimiento);
        Validaciones.FechaMayorDeTrece(fecha, "El usuario debe tener al menos 13 años.");
        _fechaNacimiento = fecha;
    }

    public void SetNumeroDocumento(string numeroDocumento)
    {
        Validaciones.CadenaMin(numeroDocumento, 6, "El número de documento debe tener al menos 6 caracteres.");
        _numeroDocumento = numeroDocumento;
    }

    public void SetDireccion(string direccion)
    {
        Validaciones.CadenaMin(direccion, 10, "La dirección debe tener al menos 10 caracteres.");
        _direccion = direccion;
    }

    public void SetContrasena(string contrasena)
    {
        Validaciones.CadenaMin(contrasena, 8, "La contraseña debe tener al menos 8 caracteres.");
        _contrasena = contrasena;
    }

    public void SetMembresia(TipoMembresia membresia)
    {
        _membresia = membresia;
    }

    // Getters
    public string GetNombreCompleto() => _nombreCompleto;
    public string GetCorreoElectronico() => _correoElectronico;
    public DateOnly GetFechaNacimiento() => _fechaNacimiento;
    public string GetNumeroDocumento() => _numeroDocumento;
    public string GetDireccion() => _direccion;
    public string GetContrasena() => _contrasena;
    public TipoMembresia GetMembresia() => _membresia;

    public void MostrarDatosUsuario() => Console.WriteLine($"Nombre: {_nombreCompleto}\nDNI: {_numeroDocumento}\nCorreo Electrónico: {_correoElectronico}\nNacimiento: {_fechaNacimiento}\nDirección: {_direccion}\nMembresía: {_membresia}");
}