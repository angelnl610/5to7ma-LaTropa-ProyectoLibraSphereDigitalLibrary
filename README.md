# 📚 LibraSphere

Sistema de gestión de biblioteca digital desarrollado como aplicación de consola en **C#**, aplicando principios de POO, validaciones centralizadas, herencia, interfaces, estrategias de exportación y separación de capas.

---

## 🚀 Descripción General

LibraSphere es un sistema que administra distintos tipos de **Material Digital**, así como **Usuarios** con diferentes permisos y un sistema de **Préstamos** con reglas propias.

El proyecto está dividido en dos capas:

* **Biblioteca** → contiene toda la lógica del sistema.
* **Consola** → interfaz con el usuario final.

El menú principal permite:

1. Crear materiales o usuarios
2. Explorar catálogo como Bibliotecario
3. Explorar catálogo como Usuario Premium
4. Explorar catálogo como Visitante
5. Salir

---

## 🧱 Arquitectura del Sistema

### **📌 MaterialDigital (abstracto)**

Clase base para todos los contenidos:

* Libro
* Revista
* Audiolibro
* Libro Interactivo

Cada clase hereda comportamientos comunes y puede sobrescribir:

* `MostrarResumen()`
* `ValidarIntegridad()`
* `Eliminar()`

### **Interfaces**

* **IPrestable** → materiales que pueden ser prestados
* **IMultimedia** → materiales que tienen contenido multimedia

### **Usuarios (herencia)**

Base: `UsuarioBase`

Tipos de usuario:

* Usuario común
* Usuario premium (préstamos más largos)
* Visitante temporal (no puede prestar)
* Bibliotecario (administra catálogo y reportes)

---

## 🔗 Préstamos

La clase `Prestamo` gestiona:

* verificar disponibilidad
* estados y subestados
* vencimientos
* devoluciones
* La Fecha inicial del Préstamo es la actual en la que se está usando el programa
* Usurios Estandar tienen fecha máxima de préstamos de 15 días y Usuarios Premium de 30 días

---

## 🛡 Validaciones Centralizadas

La clase `Validaciones` incluye reglas de:

* ISBN
* Fechas
* Membresías
* Edad mínima
* Formatos
* Plataformas permitidas

Todas las validaciones arrojan excepciones ante datos incorrectos.

---

## 📤 Exportación de Reportes

Implementado con el patrón **Estrategia**:

* `ReportePDF`
* `ReporteCSV`
* `ReporteJSON`

Todas implementan `IEstrategiaReporte`.

---

## 🖥️ Uso en Terminal

### Menú principal:

```
=== Menú de LibraSphere ===
1. Crear Material o Usuario
2. Explorar Catálogo como Bibliotecario
3. Explorar Catálogo como Usuario Premium
4. Explorar Catálogo como Visitante
5. Salir
```

Cada opción te lleva a menús específicos según el tipo de usuario.

---

## 🧪 Tecnologías y conceptos aplicados

* C# .NET
* Programación orientada a objetos
* Herencia y polimorfismo
* Clases abstractas e interfaces
* Manejo de excepciones
* Colecciones genéricas
* Patrón Estrategia para exportaciones
* Validaciones desacopladas
* Separación de capas (consola + biblioteca)

---

## 📌 Requisitos del Sistema

* .NET 8 (o superior)
* Consola de Windows, Linux o Mac

---

## 🙌 Autores

Proyecto realizado por **Eric Aguirre, Celedonio Leon Flores y Angel Lopez** para la materia de Laboratorio de Programación Orientada a Objetos
