using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Interfaces;
namespace Biblioteca.Models;
public class Revista : MaterialDigital, IPrestable
{
    public int NumeroEdicion { get; private set; }
    public string Periodicidad { get; private set; }
    public bool EstaArchivada { get; private set; }

    public Revista(string id, string titulo, string autor, DateOnly fechaPublicacion, int numeroEdicion, string periodicidad, bool estaArchivada)
        : base(id, titulo, autor, fechaPublicacion)
    {
        Validacion.EnteroMin(numeroEdicion, 1, "El número de edición debe ser mayor a 0.");
        Validacion.ValidarPeriodicidad(periodicidad, "La periodicidad debe ser Semanal, Mensual o Anual.");

        NumeroEdicion = numeroEdicion;
        Periodicidad = periodicidad;
        EstaArchivada = estaArchivada;
    }

    public override void MostrarResumen()
    {
        Console.WriteLine($"Revista: {Titulo} | Autor: {Autor} | Edición: {NumeroEdicion} | Periodicidad: {Periodicidad} | Archivada: {(EstaArchivada ? "Sí" : "No")}");
    }

    public override void ValidarIntegridad()
    {
        Validacion.ValidarISBN(Id, "El ISBN de la revista es inválido.");
        if (NumeroEdicion <= 0) throw new ArgumentException("El número de edición debe ser mayor a 0.");
        if (string.IsNullOrEmpty(Periodicidad)) throw new ArgumentException("La periodicidad es inválida.");
    }

    public override void Eliminar(List<Prestamo> prestamos)
    {
        prestamos.RemoveAll(p => p.Material.Id == Id);
        Console.WriteLine($"Eliminando revista {Titulo} y sus préstamos asociados...");
    }

    public void Prestar(UsuarioBase usuario)
    {
        if (!VerificarDisponibilidad()) throw new InvalidOperationException("La revista no está disponible.");
        if (usuario is VisitanteTemporal) throw new InvalidOperationException("Los visitantes no pueden prestar materiales.");
        EstaPrestado = true;
        Console.WriteLine($"Revista {Titulo} prestada a {usuario.Nombre}");
    }

    public void Devolver()
    {
        if (!EstaPrestado) throw new InvalidOperationException("La revista no está prestada.");
        EstaPrestado = false;
        Console.WriteLine($"Revista {Titulo} devuelta");
    }

    public bool VerificarDisponibilidad()
    {
        return !EstaPrestado;
    }
}