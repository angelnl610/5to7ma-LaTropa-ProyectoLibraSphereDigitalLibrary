using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Interface;
using Biblioteca.Models;

namespace Biblioteca.Interface.Reports
{
    public class ReporteCSV : IEstrategiaReporte
    {
        public void Exportar(List<MaterialDigital> catalogo, string archivo)
        {
            Console.WriteLine($"Exportando catálogo a CSV: {archivo}");
            Console.WriteLine("Titulo,Autor,FechaPublicacion");
            foreach (var material in catalogo)
                Console.WriteLine($"{material.Titulo},{material.Autor},{material.FechaPublicacion}");
        }
    }
}