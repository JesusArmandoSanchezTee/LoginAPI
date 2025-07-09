# LoginAPI Backend – ASP.NET Core Web API

Este proyecto representa el backend de autenticación y gestión de usuarios desarrollado con ASP.NET Core 8. Utiliza una arquitectura limpia (Clean Architecture) basada en buenas prácticas, separación de responsabilidades y patrones de diseño sólidos para asegurar escalabilidad, mantenibilidad y testabilidad.

---

## 🧱 Arquitectura

La solución está dividida en las siguientes capas:

- **Domain**: Entidades y contratos (interfaces, excepciones).
- **Application**: Casos de uso (MediatR), validaciones y lógica de negocio.
- **Infrastructure**: Implementaciones concretas de acceso a datos (EF Core).
- **Host**: Configuración de API, middlewares, DI y startup (`Program.cs`).

---

## 🛠️ Herramientas y tecnologías utilizadas

- **ASP.NET Core 8**
- **Entity Framework Core**
- **JWT (JSON Web Tokens)** para autenticación
- **MediatR** – patrón de mediador para desacoplar casos de uso
- **FluentValidation** – validación de entrada robusta
- **Swagger/OpenAPI** – documentación interactiva
- **SQL Server** – persistencia de datos

---

## 📐 Patrones de diseño implementados

### 1. 🗃️ Repository Pattern

> **Ubicación**: `Domain.Interfaces.IUserRepository`, `UserRepository.cs`

Separa la lógica de acceso a datos de la lógica de negocio. El `IUserRepository` abstrae la fuente de datos y se implementa con Entity Framework en `UserRepository`.

**Justificación**:
- Facilita el testeo unitario (mockeo de repositorios).
- Permite cambiar la fuente de datos (por ejemplo, de SQL a MongoDB) sin afectar la capa de aplicación.

---

### 2. 🧩 Strategy Pattern

> **Ubicación sugerida**: Aunque actualmente se usa login con email y contraseña, la estructura está preparada para introducir nuevas estrategias (OAuth, login por redes, etc.)

**Justificación**:
- Permite alternar dinámicamente mecanismos de login.
- Escalable para múltiples flujos de autenticación sin modificar los handlers existentes.

💡 **Implementación futura sugerida**: definir una interfaz `ILoginStrategy` con implementaciones como `EmailLoginStrategy`, `GoogleLoginStrategy`, etc., inyectadas dinámicamente.

---

### 3. 🧱 Dependency Injection (DI)

> **Ubicación**: Toda la configuración en `Program.cs` usa `IServiceCollection`.

**Justificación**:
- Desacopla componentes entre capas (repositorios, servicios, validadores).
- Facilita la inyección de dependencias, el reemplazo en testing y la reutilización.

---

## 🧰 Otros principios aplicados

- **Clean Architecture**: separación estricta entre capas.
- **Single Responsibility Principle**: cada clase tiene un solo propósito.
- **Open/Closed Principle**: puedes extender funcionalidades (e.g., nuevos validadores) sin modificar lógica existente.

---

## 🔐 Seguridad

- **Autenticación JWT**: tokens firmados y validados en cada request.
- **Middleware de excepciones**: errores controlados, sin fugas de información sensible.
- **Validaciones robustas**: todas las entradas son validadas antes de ejecutarse.

---

## 📄 Endpoints expuestos

- `POST /api/login/register` – Registro de usuarios.
- `POST /api/login/login` – Login y generación de token JWT.
- `GET /weatherforecast` – Endpoint de prueba.

---

## 📦 Validaciones

Usamos **FluentValidation** para validar comandos como `LoginUserCommand` y `RegisterUserCommand`. Esto asegura reglas de negocio claras y centralizadas.

---

## ✨ Mejoras futuras

- Soporte para múltiples estrategias de login (`ILoginStrategy`)
- Soporte para refresh tokens y expiración controlada
- Eventos globales (`Observer Pattern`) para logout/token expiration
- Logs estructurados y auditables

---

## 🚀 Cómo correr el proyecto

1. Configura la cadena de conexión en `appsettings.Development.json`.
2. Ejecuta las migraciones (si usas EF Core migrations).
3. Ejecuta el proyecto con `dotnet run`.
4. Abre Swagger en `https://localhost:{puerto}/swagger`.

---

## 📂 Estructura de carpetas

MyApp/
│
├── Domain/
│ ├── Entities/
│ ├── Interfaces/
│ └── Exceptions/
│
├── Application/
│ ├── Features/User/Commands/
│ └── Validators/
│
├── Infrastructure/
│ └── Persistence/
│
├── Host/
│ ├── Controllers/
│ └── Middlewares/
