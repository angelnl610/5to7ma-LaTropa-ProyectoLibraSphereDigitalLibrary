using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models; 

namespace Biblioteca.Interfaces;
public interface IPrestable
{
    void Prestar(UsuarioBase usuario);
    void Devolver();
    bool VerificarDisponibilidad();
}