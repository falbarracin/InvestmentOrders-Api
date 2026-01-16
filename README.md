# Investment Orders API

## Descripción

Este proyecto implementa una API RESTful para la gestión de órdenes de inversión en el mercado financiero

---

## Arquitectura

La solución está organizada siguiendo una arquitectura en capas:

API (Controllers, Middleware)

Application (Servicios, DTOs, reglas de negocio)

Domain (Entidades, contratos)

Infrastructure (Persistencia, EF Core, SQL Server)

---

## Tecnologías utilizadas

- ASP.NET Core 8
- C#
- Entity Framework Core
- SQL Server
- Docker / Docker Compose
- Swagger (OpenAPI)
- xUnit + Moq
- Visual Studio 2022

---

## API REST

### Crear orden

**POST** `/api/orders`

json Request:
{
  "accountId": 2147483647,
  "assetId": 2147483647,
  "quantity": 2147483647,
  "price": 0.01
}

### Obtener orden por ID

**GET** `/api/orders/{id}`

200 OK si existe

404 Not Found si no existe

## Levantar el entorno completo

Desde la raíz del proyecto ejecutar desde una consola cmd:

1-
docker exec -i investmentorders-sql /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P YourStrong!Passw0rd -C -i /db/init.sql

2-
docker-compose up --build

Esto levanta automáticamente:

SQL Server

Base de datos InvestmentOrdersDb

Tablas

Datos de referencia

API ASP.NET Core

## Api 

http://localhost:5000

## Ejecutar tests por consola

Desde la carpeta src:

dotnet test
