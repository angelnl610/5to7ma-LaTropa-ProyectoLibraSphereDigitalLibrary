using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;

namespace Biblioteca.Interface;
public interface IEstrategiaReporte
{
    void Exportar(List<MaterialDigital> catalogo, string archivo);
}

