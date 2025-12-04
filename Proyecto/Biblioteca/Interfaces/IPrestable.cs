using Biblioteca.Models; 

namespace Biblioteca.Interfaces;
public interface IPrestable
{
    void Prestar(UsuarioBase usuario);
    void Devolver();
    bool VerificarDisponibilidad();
}