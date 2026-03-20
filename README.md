<div align="center">

# 🛒 MyProduct

### ASP.NET Core MVC · SQL Server · C# · .NET 10

Aplicación web full-stack para gestión de productos y categorías, construida con ASP.NET Core MVC siguiendo principios de arquitectura limpia con capa de acceso a datos e inyección de dependencias.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)

</div>

---

## 📋 Tabla de Contenidos

- [Descripción](#-descripción)
- [Funcionalidades](#-funcionalidades)
- [Capturas de pantalla](#-capturas-de-pantalla)
- [Diseño de la base de datos](#-diseño-de-la-base-de-datos)
- [Estructura del proyecto](#-estructura-del-proyecto)
- [Cómo ejecutar el proyecto](#-cómo-ejecutar-el-proyecto)
- [Tecnologías utilizadas](#-tecnologías-utilizadas)

---

## 🔍 Descripción

**MyProduct** es una aplicación web para gestionar un catálogo de productos con soporte de categorización. Implementa operaciones **CRUD completas** tanto para Productos como para Categorías, con asignación dinámica de categorías al momento de crear productos. Construida con arquitectura en capas que separa el acceso a datos de la lógica de presentación usando **Inyección de Dependencias**.

---

## ✨ Funcionalidades

| Funcionalidad | Descripción |
|---|---|
| 📦 **Gestión de Productos** | Crear, ver, editar y eliminar productos con nombre, precio y categoría |
| 🏷️ **Gestión de Categorías** | CRUD completo para categorías de productos |
| 🔗 **Asignación de Categoría** | Dropdown dinámico cargado desde la BD al crear/editar productos |
| ✅ **Notificaciones de éxito** | Mensajes de alerta al crear o eliminar registros correctamente |
| 🗑️ **Confirmación de eliminación** | Pantalla de confirmación antes de eliminar cualquier registro |
| 💉 **Inyección de Dependencias** | Clases de acceso a datos registradas con `AddSingleton` en `Program.cs` |
| 🔒 **Consultas parametrizadas** | Todas las consultas usan parámetros para prevenir inyección SQL |

---

## 📸 Capturas de pantalla

### 🏠 Inicio
![Home](screenshots/home.png)

### 📦 Lista de Productos
![Products](screenshots/products.png)

### ➕ Crear Producto — con dropdown de categorías en tiempo real
![Create Product](screenshots/create_product.png)

### 🏷️ Lista de Categorías
![Categories](screenshots/categories.png)

### ➕ Crear Categoría — con notificación de éxito
![Create Category Success](screenshots/category_success.png)

### ✏️ Editar Categoría
![Edit Category](screenshots/edit_category.png)

### 🗑️ Confirmación de eliminación
![Delete Category](screenshots/delete_category.png)

---

## 🗄️ Diseño de la base de datos

### Diagrama Entidad-Relación

```
┌─────────────────────┐          ┌─────────────────────┐
│      Categories     │          │       Products       │
├─────────────────────┤          ├─────────────────────┤
│ 🔑 CategoryId (PK)  │◄────────┤ 🔑 ProductId  (PK)  │
│    Name  NVARCHAR   │  1  ───  N│ 🔗 CategoryId (FK)  │
└─────────────────────┘          │    Name  NVARCHAR   │
                                 │    Price  DECIMAL   │
                                 └─────────────────────┘
```

### Tabla: `Categories`

| Columna | Tipo | Restricciones |
|---|---|---|
| `CategoryId` | `INT` | `PRIMARY KEY`, `IDENTITY(1,1)` |
| `Name` | `NVARCHAR(100)` | `NOT NULL` |

### Tabla: `Products`

| Columna | Tipo | Restricciones |
|---|---|---|
| `ProductId` | `INT` | `PRIMARY KEY`, `IDENTITY(1,1)` |
| `Name` | `NVARCHAR(200)` | `NOT NULL` |
| `Price` | `DECIMAL(18,2)` | `NOT NULL` |
| `CategoryId` | `INT` | `FOREIGN KEY → Categories(CategoryId)` |

### Script SQL

```sql
CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    Name       NVARCHAR(100) NOT NULL
);

CREATE TABLE Products (
    ProductId  INT PRIMARY KEY IDENTITY(1,1),
    Name       NVARCHAR(200) NOT NULL,
    Price      DECIMAL(18,2) NOT NULL,
    CategoryId INT NOT NULL,
    CONSTRAINT FK_Products_Categories
        FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);
```

---

## 🗂️ Estructura del proyecto

```
MyProduct/
│
├── Controllers/
│   ├── HomeController.cs          # Página de inicio
│   ├── ProductController.cs       # CRUD de productos
│   └── CategoryController.cs      # CRUD de categorías
│
├── Data/
│   ├── DataAccess.cs              # Clase base con cadena de conexión
│   ├── ProductData.cs             # Consultas SQL para productos
│   └── CategoryData.cs            # Consultas SQL para categorías
│
├── Models/
│   ├── Product.cs                 # Modelo de producto
│   └── Category.cs                # Modelo de categoría
│
├── Views/
│   ├── Shared/
│   │   └── _Layout.cshtml         # Navbar y layout compartido
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Product/
│   │   ├── Index.cshtml           # Lista de productos
│   │   ├── Create.cshtml          # Formulario con dropdown de categorías
│   │   ├── Edit.cshtml
│   │   └── Delete.cshtml
│   └── Category/
│       ├── Index.cshtml           # Lista de categorías con alerta de éxito
│       ├── Create.cshtml
│       ├── Edit.cshtml
│       └── Delete.cshtml
│
├── appsettings.json               # Configuración de cadena de conexión
└── Program.cs                     # Registro de DI + middleware
```

---

## 🚀 Cómo ejecutar el proyecto

### Requisitos previos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local o remoto)
- Visual Studio 2022+ o VS Code

### 1. Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/MyProduct.git
cd MyProduct
```

### 2. Configurar la base de datos

Ejecuta el script SQL de la sección [Diseño de la base de datos](#-diseño-de-la-base-de-datos) en SQL Server Management Studio o Azure Data Studio.

### 3. Actualizar la cadena de conexión

Edita `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TU_SERVIDOR; Database=SampleDb; Trusted_Connection=True; TrustServerCertificate=True;"
  }
}
```

### 4. Ejecutar la aplicación

```bash
dotnet restore
dotnet run
```

Navega a `https://localhost:5001`

---

## 🛠️ Tecnologías utilizadas

| Tecnología | Uso |
|---|---|
| **ASP.NET Core MVC (.NET 10)** | Framework web |
| **C#** | Lenguaje backend |
| **SQL Server** | Base de datos relacional |
| **Microsoft.Data.SqlClient** | Acceso a datos con ADO.NET puro |
| **Bootstrap 5** | Estilos de interfaz |
| **Razor Views** | Renderizado HTML del lado del servidor |
| **Inyección de Dependencias** | Registro de servicios en `Program.cs` |

---

<div align="center">

Hecho con ❤️ usando ASP.NET Core MVC

</div>
