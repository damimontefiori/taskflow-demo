# Arquitectura propuesta para TaskFlow

## Componentes principales

### 1. Backend (.NET 8 Web API + Entity Framework Core)
- **Descripción:** API RESTful desarrollada en .NET 8, utilizando Entity Framework Core para el acceso a datos.
- **Interacción:** Expone endpoints para la gestión de tareas, usuarios y flujos de trabajo. Se comunica con la base de datos Azure SQL.
- **Justificación:** .NET 8 ofrece alto rendimiento, seguridad y soporte a largo plazo. Entity Framework Core simplifica el mapeo objeto-relacional y agiliza el desarrollo.

### 2. Frontend (Angular)
- **Descripción:** Aplicación SPA desarrollada en Angular, consumiendo la API del backend.
- **Interacción:** Realiza peticiones HTTP al backend para mostrar y gestionar información en tiempo real.
- **Justificación:** Angular proporciona una estructura robusta para aplicaciones empresariales, facilita el desarrollo modular y la integración con APIs REST.

### 3. Base de datos (Azure SQL)
- **Descripción:** Base de datos relacional en la nube, gestionada por Azure.
- **Interacción:** El backend accede a Azure SQL mediante Entity Framework Core para almacenar y consultar datos.
- **Justificación:** Azure SQL garantiza alta disponibilidad, escalabilidad y seguridad, además de integración nativa con servicios de Azure.

### 4. Despliegue (Azure Container Instances)
- **Descripción:** Los servicios de backend y frontend se despliegan como contenedores independientes.
- **Interacción:** Azure Container Instances ejecuta los contenedores, facilitando la escalabilidad y el aislamiento de servicios.
- **Justificación:** Permite despliegues rápidos, gestión simplificada y reducción de costos operativos, sin necesidad de administrar infraestructura subyacente.

## Interacción entre componentes

```mermaid
flowchart LR
    A[Usuario] --> B[Frontend (Angular)]
    B -->|HTTP| C[Backend (.NET 8 Web API)]
    C -->|EF Core| D[Azure SQL]
    B & C --> E[Azure Container Instances]
```

## Resumen de elecciones tecnológicas
- **.NET 8 + EF Core:** Desarrollo rápido, rendimiento y soporte empresarial.
- **Angular:** Experiencia de usuario moderna y mantenibilidad.
- **Azure SQL:** Seguridad y escalabilidad en la nube.
- **Azure Container Instances:** Despliegue ágil y flexible.
