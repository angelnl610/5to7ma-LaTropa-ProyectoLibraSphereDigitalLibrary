using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models;

    public class Editorial
    {
        public string Nombre { get; private set; }
        public string PaisOrigen { get; private set; }
        public int AnioFundacion { get; private set; }
        public string SitioWeb { get; private set; }

        public Editorial(string nombre, string paisOrigen, int anioFundacion, string sitioWeb)
        {
            Validaciones.CadenaMin(nombre, 3, "El nombre de la editorial debe tener al menos 3 caracteres.");
            Validaciones.CadenaMin(paisOrigen, 3, "El país de origen debe tener al menos 3 caracteres.");
            Validaciones.EnteroMin(anioFundacion, 1800, "El año de fundación debe ser mayor a 1800.");
            Validaciones.CadenaMin(sitioWeb, 1, "El sitio web no puede estar vacío.");

            Nombre = nombre;
            PaisOrigen = paisOrigen;
            AnioFundacion = anioFundacion;
            SitioWeb = sitioWeb;
        }

        public void MostrarDatos()
        {
            Console.WriteLine(
                $"Nombre: {Nombre}\n" +
                $"País de Origen: {PaisOrigen}\n" +
                $"Año de Fundación: {AnioFundacion}\n" +
                $"Sitio Web: {SitioWeb}"
            );
        }
    }

