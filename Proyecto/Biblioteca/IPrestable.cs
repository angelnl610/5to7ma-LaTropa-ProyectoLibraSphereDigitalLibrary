namespace DigitalLibrary;

public interface IPrestable
{
    void Prestar(UsuarioBase usuario);
    void Devolver();
    bool VerificarDisponibilidad();
}