using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Models;
namespace Biblioteca.Interface.Reports
{
    public class ReportePDF : IEstrategiaReporte
    {
        public void Exportar(List<MaterialDigital> catalogo, string archivo)
        {
            Console.WriteLine($"Exportando catálogo a PDF: {archivo}");
            foreach (var material in catalogo)
                Console.WriteLine($"[PDF] {material.Titulo}");
        }
    }
}
