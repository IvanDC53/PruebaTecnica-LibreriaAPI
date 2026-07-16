# 📚 Librería API RESTful

Una API robusta y escalable desarrollada en **.NET Core** para la gestión de un sistema de librerías. Este proyecto demuestra la implementación de arquitectura de software moderna, seguridad y buenas prácticas de desarrollo.

## 🚀 Tecnologías Utilizadas
* **Framework:** .NET (C#)
* **Base de Datos:** SQL Server Express
* **ORM:** Entity Framework Core (Code-First)
* **Seguridad:** JWT (JSON Web Tokens) y RBAC (Role-Based Access Control)
* **Testing:** xUnit + EF Core In-Memory Database
* **Documentación:** Swagger / OpenAPI

## ✨ Características Principales
* **CRUD Completo:** Gestión integral de Autores, Libros y Préstamos.
* **Consultas Optimizadas:** Endpoints específicos y bases de datos indexadas para búsquedas de libros clásicos y préstamos pendientes.
* **Seguridad por Roles:**
  * Acceso de solo lectura para todos los usuarios autenticados.
  * Permisos exclusivos de escritura, edición y eliminación para el rol de **Administrador**.
* **Integridad de Datos:** Validaciones en cascada y relaciones explícitas de llaves foráneas.

## 🛠️ Instrucciones de Instalación y Uso

### 1. Prerrequisitos
* [.NET SDK](https://dotnet.microsoft.com/download) instalado.
* SQL Server Express instalado y corriendo localmente.

### 2. Clonar el repositorio
```bash
git clone [https://github.com/tu-usuario/LibreriaAPI.git](https://github.com/tu-usuario/LibreriaAPI.git)
cd LibreriaAPI
