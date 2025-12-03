using System;
using System.Collections.Generic;

namespace DigitalLibrary
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
