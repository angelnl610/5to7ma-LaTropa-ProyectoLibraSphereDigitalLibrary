using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Enums;
using Biblioteca.Models;

namespace Biblioteca.Interface.Reports
{
    public class ReporteJSON : IEstrategiaReporte
    {
        public void Exportar(List<MaterialDigital> catalogo, string archivo)
        {
            Console.WriteLine($"Exportando catálogo a JSON: {archivo}");
            Console.WriteLine("[");
            foreach (var material in catalogo)
                Console.WriteLine($"  {{ \"Titulo\": \"{material.Titulo}\", \"Autor\": \"{material.Autor}\", \"Fecha\": \"{material.FechaPublicacion}\" }},");
            Console.WriteLine("]");
        }
    }

}